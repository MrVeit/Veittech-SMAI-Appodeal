using System.IO;
using UnityEditor;
using UnityEngine;
using Veittech.Modules.Ad.SMAI_Appodeal.Editor.Common;

// ReSharper Disable CheckNamespace
namespace Veittech.Modules.Ad.SMAI_Appodeal.Editor.SettingsWindow
{
    public sealed class SMAISettings : ScriptableObject
    {
        [SerializeField, Space(10)] private string _androidAppKey = SMAIConstants.START_ANDROID_KEY;
        [SerializeField] private string _androidAmazonAppKey = SMAIConstants.START_AMAZON_KEY;
        [SerializeField] private string _iosAppKey = SMAIConstants.START_IOS_KEY;

        private const string SETTINGS_FILE_NAME = "SMAI_Settings.asset";

        private static SMAISettings _instance;

        public static SMAISettings Instance
        {
            get
            {
                if (_instance)
                    return _instance;

                string filePath = $"{SMAIConstants.EDITOR_COMPONENTS_PATH}/{SETTINGS_FILE_NAME}";

                Directory.CreateDirectory(SMAIConstants.EDITOR_COMPONENTS_PATH);

                _instance = AssetDatabase.LoadAssetAtPath<SMAISettings>(filePath);

                if (_instance)
                    return _instance;

                _instance = CreateInstance<SMAISettings>();
                AssetDatabase.CreateAsset(_instance, filePath);

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