using System;

namespace Veittech.Modules.Ad.SMAI_Appodeal.Common
{
    public interface IVideoAdWithReward
    {
        void Show(string placement, Action rewardCallback);

        void Show(Action rewardCallback);
    }
}