using System;

namespace Veittech.Modules.Ad.SMAI_Appodeal.Common
{
    public interface IVideoAdWithReward : IVideoAd
    {
        void Show(string placement, Action rewardCallback);

        void Show(Action rewardCallback);
    }
}