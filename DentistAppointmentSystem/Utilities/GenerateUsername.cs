using System;
using System.Text;

namespace DentistAppointmentSystem.Utilities
{
    public class UsernameGenerator
    {
        private static readonly char[] _specialChars = "!@#$%^&*()".ToCharArray();

        public static string GenerateUsername(string firstName, string lastName)
        {

            var random = new Random();
            var username = new StringBuilder();

            // Ensure names are at least 2 characters long
            string firstPart = firstName.Length >= 2 ? firstName.Substring(0, 2) : firstName;
            string lastPart = lastName.Length >= 2 ? lastName.Substring(0, 2).ToUpper() : lastName.ToUpper();

            // append first 2 characters of the firstname and lastname
            username.Append(firstName);
            username.Append(lastPart);

            // Ensure the username contains at least one character from each required set
            username.Append(random.Next(10, 100).ToString());
            username.Append(_specialChars[random.Next(_specialChars.Length)]);

            // Shuffle the characters to ensure the username is random
            return username.ToString();
        }
    }
}