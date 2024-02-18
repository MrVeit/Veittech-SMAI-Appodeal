using Veittech.Modules.Ad.SMAI_Appodeal.Editor.SettingsWindow;

namespace Veittech.Modules.Ad.SMAI_Appodeal.Common
{
    public static class AdInitializationKeys
    {
        public sealed class AppodealKeys
        {
            public readonly string ANDROID_KEY = SMAISettings.Instance.AndroidAppKey;
            public readonly string AMAZON_KEY = SMAISettings.Instance.AmazonAndroidAppKey;
            public readonly string IOS_KEY = SMAISettings.Instance.IOSAppKey;
        }
    }
}