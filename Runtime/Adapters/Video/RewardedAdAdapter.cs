using AppodealStack.Monetization.Common;

namespace Veittech.Modules.Ad.SMAI_Appodeal
{
    public sealed class RewardedAdAdapter : VideoAdAdapter
    {
        private const int AD_TYPE = AppodealAdType.RewardedVideo;
        private const int AD_SHOW_STYLE = AppodealShowStyle.RewardedVideo;

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