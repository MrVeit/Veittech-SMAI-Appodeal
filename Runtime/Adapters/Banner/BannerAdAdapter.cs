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
    }
}