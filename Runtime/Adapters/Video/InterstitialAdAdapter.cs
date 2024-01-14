using AppodealStack.Monetization.Common;

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
    }
}