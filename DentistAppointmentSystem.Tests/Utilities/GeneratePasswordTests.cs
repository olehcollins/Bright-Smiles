using DentistAppointmentSystem.Utilities;
using System.Text;
using System;
using Xunit;

namespace DentistAppointmentSystem.Tests.Utilities
{
    public class PasswordGeneratorTests
    {

        [Fact]
        public void GeneratePassword_Successful()
        {
            string firstName = "John";
            string lastName = "Doe";

            var generatedPassword = PasswordGenerator.GeneratePassword(firstName, lastName);


            Assert.NotNull(generatedPassword);
            Assert.Equal(8, generatedPassword.Length);
        }
    }
}