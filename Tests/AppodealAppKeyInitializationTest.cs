using UnityEngine;
using NUnit.Framework;
using Veittech.Modules.Ad.SMAI_Appodeal.Common;
using Veittech.Modules.Ad.SMAI_Appodeal.Tests.Dummies;

namespace Veittech.Modules.Ad.SMAI_Appodeal.Tests
{
    public class AppodealAppKeyInitializationTest
    {
        [Test]
        public void CheckAppKey()
        {
#if UNITY_ANDROID
            DummyUtils.LogErrorAfterCheckKey(RuntimePlatform.Android,
                AdInitializationKeys.AppodealKeys.ANDROID_KEY, DummyUtils.GetErrorMessage(RuntimePlatform.Android, "Google Play"));

            DummyUtils.LogErrorAfterCheckKey(RuntimePlatform.Android,
                AdInitializationKeys.AppodealKeys.AMAZON_KEY, DummyUtils.GetErrorMessage(RuntimePlatform.Android, "Amazon Store"));
#elif UNITY_IOS
             DummyUtils.LogErrorAfterCheckKey(RuntimePlatform.IPhonePlayer,
                AdInitializationKeys.AppodealKeys.IOS_KEY, GetErrorMessage(RuntimePlatform.IPhonePlayer, "App Store"));
#endif
        }
    }
}