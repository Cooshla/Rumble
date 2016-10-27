using System;
using Refractored.Xam.Settings.Abstractions;
using Refractored.Xam.Settings;

namespace BlankXamarinApp.Core
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

		private const string IsFirstRun_Key = "IsFirstRun_key";
		private static readonly bool IsFirstRunDefault = true;


		private const string IsPersonalized_Key = "IsPersonalized_Key";
		private static readonly bool IsPersonalizedDefault = false;

		private const string IsSkipLogin_Key = "IsSkipLogin_Key";
		private static readonly bool IsSkipLogindDefault = false;



		private const string NumberAdults_Key = "NumberAdults_Key";
		private static readonly int NumberAdultsDefault = 0;

		private const string NumberChildren_Key = "NumberChildren_Key";
		private static readonly int NumberChildrenDefault = 0;

		private const string Outfit_Key = "Outfit_Key";
		private static readonly string OutfitDefault = string.Empty;



		private const string Token_Key = "Token_Key";
		private static readonly string TokenDefault = string.Empty;

		private const string Password_Key = "Password_Key";
		private static readonly string PasswordDefault = string.Empty;

		private const string Username_Key = "Username_Key";
		private static readonly string UsernameDefault = string.Empty;

		private const string MembershipNumber_Key = "MembershipNumber_Key";
		private static readonly string MembershipNumberDefault = string.Empty;


		private const string IsPaidMember_Key = "IsPaidMember_key";
		private static readonly bool IsPaidMemberDefault = false;

		private const string SendNotifications_Key = "SendNotifications_Key";
		private static readonly bool SendNotificationsDefault = false;

		private const string DataDownloaded_Key = "DataDownloaded_Key";
        private static readonly bool DataDownloadedDefault = false;

	    public const string LastSiteCatUpdateCheck_Key = "LastSiteCatUpdateCheck_Key";
        private static readonly DateTime LastSiteCatUpdateCheckDefault = DateTime.MinValue;

        public static DateTime LastRefresh
        {
            get { return AppSettings.GetValueOrDefault<DateTime>(LastSiteCatUpdateCheck_Key, LastSiteCatUpdateCheckDefault); }
            set { AppSettings.AddOrUpdateValue<DateTime>(LastSiteCatUpdateCheck_Key, value); }
        }

        public static bool IsDataDownloaded
        {
            get { return AppSettings.GetValueOrDefault<bool>(DataDownloaded_Key, DataDownloadedDefault); }
            set { AppSettings.AddOrUpdateValue<bool>(DataDownloaded_Key, value); }
        }

		public static bool IsFirstRun
		{
			get { return AppSettings.GetValueOrDefault<bool>(IsFirstRun_Key, IsFirstRunDefault); }
			set { AppSettings.AddOrUpdateValue<bool>(IsFirstRun_Key, value); }
		}

		public static bool IsPersonalized
		{
			get { return AppSettings.GetValueOrDefault<bool>(IsPersonalized_Key, IsPersonalizedDefault); }
			set { AppSettings.AddOrUpdateValue<bool>(IsPersonalized_Key, value); }
		}

		public static bool IsSkipLogin
		{
			get { return AppSettings.GetValueOrDefault<bool>(IsSkipLogin_Key, IsSkipLogindDefault); }
			set { AppSettings.AddOrUpdateValue<bool>(IsSkipLogin_Key, value); }
		}

		public static bool SendNotifications
		{
			get { return AppSettings.GetValueOrDefault<bool>(SendNotifications_Key, SendNotificationsDefault); }
			set { AppSettings.AddOrUpdateValue<bool>(SendNotifications_Key, value); }
		}

		public static int NumberAdults
		{
			get { return AppSettings.GetValueOrDefault<int>(NumberAdults_Key, NumberAdultsDefault); }
			set { AppSettings.AddOrUpdateValue<int>(NumberAdults_Key, value); }
		}

		public static int NumberChildren
		{
			get { return AppSettings.GetValueOrDefault<int>(NumberChildren_Key, NumberChildrenDefault); }
			set { AppSettings.AddOrUpdateValue<int>(NumberChildren_Key, value); }
		}

		public static string Outfit
		{
			get { return AppSettings.GetValueOrDefault<string>(Outfit_Key, OutfitDefault); }
			set { AppSettings.AddOrUpdateValue<string>(Outfit_Key, value); }
		}

		public static string Username
		{
			get { return AppSettings.GetValueOrDefault<string>(Username_Key, UsernameDefault); }
			set { AppSettings.AddOrUpdateValue<string>(Username_Key, value); }
		}

		public static string Password
		{
			get { return AppSettings.GetValueOrDefault<string>(Password_Key, PasswordDefault); }
			set { AppSettings.AddOrUpdateValue<string>(Password_Key, value); }
		}

		public static string AccessToken
		{
			get { return AppSettings.GetValueOrDefault<string>(Token_Key, TokenDefault); }
			set { AppSettings.AddOrUpdateValue<string>(Token_Key, value); }
		}

		public static string MembershipNumber
		{
			get { return AppSettings.GetValueOrDefault<string>(MembershipNumber_Key, MembershipNumberDefault); }
			set { AppSettings.AddOrUpdateValue<string>(MembershipNumber_Key, value); }
		}

		public static bool IsPaidMember
		{
			get { return AppSettings.GetValueOrDefault<bool>(IsPaidMember_Key, IsPaidMemberDefault); }
			set { AppSettings.AddOrUpdateValue<bool>(IsPaidMember_Key, value); }
		}


	}
}

