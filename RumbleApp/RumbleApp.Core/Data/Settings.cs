using System;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace JamnationApp.Core
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
            get { return AppSettings.GetValueOrDefault(TokenKey, TokenDefault); }
            set { AppSettings.AddOrUpdateValue(TokenKey, value); }
        }

        public static string UserName
        {
            get { return AppSettings.GetValueOrDefault(UserNameKey, UserNameDefault); }
            set { AppSettings.AddOrUpdateValue(UserNameKey, value); }
        }

        public static string Password
        {
            get { return AppSettings.GetValueOrDefault(PasswordKey, PasswordDefault); }
            set { AppSettings.AddOrUpdateValue(PasswordKey, value); }
        }
        public static string Expires
        {
            get { return AppSettings.GetValueOrDefault(ExpiresKey, ExpiresDefault); }
            set { AppSettings.AddOrUpdateValue(ExpiresKey, value); }
        }

        public static bool IsFirstRun
        {
            get { return AppSettings.GetValueOrDefault(IsFirstRunKey, IsFirstRunDefault); }
            set { AppSettings.AddOrUpdateValue(IsFirstRunKey, value); }
        }
    }
}

