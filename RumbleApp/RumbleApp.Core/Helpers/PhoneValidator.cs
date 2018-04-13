using System.Text.RegularExpressions;

namespace JamnationApp.Core.Helpers
{
    public class PhoneValidator
    {
        public static bool PhoneIsValid(string phoneNumber)
        {
            Match match = Regex.Match(phoneNumber, @"^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$");

            if (match.Success)
                return true;
            return false;
        }
    }
}
