using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using DentistAppointmentSystem.Controllers;
using DentistAppointmentSystem.Models;
using DentistAppointmentSystem.ViewModels;
using DentistAppointmentSystem.Utilities;
using System.Threading.Tasks;
using System.Text;
using System;
using System.IO;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace DentistAppointmentSystem.Tests.Controllers
{
    public class AccountControllerTests
    {
        private readonly Mock<UserManager<ApplicationUser>> _userManagerMock;
        private readonly Mock<RoleManager<IdentityRole>> _roleManagerMock;
        private readonly Mock<SignInManager<ApplicationUser>> _signInManagerMock;
        private readonly Mock<IWebHostEnvironment> _webHostEnvironmentMock;
        private readonly AccountController _accountController;

        public AccountControllerTests()
        {
            // Mock dependencies
            _userManagerMock = MockUserManager();
            _roleManagerMock = MockRoleManager();
            _signInManagerMock = MockSignInManager();
            _webHostEnvironmentMock = new Mock<IWebHostEnvironment>();
            _webHostEnvironmentMock.Setup(m => m.WebRootPath).Returns(Path.GetTempPath());

            // Initialise AccountController with mocked dependencies
            _accountController = new AccountController(
                _userManagerMock.Object,
                _signInManagerMock.Object,
                _webHostEnvironmentMock.Object,
                _roleManagerMock.Object
            );
            // mocked 
            var tempData = new Mock<ITempDataDictionary>();
            _accountController.TempData = tempData.Object;

        }

        private Mock<UserManager<ApplicationUser>> MockUserManager()
        {
            return new Mock<UserManager<ApplicationUser>>(
                Mock.Of<IUserStore<ApplicationUser>>(),
                null, null, null, null, null, null, null, null
            );
        }

        private Mock<SignInManager<ApplicationUser>> MockSignInManager()
        {
            return new Mock<SignInManager<ApplicationUser>>(
                MockUserManager().Object,
                Mock.Of<IHttpContextAccessor>(),
                Mock.Of<IUserClaimsPrincipalFactory<ApplicationUser>>(),
                null, null, null, null
            );
        }

        private Mock<RoleManager<IdentityRole>> MockRoleManager()
        {
            return new Mock<RoleManager<IdentityRole>>(
                Mock.Of<IRoleStore<IdentityRole>>(),
                null, null, null, null
            );
        }

        // Test for a Successful Login Action
        [Fact] // Marks a method as a test method that takes no parameters. from Xunit
        public async Task Login_Post_ValidModel_RedirectsToHome()
        {
            // LoginViewModel with a specific email and password.
            var model = new LoginViewModel
            {
                Email = "admin@admin.com",
                Password = "AdminPassword123!",
                RememberMe = false
            };
            // set up the mock _signInManager to return SignInResult.Success when PasswordSignInAsync is called with the provided email, password, and remember-me flag.
            _signInManagerMock.Setup(sm => sm.PasswordSignInAsync(
                model.Email,
                model.Password,
                model.RememberMe,
                false
            )).ReturnsAsync(Microsoft.AspNetCore.Identity.SignInResult.Success);

            var result = await _accountController.Login(model);

            // check that the result of the Login method is a RedirectToActionResult.
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            // verify that this result redirects to the “Index” action of the “Home” controller.from Xunit
            Assert.Equal("Index", redirectResult.ActionName);
            Assert.Equal("Home", redirectResult.ControllerName);
        }

        // Test for a Failed Login Action
        [Fact]
        public async Task Login_Post_InvalidModel_ReturnsViewWithModel()
        {
            // Arrange
            var model = new LoginViewModel
            {
                Email = "test@example.com",
                Password = "wrongpassword",
                RememberMe = false
            };

            _signInManagerMock.Setup(sm => sm.PasswordSignInAsync(
                model.Email,
                model.Password,
                model.RememberMe,
                false
            )).ReturnsAsync(Microsoft.AspNetCore.Identity.SignInResult.Failed);

            // Act
            var result = await _accountController.Login(model);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal(model, viewResult.Model);
        }

        // Test for a Successful Logout Action
        [Fact]
        public async Task Logout_Post_User_RedirectsToHome()
        {
            var result = await _accountController.Logout();

            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectResult.ActionName);
            Assert.Equal("Home", redirectResult.ControllerName);

            _signInManagerMock.Verify(sm => sm.SignOutAsync(), Times.Once);
        }

        // Test for a Successful Register Action
        [Fact]
        public async Task Register_ValidModel_WhenRegistrationIsSuccessful()
        {
            var model = new RegisterViewModel
            {
                FirstName = "John",
                LastName = "Lock",
                Email = "newuser@example.com",
                Role = "Patient",
                DateOfBirth = DateTime.SpecifyKind(new DateTime(1980, 1, 1), DateTimeKind.Utc),
                Address = "123 Admin St, Admin City, Adminland",
                Gender = "Male",
                PhoneNumber = "+44123456789",
                EmmergencyContact = "0123456789",
                EmmergencyContactName = "Johhan Geothe"
            };

            _userManagerMock.Setup(m => m.CreateAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()))
                .ReturnsAsync(IdentityResult.Success);
            _userManagerMock.Setup(m => m.AddToRoleAsync(It.IsAny<ApplicationUser>(), model.Role))
                .ReturnsAsync(IdentityResult.Success);
            _signInManagerMock.Setup(m => m.SignInAsync(It.IsAny<ApplicationUser>(), false, null))
                .Returns(Task.CompletedTask);

            var result = await _accountController.Register(model);

            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectResult.ActionName);

            _userManagerMock.Verify(um => um.CreateAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()), Times.Once);
            _userManagerMock.Verify(um => um.AddToRoleAsync(It.IsAny<ApplicationUser>(), model.Role), Times.Once);
            _signInManagerMock.Verify(sm => sm.SignInAsync(It.IsAny<ApplicationUser>(), false, null), Times.Once);

            Assert.True(_accountController.ModelState.IsValid);
        }

        // Test for a Failed Register Action
        [Fact]
        public async Task Register_InValidModel_WhenRegistrationFails()
        {
            var model = new RegisterViewModel();

            _userManagerMock.Setup(m => m.CreateAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()))
                .ReturnsAsync(IdentityResult.Failed(new IdentityError { Description = "User creation failed." }));
            _userManagerMock.Setup(m => m.AddToRoleAsync(It.IsAny<ApplicationUser>(), model.Role))
                .ReturnsAsync(IdentityResult.Failed(new IdentityError { Description = "Role assignment failed." }));
            _signInManagerMock.Setup(m => m.SignInAsync(It.IsAny<ApplicationUser>(), false, null))
                .Returns(Task.FromException(new Exception("Sign in failed.")));

            var result = await _accountController.Register(model);

            _userManagerMock.Verify(um => um.CreateAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()), Times.Once);
            _userManagerMock.Verify(um => um.AddToRoleAsync(It.IsAny<ApplicationUser>(), model.Role), Times.Once);
            _signInManagerMock.Verify(sm => sm.SignInAsync(It.IsAny<ApplicationUser>(), false, null), Times.Never);

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal(model, viewResult.Model);
            Assert.True(_accountController.ModelState.ContainsKey(""));
            Assert.Contains("User creation failed.", _accountController.ModelState[""].Errors[0].ErrorMessage);

        }
    }
}