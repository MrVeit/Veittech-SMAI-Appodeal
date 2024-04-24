using System;
using System.Collections.Generic;
using UnityEngine;
using AppodealStack.Monetization.Api;
using AppodealStack.Monetization.Common;
using Veittech.Modules.Ad.SMAI_Appodeal.Utils;

namespace Veittech.Modules.Ad.SMAI_Appodeal.Common
{
    public sealed class AdConfigAdapter
    {
        public bool IsInitialized { get; private set; }
        public bool IsTestMode { get; private set; }

        public int AdTypes { get; private set; }

        public string AndroidAppKey { get; private set; }
        public string IOSAppKey { get; private set; }

        public bool SafeArea { get; private set; }
        public bool MuteVideoAd {get; private set; }
        public bool ChildDirectedTreatment { get; private set; }

        public bool AutoCacheInterstitialAd { get; private set; }
        public bool AutoCacheRewardedAd { get; private set; }
        public bool AutoCacheBannerAd { get; private set; }
        public bool AutoCacheMrecAd { get; private set; }

        public bool BannerAnimation { get; private set; }
        public bool SmartBanners { get; private set; }
        public bool TabletBanner { get; private set; }

        public AppodealLogLevel LogLevel { get; private set; }

        public IReadOnlyList<string> DisabledNetworksNames { get; private set; }
        public IReadOnlyList<AppodealAdNetworks> DisabledNetworks { get; private set; }

        private AdConfigAdapter(Builder builder)
        {
            this.IsInitialized = builder.IsInitialized;
            this.IsTestMode = builder.IsTestMode;
            this.AdTypes = builder.AdTypes;
            this.AndroidAppKey = builder.AndroidAppKey;
            this.IOSAppKey = builder.IOSAppKey;
            this.MuteVideoAd = builder.MuteVideoAd;
            this.SafeArea = builder.SafeArea;
            this.ChildDirectedTreatment = builder.ChildDirectedTreatment;
            this.AutoCacheInterstitialAd = builder.AutoCacheInterstitialAd;
            this.AutoCacheRewardedAd = builder.AutoCacheRewardedAd;
            this.AutoCacheBannerAd = builder.AutoCacheBannerAd;
            this.AutoCacheMrecAd = builder.AutoCacheMrecAd;
            this.SmartBanners = builder.SmartBanners;
            this.TabletBanner = builder.TabletBanner;
            this.BannerAnimation = builder.BannerAnimation;
            this.LogLevel = builder.LogLevel;
            this.DisabledNetworks = builder.DisabledNetworks;
            this.DisabledNetworksNames = builder.DisabledNetworksNames;
        }

        public sealed class Builder
        {
            internal bool IsInitialized { get; private set; }
            internal bool IsTestMode { get; private set; }

            internal int AdTypes { get; private set; }

            internal string AndroidAppKey { get; private set; }
            internal string IOSAppKey { get; private set; }

            internal bool SafeArea { get; private set; }
            internal bool MuteVideoAd { get; private set; }
            internal bool ChildDirectedTreatment { get; private set; }

            internal bool AutoCacheInterstitialAd { get; private set; }
            internal bool AutoCacheRewardedAd { get; private set; }
            internal bool AutoCacheBannerAd { get; private set; }
            internal bool AutoCacheMrecAd { get; private set; }

            internal bool BannerAnimation { get; private set; }
            internal bool SmartBanners { get; private set; }
            internal bool TabletBanner { get; private set; }

            internal AppodealLogLevel LogLevel { get; private set; }

            internal List<string> DisabledNetworksNames { get; private set; }
            internal List<AppodealAdNetworks> DisabledNetworks { get; private set; }

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

            public Builder WithAutoCacheBannerAd()
            {
                this.AutoCacheBannerAd = true;

                Appodeal.SetAutoCache(AppodealAdType.Banner, this.AutoCacheBannerAd);

                return this;
            }

            public Builder WithAutoCacheMrecAd()
            {
                this.AutoCacheMrecAd = true;

                Appodeal.SetAutoCache(AppodealAdType.Mrec, this.AutoCacheMrecAd);

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

            public Builder WithLogLevel(AppodealLogLevel level)
            {
                this.LogLevel = level;

                Appodeal.SetLogLevel(level);

                return this;
            }

            public Builder WithDisableAdNetwork(AppodealAdNetworks network)
            {
                DisabledNetworks.Add(network);

                SMAIAppodealUtils.AdTools.DisableNetwork(network);

                return this;
            }

            public Builder WithDisableNetworks(AppodealAdNetworks[] networks)
            {
                foreach (var network in networks)
                {
                    DisabledNetworks.Add(network);
                }

                SMAIAppodealUtils.AdTools.DisableNetworks(networks);

                return this;
            }

            public Builder WithDisableNetwork(string networkName)
            { 
                DisabledNetworksNames.Add(networkName);

                SMAIAppodealUtils.AdTools.DisableNetwork(networkName);

                return this;
            }

            public Builder WithDisableNetworks(string[] networksNames)
            {
                foreach (var networkName in networksNames)
                {
                    DisabledNetworksNames.Add(networkName);
                }

                SMAIAppodealUtils.AdTools.DisableNetworks(networksNames);

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

            public AdConfigAdapter Build(Action<bool, List<string>> initializationFinished)
            {
                AppodealCallbacks.Sdk.OnInitialized += 
                    (sender, sdkInitializeArgs) =>
                    {
                        InitializationFinished(sender, sdkInitializeArgs);

                        if (sdkInitializeArgs.Errors == null)
                        {
                            initializationFinished?.Invoke(true, null);

                            return;
                        }

                        initializationFinished?.Invoke(false, sdkInitializeArgs.Errors);
                    };

                Build();

                return new AdConfigAdapter(this);
            }

            private void InitializationFinished(object sender,
                SdkInitializedEventArgs sdkInitializedArgs)
            {
                AppodealCallbacks.Sdk.OnInitialized -= InitializationFinished;

                if (sdkInitializedArgs.Errors == null)
                {
                    IsInitialized = true;

                    return;
                }

                foreach (var item in sdkInitializedArgs.Errors)
                {
                    Debug.LogError($"[SMAI APPODEAL] Appodeal SDK initialization" +
                        $" did not complete successfully, the reasons are as follows: {item}");
                }
            }
        }
    }
}