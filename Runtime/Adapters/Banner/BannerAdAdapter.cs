using AppodealStack.Monetization.Api;
using Veittech.Modules.Ad.SMAI_Appodeal.Common;

namespace Veittech.Modules.Ad.SMAI_Appodeal
{
    public abstract class BannerAdAdapter : IBannerAd
    {
        public void Show()
        {
            Show(AdPlacements.DEFAULT);
        }

        public abstract void Show(string placement);

        public abstract void Destroy();

        public abstract void Hide();

        public abstract void Cache();

        protected void Cache(int adType)
        {
            if (!Appodeal.IsAutoCacheEnabled(adType))
            {
                Appodeal.Cache(adType);
            }
        }

        public abstract bool IsLoaded();

        protected bool IsLoaded(int adType, string placement)
        {
            var adLoader = new AdLoader(adType, placement);

            if (adLoader.IsReadyBanner())
            {
                return true;
            }

            return false;
        }

        public abstract double GetPredictedEcpm();

        public abstract double GetPredictedEcpm(string placement);

        protected double GetPredictedEcpm(int adType, string placement)
        {
            return Appodeal.GetPredictedEcpmForPlacement(adType, placement);
        }
    }
}