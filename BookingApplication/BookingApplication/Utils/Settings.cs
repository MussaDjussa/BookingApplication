using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace BookingApplication.Helpers
{
    /// <summary>
    /// This is the Settings static class that can be used in your Core solution or in any
    /// of your client applications. All settings are laid out the same exact way with getters
    /// and setters. 
    /// </summary>
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        #region Setting Constants

        private const string LastUserEmailKey = "last_email_key";

        private const string LastUserPasswordKey = "last_password_key";
        private static readonly string SettingsDefault = string.Empty;

        private const string PreviewState = "preview_state_key";

        #endregion

        public static string LastPreviewState
        {
            get
            {

                return AppSettings.GetValueOrDefault(PreviewState, SettingsDefault);
            }
            set
            {
                
                AppSettings.AddOrUpdateValue(PreviewState, value);
            }
        }
        public static string LastUserEmail
        {
            get
            {
                return AppSettings.GetValueOrDefault(LastUserEmailKey, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(LastUserEmailKey, value);
            }
        }

        public static string LastUserPassword
        {
            get
            {
                return AppSettings.GetValueOrDefault(LastUserPasswordKey, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(LastUserPasswordKey, value);
            }
        }

    }
}
