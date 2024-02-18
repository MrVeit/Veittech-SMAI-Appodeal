using AppodealStack.Monetization.Common;
using System;
using Veittech.Modules.Ad.SMAI_Appodeal.Common;

namespace Veittech.Modules.Ad.SMAI_Appodeal
{
    public sealed class RewardedAdAdapter : VideoAdAdapter, IVideoAdWithReward
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

        public void Show(string placement, Action rewardCallback)
        {
            Show(placement, AD_TYPE, AD_SHOW_STYLE);

            GiveRewardAfterWatch(rewardCallback);
        }

        public void Show(Action rewardCallback)
        {
            Show();

            GiveRewardAfterWatch(rewardCallback);
        }

        private void GiveRewardAfterWatch(Action rewardCallback)
        {
            AppodealCallbacks.RewardedVideo.OnFinished += (sender, serverReward) =>
            {
                rewardCallback?.Invoke();
            };
        }
    }
}