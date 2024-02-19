using UnityEngine;
using NUnit.Framework;
using Veittech.Modules.Ad.SMAI_Appodeal.Common;
using Veittech.Modules.Ad.SMAI_Appodeal.Tests.Dummies;

namespace Veittech.Modules.Ad.SMAI_Appodeal.Tests
{
    public sealed class AppodealAppKeyInitializationTest
    {
        [Test]
        public void CheckAppKey()
        {
            var keysStorage = new AdInitializationKeys();

            var androidKey = keysStorage.GetAndroidKey();
            var amazonKey = keysStorage.GetAmazonKey();
            var iosKey = keysStorage.GetIosKey();

#if UNITY_ANDROID
            DummyUtils.LogErrorAfterCheckKey(RuntimePlatform.Android,
                 androidKey, DummyUtils.GetErrorMessage(RuntimePlatform.Android, "Google Play"));

            DummyUtils.LogErrorAfterCheckKey(RuntimePlatform.Android,
                 amazonKey, DummyUtils.GetErrorMessage(RuntimePlatform.Android, "Amazon Store"));
#elif UNITY_IOS
             DummyUtils.LogErrorAfterCheckKey(RuntimePlatform.IPhonePlayer,
                 iosKey, GetErrorMessage(RuntimePlatform.IPhonePlayer, "App Store"));
#endif
        }
    }
}