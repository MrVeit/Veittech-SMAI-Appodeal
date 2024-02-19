namespace Veittech.Modules.Ad.SMAI_Appodeal.Common
{
    public sealed class AdInitializationKeys
    {
        private readonly AppKeysProxy _appKeysProxy;

        public AdInitializationKeys()
        {
            _appKeysProxy = new AppKeysProxy();
        }

        public string GetAndroidKey()
        {
            return _appKeysProxy.GetAndroidKey();
        }

        public string GetAmazonKey()
        {
            return _appKeysProxy.GetAmazonKey();
        }

        public string GetIosKey()
        {
            return _appKeysProxy.GetIOSKey();
        }
    }
}