using System;
using AppodealStack.Monetization.Common;
using Veittech.Modules.Ad.SMAI_Appodeal.Common;

namespace Veittech.Modules.Ad.SMAI_Appodeal
{
    public sealed class RewardedAdAdapter : VideoAdAdapter, IVideoAdWithReward
    {
        private const int AD_TYPE = AppodealAdType.RewardedVideo;
        private const int AD_SHOW_STYLE = AppodealShowStyle.RewardedVideo;

        private Action _rewardCallback;

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

            SetRewardCallback(rewardCallback);
        }

        public void Show(Action rewardCallback)
        {
            Show();

            SetRewardCallback(rewardCallback);
        }

        private void SetRewardCallback(Action rewardCallback)
        {
            _rewardCallback = rewardCallback;

            AppodealCallbacks.RewardedVideo.OnFinished += GiveRewardAfterWatch;
        }

        private void GiveRewardAfterWatch(object sender, RewardedVideoFinishedEventArgs serverReward)
        {
            _rewardCallback?.Invoke();

            AppodealCallbacks.RewardedVideo.OnFinished -= GiveRewardAfterWatch;
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