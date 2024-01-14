using UnityEngine;
using NUnit.Framework;

namespace Veittech.Modules.Ad.SMAI_Appodeal.Tests.Dummies
{
    public static class DummyUtils
    {
        public static bool CheckKeyForNullOrEmpty(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return true;
            }

            return false;
        }

        public static RuntimePlatform GetCurrentPlatfrom()
        {
            return Application.platform;
        }

        public static void LogErrorAfterCheckKey(RuntimePlatform targetPlatform, string appKey, string errorMessage)
        {
            if (CheckKeyForNullOrEmpty(appKey))
            {
                Assert.IsEmpty(errorMessage);

                Debug.Log(errorMessage);
            }
        }

        public static string GetErrorMessage(RuntimePlatform platformName, string applicationStore)
        {
            return $"The {platformName} application key for {applicationStore} must not be null, otherwise the application may crash after installation.";
        }
    }
}