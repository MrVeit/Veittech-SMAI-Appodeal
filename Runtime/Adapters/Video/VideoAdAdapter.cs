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

            var adLoader = new AdLoader(adType, placement);

            if (!adLoader.IsReadyAd())
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
    }
}