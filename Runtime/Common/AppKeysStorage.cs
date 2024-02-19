using UnityEngine;
using UnityEditor;
using Veittech.Modules.Ad.SMAI_Appodeal.Utils;

namespace Veittech.Modules.Ad.SMAI_Appodeal.Common
{
    public sealed class AppKeysStorage : ScriptableObject
    {
        [field: SerializeField, Space(10)] public string AndroidAppKey { get; set; }
        [field: SerializeField] public string AmazonAppKey { get; set; }
        [field: SerializeField] public string IosAppKey { get; set; }

        public const string FULL_FILE_NAME = "AppKeysStorage.asset";
        public const string FILE_NAME = "AppKeysStorage";

        public const string FILE_FOLDER = "Assets/Resources";

#if UNITY_EDITOR
        private static AppKeysStorage _instance;

        public static AppKeysStorage Instance
        {
            get
            {
                if (_instance)
                    return _instance;

                string path = $"{FILE_FOLDER}/{FULL_FILE_NAME}";

                _instance = SMAIUtils.ScriptableObjectsTools.
                    Target<AppKeysStorage>.LoadAssetAtPath(FILE_FOLDER, path);

                if (_instance)
                    return _instance;

                _instance = SMAIUtils.ScriptableObjectsTools.
                    Target<AppKeysStorage>.CreateInstance();

                SMAIUtils.ScriptableObjectsTools.CreateAsset(_instance, path);

                return _instance;
            }
        }

        public static void SaveAsync()
        {
            EditorUtility.SetDirty(_instance);
        }
#endif
    }
}