using UnityEngine;

namespace Veittech.Modules.Ad.SMAI_Appodeal.Common
{
    public sealed class AppKeysProxy
    {
        public readonly AppKeysStorage AppKeysData;

        public AppKeysProxy()
        {
            AppKeysData = Resources.Load<AppKeysStorage>(AppKeysStorage.FILE_NAME);
        }

        public string GetAndroidKey()
        {
            return AppKeysData.AndroidAppKey;
        }

        public string GetAmazonKey()
        {
            return AppKeysData.AmazonAppKey;
        }

        public string GetIOSKey()
        {
            return AppKeysData.IosAppKey;
        }
    }
}