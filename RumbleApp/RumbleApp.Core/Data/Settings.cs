using System;
using Refractored.Xam.Settings.Abstractions;
using Refractored.Xam.Settings;

namespace RumbleApp.Core
{
	public static class Settings
	{
		private static ISettings AppSettings
		{
			get
			{
				return CrossSettings.Current;
			}
		}


        private const string IsFirstRunKey = "is_first_run";
        private static readonly bool IsFirstRunDefault = true;

        private const string UserNameKey = "user_name";
        private static readonly string UserNameDefault = string.Empty;

        private const string PasswordKey = "password";
        private static readonly string PasswordDefault = string.Empty;

        private const string ExpiresKey = "expires";
        private static readonly string ExpiresDefault = string.Empty;

        private const string TokenKey = "token";
        private static readonly string TokenDefault = string.Empty;


        public static string Token
        {
            get { return AppSettings.GetValueOrDefault<string>(TokenKey, TokenDefault); }
            set { AppSettings.AddOrUpdateValue<string>(TokenKey, value); }
        }

        public static string UserName
        {
            get { return AppSettings.GetValueOrDefault<string>(UserNameKey, UserNameDefault); }
            set { AppSettings.AddOrUpdateValue<string>(UserNameKey, value); }
        }

        public static string Password
        {
            get { return AppSettings.GetValueOrDefault<string>(PasswordKey, PasswordDefault); }
            set { AppSettings.AddOrUpdateValue<string>(PasswordKey, value); }
        }
        public static string Expires
        {
            get { return AppSettings.GetValueOrDefault<string>(ExpiresKey, ExpiresDefault); }
            set { AppSettings.AddOrUpdateValue<string>(ExpiresKey, value); }
        }

        public static bool IsFirstRun
        {
            get { return AppSettings.GetValueOrDefault<bool>(IsFirstRunKey, IsFirstRunDefault); }
            set { AppSettings.AddOrUpdateValue<bool>(IsFirstRunKey, value); }
        }
    }
}

