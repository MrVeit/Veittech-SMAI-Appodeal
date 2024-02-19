using System.IO;
using UnityEditor;
using UnityEngine;

namespace Veittech.Modules.Ad.SMAI_Appodeal.Utils
{
    public sealed class SMAIUtils
    {
        public sealed class ScriptableObjectsTools
        {
            public sealed class Target<T> where T : ScriptableObject
            {
                public static T CreateInstance()
                {
                    var instance = ScriptableObject.CreateInstance<T>();

                    return instance;
                }

                public static T LoadAssetAtPath(string folder, string path)
                {
                    Directory.CreateDirectory(folder);

                    return AssetDatabase.LoadAssetAtPath<T>(path);
                }
            }

            public static void CreateAsset(Object asset, string path)
            {
                AssetDatabase.CreateAsset(asset, path);
            }
        }
    }
}