using AppodealStack.Monetization.Api;
using AppodealStack.Monetization.Common;

namespace Veittech.Modules.Ad.SMAI_Appodeal.Common
{
    public sealed class AdConfigAdapter
    {
        public string AndroidAppKey { get; private set; }
        public string IOSAppKey { get; private set; }
        public int AdTypes { get; private set; }

        public bool IsTestMode { get; private set; }
        public bool SafeArea { get; private set; }
        public bool MuteVideoAd {get; private set; }
        public bool AutoCacheInterstitialAd { get; private set; }
        public bool AutoCacheRewardedAd { get; private set; }
        public bool ChildDirectedTreatment { get; private set; }

        public bool BannerAnimation { get; private set; }
        public bool SmartBanners { get; private set; }
        public bool TabletBanner { get; private set; }

        private AdConfigAdapter(Builder builder)
        {
            this.AndroidAppKey = builder.AndroidAppKey;
            this.IOSAppKey = builder.IOSAppKey;
            this.AdTypes = builder.AdTypes;
            this.IsTestMode = builder.IsTestMode;
            this.MuteVideoAd = builder.MuteVideoAd;
            this.SafeArea = builder.SafeArea;
            this.AutoCacheInterstitialAd = builder.AutoCacheInterstitialAd;
            this.AutoCacheRewardedAd = builder.AutoCacheRewardedAd;
            this.ChildDirectedTreatment = builder.ChildDirectedTreatment;
            this.SmartBanners = builder.SmartBanners;
            this.TabletBanner = builder.TabletBanner;
            this.BannerAnimation = builder.BannerAnimation;
        }

        public sealed class Builder
        {
            internal string AndroidAppKey { get; private set; }
            internal string IOSAppKey { get; private set; }
            internal int AdTypes { get; private set; }
            internal bool IsTestMode { get; private set; }

            internal bool SafeArea { get; private set; }
            internal bool MuteVideoAd { get; private set; }
            internal bool AutoCacheInterstitialAd { get; private set; }
            internal bool AutoCacheRewardedAd { get; private set; }
            internal bool ChildDirectedTreatment { get; private set; }

            internal bool BannerAnimation { get; private set; }
            internal bool SmartBanners { get; private set; }
            internal bool TabletBanner { get; private set; }

            public Builder(string androidAppKey, int adTypes)
            {
                this.AndroidAppKey = androidAppKey;
                this.AdTypes = adTypes;
            }

            public Builder WithIOSAppKey(string key)
            {
                this.IOSAppKey = key;

                return this;
            }

            public Builder WithTestMode()
            {
                this.IsTestMode = true;

                return this;
            }

            public Builder WithMuteVideoAd()
            {
                this.MuteVideoAd = true;

                Appodeal.MuteVideosIfCallsMuted(this.MuteVideoAd);

                return this;
            }

            public Builder WithSafeArea()
            {
                this.SafeArea = true;

                Appodeal.SetUseSafeArea(this.SafeArea);

                return this;
            }

            public Builder WithChildDirectedTreament()
            {
                this.ChildDirectedTreatment = true;

                Appodeal.SetChildDirectedTreatment(this.ChildDirectedTreatment);

                return this;
            }

            public Builder WithAutoCacheInterstitialAd()
            {
                this.AutoCacheInterstitialAd = true;

                Appodeal.SetAutoCache(AppodealAdType.Interstitial, this.AutoCacheInterstitialAd);

                return this;
            }

            public Builder WithAutoCacheRewardedAd()
            {
                this.AutoCacheRewardedAd = true;

                Appodeal.SetAutoCache(AppodealAdType.RewardedVideo, this.AutoCacheRewardedAd);

                return this;
            }

            public Builder WithBannerAnimation()
            {
                this.BannerAnimation = true;

                Appodeal.SetBannerAnimation(this.BannerAnimation);

                return this;
            }

            public Builder WithSmartBanners()
            {
                this.SmartBanners = true;

                Appodeal.SetSmartBanners(this.SmartBanners);

                return this;
            }

            public Builder WithTabletBanners()
            {
                this.TabletBanner = true;

                Appodeal.SetTabletBanners(this.TabletBanner);

                return this;
            }

            public AdConfigAdapter Build()
            {
                Appodeal.SetTesting(IsTestMode);

#if UNITY_ANDROID
                Appodeal.Initialize(AndroidAppKey, AdTypes);
#elif UNITY_IOS
                Appodeal.Initialize(IOSAppKey, AdTypes);
#endif

                return new AdConfigAdapter(this);
            }
        }
    }
}