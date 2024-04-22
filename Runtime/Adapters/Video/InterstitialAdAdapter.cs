using AppodealStack.Monetization.Common;
using Veittech.Modules.Ad.SMAI_Appodeal.Common;

namespace Veittech.Modules.Ad.SMAI_Appodeal
{
    public sealed class InterstitialAdAdapter : VideoAdAdapter
    {
        private const int AD_TYPE = AppodealAdType.Interstitial;
        private const int AD_SHOW_STYLE = AppodealShowStyle.Interstitial;

        public sealed override void Show(string placement)
        {
            Show(placement, AD_TYPE, AD_SHOW_STYLE);
        }

        public sealed override void Cache()
        {
            Cache(AD_TYPE);
        }

        public sealed override bool IsLoaded()
        {
            return IsLoaded(AD_TYPE, AdPlacements.DEFAULT);
        }

        public sealed override double GetPredictedEcpm()
        {
            return GetPredictedEcpm(AD_TYPE, AdPlacements.DEFAULT);
        }

        public sealed override double GetPredictedEcpm(string placemen)
        {
            return GetPredictedEcpm(AD_TYPE, placemen);
        }
    }
}