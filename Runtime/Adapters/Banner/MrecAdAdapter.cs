using AppodealStack.Monetization.Api;

namespace Veittech.Modules.Ad.SMAI_Appodeal
{
    public sealed class MrecAdAdapter : BannerAdAdapter
    {
        private readonly int _horizontalPosition;
        private readonly int _verticalPosition;

        public MrecAdAdapter(int horizontalPosition, int verticalPosition)
        {
            _horizontalPosition = horizontalPosition;
            _verticalPosition = verticalPosition;
        }

        public sealed override void Show(string placement)
        {
            Appodeal.ShowMrecView(_verticalPosition, _horizontalPosition, placement);
        }

        public sealed override void Hide()
        {
            Appodeal.HideMrecView();
        }

        public sealed override void Destroy()
        {
            Hide();
        }
    }
}