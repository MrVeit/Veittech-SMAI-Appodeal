using AppodealStack.Monetization.Api;
using AppodealStack.Monetization.Common;
using Veittech.Modules.Ad.SMAI_Appodeal.Common;

namespace Veittech.Modules.Ad.SMAI_Appodeal
{
    public sealed class ClassicBannerAdAdapter : BannerAdAdapter
    {
        private const int AD_TYPE = AppodealAdType.Banner;

        private readonly int _position;

        public ClassicBannerAdAdapter(int position)
        {
            _position = position;
        }

        public sealed override void Show(string placement)
        {
            var adLoader = new AdLoader(AD_TYPE, placement);

            if (adLoader.IsReadyBanner())
            {
                Appodeal.Show(_position, placement);
            }
        }

        public sealed override void Hide()
        {
            Appodeal.Hide(AD_TYPE);
        }

        public sealed override void Destroy()
        {
            Appodeal.Destroy(AD_TYPE);
        }
    }
}