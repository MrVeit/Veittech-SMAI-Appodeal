using AppodealStack.Monetization.Api;
using Veittech.Modules.Ad.SMAI_Appodeal.Common;

namespace Veittech.Modules.Ad.SMAI_Appodeal
{
    public abstract class VideoAdAdapter : IVideoAd
    {
        public void Show()
        {
            Show(AdPlacements.DEFAULT);
        }

        public abstract void Show(string placement);

        protected void Show(string placement, int adType, int showStyle)
        {
            if (placement == null)
            {
                placement = AdPlacements.DEFAULT;
            }

            if (!IsLoaded())
            {
                return;
            }

            Appodeal.Show(showStyle, placement);
        }

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

            if (adLoader.IsReadyAd())
            {
                return true;
            }

            return false;
        }

        public abstract double GetPredictedEcpm();

        public abstract double GetPredictedEcpm(string placemen);

        protected double GetPredictedEcpm(int adType, string placement)
        {
            return Appodeal.GetPredictedEcpmForPlacement(adType, placement);
        }
    }
}