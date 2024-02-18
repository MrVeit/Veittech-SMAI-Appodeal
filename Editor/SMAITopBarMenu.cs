using UnityEngine;
using UnityEditor;

// ReSharper Disable CheckNamespace
namespace Veittech.Modules.Ad.SMAI_Appodeal.Editor.SettingsWindow
{
    public sealed class SMAITopBarMenu : ScriptableObject
    {
        [MenuItem("SMAI/Appodeal/Settings")]
        public static void OpenSettingsWindow()
        {
            SMAISettingsWindow.ShowWindow();
        }
    }
}