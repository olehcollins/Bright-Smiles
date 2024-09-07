using System;
using System.Text;

namespace DentistAppointmentSystem.Utilities
{
    public class PasswordGenerator
    {
        private static readonly char[] _upperCaseChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        private static readonly char[] _lowerCaseChars = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
        private static readonly char[] _digits = "0123456789".ToCharArray();
        private static readonly char[] _specialChars = "!@#$%^&*()".ToCharArray();

        public static string GeneratePassword(string firstName, string lastName)
        {

            var random = new Random();
            var password = new StringBuilder();

            // Ensure names are at least 2 characters long
            string firstPart = firstName.Length >= 2 ? firstName.Substring(0, 2) : firstName;
            string lastPart = lastName.Length >= 2 ? lastName.Substring(0, 2) : lastName;

            // append first 2 characters of the firstname and lastname
            password.Append(firstPart);
            password.Append(lastPart);

            // Ensure the password contains at least one character from each required set
            password.Append(_upperCaseChars[random.Next(_upperCaseChars.Length)]);
            password.Append(_lowerCaseChars[random.Next(_lowerCaseChars.Length)]);
            password.Append(_digits[random.Next(_digits.Length)]);
            password.Append(_specialChars[random.Next(_specialChars.Length)]);

            // Shuffle the characters to ensure the password is random
            return password.ToString();
        }
    }
}