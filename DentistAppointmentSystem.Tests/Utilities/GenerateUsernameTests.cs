using DentistAppointmentSystem.Utilities;
using System.Text;
using System;
using Xunit;

namespace DentistAppointmentSystem.Tests.Utilities
{
    public class UsernameGeneratorTests
    {

        [Fact]
        public void GenerateUsername_Successful()
        {
            string firstName = "John";
            string lastName = "Doe";

            var generatedUsername = UsernameGenerator.GenerateUsername(firstName, lastName);

            string pattern = @"^(?=.*\d{2})(?=.*[!@#$%^&*()]).*$";
            Assert.NotNull(generatedUsername);
            Assert.Contains(firstName, generatedUsername);
            Assert.Matches(pattern, generatedUsername);
        }
    }
}