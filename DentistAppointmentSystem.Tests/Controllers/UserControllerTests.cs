using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Collections.Generic;
using DentistAppointmentSystem.Controllers;
using DentistAppointmentSystem.Models;
using DentistAppointmentSystem.ViewModels;

namespace DentistAppointmentSystem.Tests.Controllers
{
    public class UserControllerTests
    {
        private readonly Mock<UserManager<ApplicationUser>> _userManagerMock;
        private readonly Mock<RoleManager<IdentityRole>> _roleManagerMock;
        private readonly UserController _userController;

        public UserControllerTests()
        {
            _userManagerMock = MockUserManager();
            _roleManagerMock = MockRoleManager();

            _userController = new UserController(
                _userManagerMock.Object,
                _roleManagerMock.Object
            );
        }

        private Mock<UserManager<ApplicationUser>> MockUserManager()
        {
            return new Mock<UserManager<ApplicationUser>>(
                Mock.Of<IUserStore<ApplicationUser>>(),
                null, null, null, null, null, null, null, null
            );
        }

        private Mock<RoleManager<IdentityRole>> MockRoleManager()
        {
            return new Mock<RoleManager<IdentityRole>>(
                Mock.Of<IRoleStore<IdentityRole>>(),
                null, null, null, null
            );
        }

        [Theory]
        [InlineData("validId")]
        public async Task GetProfile_With_ValidUserId_Returns_ViewResult(string id)
        {
            // Arrange
            var mockUser = new ApplicationUser { Id = id };
            _userManagerMock.Setup(um => um.FindByIdAsync(id)).ReturnsAsync(mockUser);
            _userManagerMock.Setup(um => um.GetRolesAsync(mockUser)).ReturnsAsync(new List<string> { "Dentist" });

            // Act
            var result = await _userController.Profile(id);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<UserViewModel>(viewResult.Model);
            Assert.Equal(mockUser, model.User);
            Assert.Equal("Dentist", model.Role);
        }
    }
}