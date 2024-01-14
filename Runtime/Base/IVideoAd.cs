namespace Veittech.Modules.Ad.SMAI_Appodeal.Common
{
    public interface IVideoAd
    {
        void Show();

        void Show(string placement);

        void Cache();
    }
}