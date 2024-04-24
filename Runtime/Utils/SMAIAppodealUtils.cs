using AppodealStack.Monetization.Api;
using AppodealStack.Monetization.Common;
using Veittech.Modules.Ad.SMAI_Appodeal.Common;

namespace Veittech.Modules.Ad.SMAI_Appodeal.Utils
{
    public static class SMAIAppodealUtils
    {
        public sealed class AdTools
        {
            public static void DisableNetworks(string[] networksNames)
            {
                foreach (var network in networksNames)
                {
                    DisableNetwork(network);
                }
            }

            public static void DisableNetwork(string networkName)
            {
                Appodeal.DisableNetwork(networkName);
            }

            public static void DisableNetwork(AppodealAdNetworks network)
            {
                DisableNetwork(network.ToString());
            }

            public static void DisableNetworks(AppodealAdNetworks[] networks)
            {
                foreach(var network in networks)
                {
                    DisableNetwork(network);
                }
            }

            public static void ShowDebugTestAd()
            {
                Appodeal.ShowTestScreen();
            }

            public static bool IsInitialized(SdkInitializedEventArgs initArgs)
            {
                if (initArgs.Errors == null)
                {
                    return true;
                }

                return false;
            }
        }
    }
}