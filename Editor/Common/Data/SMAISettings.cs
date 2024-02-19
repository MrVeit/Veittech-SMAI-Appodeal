using System.IO;
using UnityEngine;
using UnityEditor;
using Veittech.Modules.Ad.SMAI_Appodeal.Editor.Common;
using Veittech.Modules.Ad.SMAI_Appodeal.Utils;

// ReSharper Disable CheckNamespace
namespace Veittech.Modules.Ad.SMAI_Appodeal.Editor.SettingsWindow
{
    public sealed class SMAISettings : ScriptableObject
    {
        [SerializeField, Space(10)] private string _androidAppKey = SMAIConstants.START_ANDROID_KEY;
        [SerializeField] private string _androidAmazonAppKey = SMAIConstants.START_AMAZON_KEY;
        [SerializeField] private string _iosAppKey = SMAIConstants.START_IOS_KEY;

        public const string SETTINGS_FILE_NAME = "SMAI_Settings.asset";

        private static SMAISettings _instance;

        public static SMAISettings Instance
        {
            get
            {
                if (_instance)
                    return _instance;

                string folder = SMAIConstants.EDITOR_COMPONENTS_PATH; ;
                string path = $"{folder}/{SETTINGS_FILE_NAME}";

                _instance = SMAIUtils.ScriptableObjectsTools.
                    Target<SMAISettings>.LoadAssetAtPath(folder, path);

                if (_instance)
                    return _instance;

                _instance = SMAIUtils.ScriptableObjectsTools.
                    Target<SMAISettings>.CreateInstance();

                SMAIUtils.ScriptableObjectsTools.CreateAsset(_instance, path);

                return _instance;
            }
        }

        public string AndroidAppKey
        {
            get => _androidAppKey;
            set => _androidAppKey = value.Trim();
        }

        public string AmazonAndroidAppKey
        {
            get => _androidAmazonAppKey;
            set => _androidAmazonAppKey = value.Trim();
        }

        public string IOSAppKey
        {
            get => _iosAppKey;
            set => _iosAppKey = value.Trim();
        }

        public static void SaveAsync()
        {
            EditorUtility.SetDirty(_instance);
        }
    }
}