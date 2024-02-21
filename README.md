#  SMAI APPODEAL
[![License](https://img.shields.io/github/license/mrveit/veittech-smai-appodeal?color=318CE7&style=flat-square)](LICENSE)
[![Version](https://img.shields.io/github/package-json/v/mrveit/veittech-smai-appodeal?color=318CE7&style=flat-square)](package.json)
[![Unity](https://img.shields.io/badge/Unity-2020.3.16+-2296F3.svg?color=318CE7&style=flat-square)](https://unity.com/releases/editor/archive)

**SMAIL Appodeal** is to speed up the integration of Appodeal Ad SDK into your project with a user-friendly api that reduces unnecessary lines of code.

Before importing this package, you should install the Appodeal SDK following their [official documentation](https://docs.appodeal.com/ru/unity/get-started) to avoid possible errors.

# Installation

**As a Unity module:**

Supports installation as a Unity module via a git link in the **Package Manager**
```
https://github.com/MrVeit/Veittech-SMAI-Appodeal.git
```
or direct editing of `Packages/manifest.json`:
```
"com.veittech.smai.appodeal": "https://github.com/MrVeit/Veittech-SMAI-Appodeal.git",
```

**As source:**

You can also clone the code into your Unity project.


# Initialization

First of all, you need to initialize the plugin before the first display of ads as follows:

**BEFORE:**
```c#
public sealed class StandartAppodealIntegration : MonoBehaviour
{
    private const int AD_TYPES = AppodealAdType.Interstitial | AppodealAdType.RewardedVideo
                               | AppodealAdType.Banner | AppodealAdType.Mrec;

    public void Init()
    {
        var androidKey = new AdInitializationKeys().GetAndroidKey();

        Appodeal.SetTesting(true);
        Appodeal.SetUseSafeArea(true);
        Appodeal.MuteVideosIfCallsMuted(true)

        AppodealCallbacks.Sdk.OnInitialized += OnInitializationFinished;

#if UNITY_ANDROID
        Appodeal.Initialize(androidKey, AD_TYPES);
#endif
    }

    public void OnInitializationFinished(object sender, SdkInitializedEventArgs e) {}
}
```
**AFTER:**
```c#
public sealed class AppodealIntegrationWithSMAI : MonoBehaviour
{
    private const int AD_TYPES = AppodealAdType.Interstitial | AppodealAdType.RewardedVideo
                               | AppodealAdType.Banner | AppodealAdType.Mrec;

    public void Init()
    {
        var androidKey = new AdInitializationKeys().GetAndroidKey();

        var adConfig = new AdConfigAdapter.Builder(androidKey, AD_TYPES)
          .WithTestMode()
          .WithSafeArea()
          .WithMuteVideoAd()
          .Build();
    }
}
```

The **AD_TYPES** constant specifies the types of advertisements that will be used in the project (if you doubt that one of the advertisement types will be used, it is better to delete it to avoid generating unnecessary requests to the Appodeal SDK).

In order for the Appodeal SDK to work correctly on two platforms, you need to initialize the application keys that are created [in the dashboard](https://app.appodeal.com/apps) on the Appodeal website. To do this, you need to set their values using the SMAI Appodeal settings window, which can be found at `SMAI -> Appodeal -> Settings`, having previously created them in the dashboard. 

<p align="center">
 <img width="700px" src="Assets/SMAISettingsPanel.png" alt="qr"/>
</p>

P.S: For convenience, the corresponding link to the key creation section can be opened by clicking on `Initialization App Keys`.

**IMPORTANT**: For correct work of Appodeal SDK and avoiding ARN errors. It is necessary to **NOT DESTROY** the initialization config for advertising between scenes via the `DontDestroyOnLoad(gameObject)` method after its initialization.

For example, if you have a project published under Google Play and App Store, the initialization method will have the following form:
```c#
public void Init()
{
    var keysStorage = new AdInitializationKeys();

    var androidKey = keysStorage.GetAndroidKey();
    var iosKey = keysStorage.GetIosKey();

    var adConfig = new AdConfigAdapter.Builder(androidKey, AD_TYPES)
        .WithIOSAppKey(iosKey)
        .WithTestMode()
        .WithSafeArea()
        .WithMuteVideoAd()
        .Build();

    DontDestroyOnLoad(gameObject);
}
```

For detailed configuration of banner ads there are 3 following initialization methods, which you can read about in detail in the official Appodeal SDK documentation, in the section [about banner ads](https://docs.appodeal.com/unity/ad-types/banner#enable-728x90-banners) 

```c#
public void Init()
{
    var androidKey = new AdInitializationKeys().GetAndroidKey();

    var adConfig = new AdConfigAdapter.Builder(androidKey, AD_TYPES)
        .WithTestMode()
        .WithSafeArea()
        .WithMuteVideoAd()
        .WithBannerAnimation()
        .WithSmartBanners()
        .WithTabletBanners()
        .Build();
}
```

# Usage template video ad

After initializing our config in the bootstrap, we can move on to implementing the logic for displaying ads.

For cross-page and reward ads, there is one important setting in the config that allows you to **ACTIVATE ADVERTISING AUTOCASHING**. Once activated, ads will be loaded as they appear, which can significantly reduce the pause between displays if you plan to show them continuously, **BUT IN THAT CASE** you may reduce the Display Rate, because the player may simply not get to the point in the game where the ad is scheduled to be shown.

**RECOMMENDED**: Do not activate auto-caching when initializing the config, but call manual ad caching 30-60 seconds before the potential display location.

```c#
public void CacheVideoAd()
{
    IVideoAd videoAd = new InterstitialAdAdapter();
    videoAd.Cache();

    IVideoAd videoAd = new RewardedAdAdapter();
    videoAd.Cache();
}
```
The logic of the show itself would look like this:

```c#
public void ShowVideoAd()
{
    IVideoAd videoAd = new InterstitialAdAdapter();
    videoAd.Show();

    IVideoAd videoAd = new RewardedAdAdapter();
    videoAd.Show();
}
```

Appodeal SDK provides a convenient [callback system](https://docs.appodeal.com/unity/ad-types/rewarded-video#callbacks) for issuing rewards for ad views. 
Below are **2 examples of implementing such logic**, choose the appropriate way depending on the installed version of SMAI Appodeal in our project:

### Implementing logic with award giving ON VERSION 1.0.7 and below:
```c#
public sealed class StandartImplementationOfRewardGiving : MonoBehaviour
{
    [SerializeField, Space(10)] private Button _rewardedAdButton;

    private IVideoAd _rewardedAd;

    private void OnEnable()
    {
        AppodealCallbacks.RewardedVideo.OnFinished += ClaimReward;
    }

    private void OnDisable()
    {
        AppodealCallbacks.RewardedVideo.OnFinished -= ClaimReward;
    }

    private void Start()
    {
        _rewardedAd = new RewardedAdAdapter();

        _rewardedAdButton.onClick.AddListener(ShowRewardedAd);
    }

    private void ShowRewardedAd()
    {
        _rewardedAd.Show();
    }

    private void ClaimReward(object sender, RewardedVideoFinishedEventArgs serverReward)
    {
        Debug.Log($"Reward {serverReward.Amount} after watch ad claimed!");
    }
}
```

### Implementation of logic with awarding of rewards IN VERSION 1.0.8 and higher:
```c#
public sealed class FastImplementationOfRewardGiving : MonoBehaviour
{
    [SerializeField, Space(10)] private Button _rewardedAdButton;

    private IVideoAdWithReward _rewardedAd;

    private void Start()
    {
        _rewardedAd = new RewardedAdAdapter();

        _rewardedAdButton.onClick.AddListener(ShowRewardedAd);
    }

    private void ShowRewardedAd()
    {
        _rewardedAd.Show(ClaimReward);
    }

    private void ClaimReward()
    {
        Debug.Log($"Reward after watch ad claimed!");
    }
}
```

# Usage template banner ad

There are 4 banner implementations in Appodeal SDK, between them they differ in size, which takes some part on the screen, as well as the ability to set a custom position:

1. Standard banner with a size of 320x50 and the ability to set the position [from 4 options](https://docs.appodeal.com/unity/ad-types/banner#display):
```c#
public void ShowClassicBanner()
{
    IBannerAd bannerAd = new ClassicBannerAdAdapter(AppodealShowStyle.BannerBottom);
    bannerAd.Show();

    IBannerAd bannerAd = new ClassicBannerAdAdapter(AppodealShowStyle.BannerTop);
    bannerAd.Show();

    IBannerAd bannerAd = new ClassicBannerAdAdapter(AppodealShowStyle.BannerLeft);
    bannerAd.Show();

    IBannerAd bannerAd = new ClassicBannerAdAdapter(AppodealShowStyle.BannerRight);
    bannerAd.Show();
}
```
2. Wide format banner (or tablet banner) size 728x90. It is activated in the same way as the first type of banner, but for it to work correctly, you need to add the **.WithTabletBanners()** method to the config.
3. Banner with custom position, the size can be standard - 320x50 or tablet - 728x90. You can read the details in the relevant [section of the banners.](https://docs.appodeal.com/unity/ad-types/banner#displaying-banner-at-custom-position). Position constants **ARE NOT MANDATORY** and you can set them yourself, depending on your needs.
It has horizontal and vertical position adjustment:
```c#
public void ShowCustomBanner()
{
    IBannerAd bannerAd = new CustomBannerAdAdapter(AppodealViewPosition.HorizontalSmart, AppodealViewPosition.VerticalBottom);
    bannerAd.Show();

    IBannerAd bannerAd = new CustomBannerAdAdapter(AppodealViewPosition.HorizontalCenter, AppodealViewPosition.VerticalTop);
    bannerAd.Show();

    IBannerAd bannerAd = new CustomBannerAdAdapter(AppodealViewPosition.HorizontalRight, AppodealViewPosition.VerticalBottom);
    bannerAd.Show();

    IBannerAd bannerAd = new CustomBannerAdAdapter(AppodealViewPosition.HorizontalLeft, AppodealViewPosition.VerticalTop);
    bannerAd.Show();
}
```

4. The final type of banners in the Appodeal SDK [are **MREC banners**](https://docs.appodeal.com/ru/unity/ad-types/mrec).
They perform exactly the same role as the 3rd type of banners, but have a much larger size - 300 x 250.
The following shows the implementation in SMAI Appodeal:
```c#
public void ShowMrecBanner()
{
    IBannerAd bannerAd = new MrecAdAdapter(AppodealViewPosition.HorizontalSmart, AppodealViewPosition.VerticalBottom);
    bannerAd.Show();

    IBannerAd bannerAd = new MrecAdAdapter(AppodealViewPosition.HorizontalCenter, AppodealViewPosition.VerticalTop);
    bannerAd.Show();

    IBannerAd bannerAd = new MrecAdAdapter(AppodealViewPosition.HorizontalRight, AppodealViewPosition.VerticalBottom);
    bannerAd.Show();

    IBannerAd bannerAd = new MrecAdAdapter(AppodealViewPosition.HorizontalLeft, AppodealViewPosition.VerticalTop);
    bannerAd.Show();
}
```

# Support:

[![Email](https://img.shields.io/badge/-gmail-090909?style=for-the-badge&logo=gmail)](https://mail.google.com/mail/?view=cm&fs=1&to=misster.veit@gmail.com)
[![Telegram](https://img.shields.io/badge/-Telegram-090909?style=for-the-badge&logo=telegram)](https://t.me/MrVeit)
