using UnityEngine;
using NUnit.Framework;
using Veittech.Modules.Ad.SMAI_Appodeal.Tests.Dummies;
using Veittech.Modules.Ad.SMAI_Appodeal.Editor.SettingsWindow;

namespace Veittech.Modules.Ad.SMAI_Appodeal.Tests
{
    public sealed class AppodealAppKeyInitializationTest
    {
        [Test]
        public void CheckAppKey()
        {
#if UNITY_ANDROID
            DummyUtils.LogErrorAfterCheckKey(RuntimePlatform.Android,
                 SMAISettings.Instance.AndroidAppKey, DummyUtils.GetErrorMessage(RuntimePlatform.Android, "Google Play"));

            DummyUtils.LogErrorAfterCheckKey(RuntimePlatform.Android,
                 SMAISettings.Instance.AmazonAndroidAppKey, DummyUtils.GetErrorMessage(RuntimePlatform.Android, "Amazon Store"));
#elif UNITY_IOS
             DummyUtils.LogErrorAfterCheckKey(RuntimePlatform.IPhonePlayer,
                 SMAISettings.Instance.IOSAppKey, GetErrorMessage(RuntimePlatform.IPhonePlayer, "App Store"));
#endif
        }
    }
}