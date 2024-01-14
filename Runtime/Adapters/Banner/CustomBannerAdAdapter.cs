using AppodealStack.Monetization.Api;

namespace Veittech.Modules.Ad.SMAI_Appodeal
{
    public sealed class CustomBannerAdAdapter : BannerAdAdapter
    {
        private readonly int _horizontalPosition;
        private readonly int _verticalPosition;

        public CustomBannerAdAdapter(int horizontalPosition, int verticalPosition)
        {
            _horizontalPosition = horizontalPosition;
            _verticalPosition = verticalPosition;
        }

        public sealed override void Show(string placement)
        {
            Appodeal.ShowBannerView(_verticalPosition, _horizontalPosition, placement);
        }

        public sealed override void Hide()
        {
            Appodeal.HideBannerView();
        }

        public sealed override void Destroy()
        {
            Hide();
        }
    }
}