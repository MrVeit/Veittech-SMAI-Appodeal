using AppodealStack.Monetization.Api;
using AppodealStack.Monetization.Common;
using Veittech.Modules.Ad.SMAI_Appodeal.Common;

namespace Veittech.Modules.Ad.SMAI_Appodeal
{
    public sealed class MrecAdAdapter : BannerAdAdapter
    {
        private const int AD_TYPE = AppodealAdType.Mrec;

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