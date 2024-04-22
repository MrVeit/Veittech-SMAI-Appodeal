namespace Veittech.Modules.Ad.SMAI_Appodeal.Common
{
    public interface IBannerAd
    {
        void Show();
        void Show(string placement);

        void Destroy();

        void Hide();

        void Cache();

        bool IsLoaded();

        double GetPredictedEcpm();
        double GetPredictedEcpm(string placement);
    }
}