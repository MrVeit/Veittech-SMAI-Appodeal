using AppodealStack.Monetization.Api;

namespace Veittech.Modules.Ad.SMAI_Appodeal
{
    public sealed class AdLoader
    {
        public int Type { get; private set; }
        public string Placement { get; private set; }

        public AdLoader(int adType, string placement)
        {
            Type = adType;
            Placement = placement;
        }

        public bool IsReadyAd()
        {
            if (Appodeal.IsLoaded(Type) &&
                Appodeal.CanShow(Type, Placement)
                && !Appodeal.IsPrecache(Type))
            {
                return true;
            }

            return false;
        }

        public bool IsReadyBanner()
        {
            if (Appodeal.IsLoaded(Type) &&
                Appodeal.CanShow(Type, Placement))
            {
                return true;
            }

            return false;
        }
    }
}