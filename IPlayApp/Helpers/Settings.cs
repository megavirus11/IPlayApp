// Helpers/Settings.cs
using Refractored.Xam.Settings;
using Refractored.Xam.Settings.Abstractions;

namespace IPlayApp.Helpers
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


        private const string Url = "url";
        private static readonly string UrlDefault = string.Empty;

        private const string Segment = "segment";
        private static readonly string SegmentDefault = string.Empty;

        private const string DeviceId = "deviceid";
        private static readonly string DeviceIdDefault = string.Empty;

        private const string UserId = "userid";
        private static readonly string UserIdDefault = string.Empty;

        #endregion


        public static string UrlSettings
        {
            get
            {
                return AppSettings.GetValueOrDefault(Url, UrlDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(Url, value);
            }
        }

        public static string SegmentSettings
        {
            get
            {
                return AppSettings.GetValueOrDefault(Segment, SegmentDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(Segment, value);
            }
        }

        public static string DeviceSettings
        {
            get
            {
                return AppSettings.GetValueOrDefault(DeviceId, DeviceIdDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(DeviceId, value);
            }
        }

        public static string UserIdSettings
        {
            get
            {
                return AppSettings.GetValueOrDefault(UserId, UserIdDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(UserId, value);
            }
        }

    }
}