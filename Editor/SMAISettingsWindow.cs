using System.Diagnostics.CodeAnalysis;
using UnityEditor;
using UnityEngine;

// ReSharper Disable CheckNamespace
namespace Veittech.Modules.Ad.SMAI_Appodeal.Editor.SettingsWindow
{
    [SuppressMessage("ReSharper", "StringLiteralTypo")]
    public sealed class SMAISettingsWindow : EditorWindow
    {
        private void OnDestroy()
        {
            SMAISettings.SaveAsync();
            AssetDatabase.SaveAssets();
        }

        public static void ShowWindow()
        {
            GetWindowWithRect(typeof(SMAISettingsWindow), new Rect(0, 0, 650, 150), true, "SMAI Settings");
        }

        private void OnGUI()
        {
            LaberHeaderField("Base Settings");

            #region Base Settings

            GUILayout.BeginHorizontal();

            using (new EditorGUILayout.VerticalScope("box"))
            {
                if (GUILayout.Button("Initialization App Keys", new GUIStyle(EditorStyles.label)
                {
                    fontSize = 15,
                    fontStyle = FontStyle.Bold,
                    fixedHeight = 25

                }, GUILayout.Width(200)))
                {
                    Application.OpenURL("https://app.appodeal.com/apps/new");
                }

                GUILayout.Space(2);

                SMAISettings.Instance.AndroidAppKey = TextRow("Android Key",
                    SMAISettings.Instance.AndroidAppKey, GUILayout.Width(200));

                GUILayout.Space(5);

                SMAISettings.Instance.AmazonAndroidAppKey = TextRow("Amazon Android Key",
                    SMAISettings.Instance.AmazonAndroidAppKey, GUILayout.Width(200));

                GUILayout.Space(5);

                SMAISettings.Instance.IOSAppKey = TextRow("iOS Key",
                    SMAISettings.Instance.IOSAppKey, GUILayout.Width(200)); ;

                GUILayout.Space(5);
            }

            GUILayout.EndHorizontal();

            #endregion
        }

        private static void LaberHeaderField(string headerName)
        {
            EditorGUILayout.LabelField(headerName, new GUIStyle(EditorStyles.label)
            {
                fontSize = 16,
                fontStyle = FontStyle.Bold,

                normal = new GUIStyleState()
                {
                    textColor = Color.cyan
                },

                alignment = TextAnchor.MiddleCenter

            }, GUILayout.Height(20));

            HorizontalLine(new GUIStyle()
            {
                normal = new GUIStyleState()
                {
                    background = EditorGUIUtility.whiteTexture
                },
                margin = new RectOffset(0, 0, 10, 5),
                fixedHeight = 2
            });
        }

        private static string TextRow(string fieldTitle, string text, GUILayoutOption laberWidth,
            GUILayoutOption textFieldWidthOption = null)
        {
            GUILayout.BeginHorizontal();
            EditorGUILayout.LabelField(new GUIContent(fieldTitle), laberWidth);

            text = textFieldWidthOption == null
                ? GUILayout.TextField(text) : 
                GUILayout.TextField(text, textFieldWidthOption);

            GUILayout.EndHorizontal();

            return text;
        }

        private static void HorizontalLine(GUIStyle lineStyle)
        {
            var color = GUI.color;

            GUI.color = Color.grey;
            GUILayout.Box(GUIContent.none, lineStyle);
            GUI.color = color;
        }
    }
}