using System;
using System.Text.RegularExpressions;

namespace RumbleApp.Core.Helpers
{
	public class Validation
	{

		public static bool IsValidEmail(string email)
		{
			return Regex.IsMatch(email, @"^(.*)*@(.*)$");
		}

	    public static bool IsValidCarReg(string reg)
	    {
	        return !String.IsNullOrWhiteSpace(reg) && Regex.IsMatch(reg, @"^[a-zA-Z0-9 ]*$");
	    }

	    public static bool IsValidTelNumber(string tel)
	    {
	        return Regex.IsMatch(tel, @"^\d+$");
	    }

	}
}

