using System.Collections.Generic;
using System.IO;
using Sirenix.OdinInspector.Editor;
using UnityEditor;
using UnityEngine;

namespace EditorAssetBundle
{
    /// <summary>
    /// AssetBundle在Inspector显示设置和创建（可视化操作）
    /// </summary>
    [CustomEditor(typeof(DefaultAsset), true)]
    public class AssetBundleDispatcherInspector : OdinEditor
    {
        public static bool hasAnythingModified = false;

        AssetBundleDispatcherConfig dispatcherConfig = null;

        /// <summary>
        /// 当前文件在AssetsPackage下的路径
        /// </summary>
        string packagePath = null;

        /// <summary>
        /// 当前文件的路径
        /// </summary>
        string targetAssetPath = null;

        /// <summary>
        /// 当前文件生成的配置文件路径
        /// </summary>
        string databaseAssetPath = null;

        static Dictionary<string, bool> inspectorSate = new Dictionary<string, bool>();

        /// <summary>
        /// 当前文件的生存模式
        /// </summary>
        AssetBundleDispatcherFilterType filterType = AssetBundleDispatcherFilterType.Root;

        bool configChanged = false;
        bool isNewCreate = false;

        void OnEnable()
        {
            Initialize();
        }

        /// <summary>
        /// 初始化此文件的状态
        /// </summary>
        void Initialize()
        {
            configChanged = false;
            filterType = AssetBundleDispatcherFilterType.Root;
            targetAssetPath = AssetDatabase.GetAssetPath(target);
            if (!AssetBundleUtility.IsPackagePath(targetAssetPath))
            {
                return;
            }

            packagePath = AssetBundleUtility.AssetsPathToPackagePath(targetAssetPath);
            databaseAssetPath = AssetBundleInspectorUtils.AssetPathToDatabasePath(targetAssetPath);
            dispatcherConfig = AssetDatabase.LoadAssetAtPath<AssetBundleDispatcherConfig>(databaseAssetPath);
            if (dispatcherConfig != null)
            {
                dispatcherConfig.Load();
                filterType = dispatcherConfig.Type;
            }
        }

        void MarkChanged()
        {
            configChanged = true;
            hasAnythingModified = true;
        }

        void DrawCreateAssetBundleDispatcher()
        {
            if (GUILayout.Button("为此文件生成AssetBundle配置文件"))
            {
                var dir = Path.GetDirectoryName(databaseAssetPath);
                GameUtility.CheckDirAndCreateWhenNeeded(dir);

                var instance = CreateInstance<AssetBundleDispatcherConfig>();
                AssetDatabase.CreateAsset(instance, databaseAssetPath);
                AssetDatabase.Refresh();

                Initialize();
                Repaint();

                isNewCreate = true;
                MarkChanged();
            }
        }

        void DrawFilterItem(AssetBundleCheckerFilter checkerFilter)
        {
            GUILayout.BeginVertical();
            var relativePath = GUILayoutUtils.DrawInputField("RelativePath:", checkerFilter.RelativePath, 300f, 80f);
            var objectFilter = GUILayoutUtils.DrawInputField("ObjectFilter:", checkerFilter.ObjectFilter, 300f, 80f);
            if (relativePath != checkerFilter.RelativePath)
            {
                MarkChanged();
                checkerFilter.RelativePath = relativePath;
            }

            if (objectFilter != checkerFilter.ObjectFilter)
            {
                MarkChanged();
                checkerFilter.ObjectFilter = objectFilter;
            }

            GUILayout.EndVertical();
        }

        void DrawFilterTypesList(List<AssetBundleCheckerFilter> checkerFilters)
        {
            GUILayout.BeginVertical(EditorStyles.textField);
            GUILayout.Space(3);

            EditorGUILayout.Separator();
            for (int i = 0; i < checkerFilters.Count; i++)
            {
                var curFilter = checkerFilters[i];
                var relativePath = string.IsNullOrEmpty(curFilter.RelativePath) ? "root" : curFilter.RelativePath;
                var objectFilter = string.IsNullOrEmpty(curFilter.ObjectFilter) ? "all" : curFilter.ObjectFilter;
                var filterType = relativePath + ": <" + objectFilter + ">";
                var stateKey = "CheckerFilters" + i.ToString();
                if (GUILayoutUtils.DrawRemovableSubHeader(1, filterType, inspectorSate, stateKey, () =>
                {
                    MarkChanged();
                    checkerFilters.RemoveAt(i);
                    i--;
                }))
                {
                    DrawFilterItem(curFilter);
                }

                EditorGUILayout.Separator();
            }

            if (GUILayout.Button("Add"))
            {
                MarkChanged();
                checkerFilters.Add(new AssetBundleCheckerFilter("", "t:prefab"));
            }

            EditorGUILayout.Separator();

            GUILayout.Space(3);
            GUILayout.EndVertical();
        }

        void DrawAssetDispatcherConfig()
        {
            GUILayoutUtils.BeginContents(false);

            GUILayoutUtils.DrawProperty("Path:", AssetBundleUtility.AssetsPathToPackagePath(targetAssetPath), 300f,
                80f);

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("FilterType:", GUILayout.MaxWidth(80f));
            var selectType = (AssetBundleDispatcherFilterType) EditorGUILayout.EnumPopup(filterType);
            if (selectType != filterType)
            {
                filterType = selectType;
                MarkChanged();
            }

            EditorGUILayout.EndHorizontal();

            EditorGUILayout.Separator();
            var filtersCount = dispatcherConfig.CheckerFilters.Count;
            if (GUILayoutUtils.DrawSubHeader(0, "CheckerFilters:", inspectorSate, "CheckerFilters",
                filtersCount.ToString()))
            {
                DrawFilterTypesList(dispatcherConfig.CheckerFilters);
            }

            Color color = GUI.color;
            if (configChanged)
            {
                GUI.color = color * new Color(1, 1, 0.5f);
            }

            EditorGUILayout.Separator();
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Apply"))
            {
                Apply();
            }

            GUI.color = new Color(1, 0.5f, 0.5f);
            if (GUILayout.Button("Remove"))
            {
                ConfirmRemove();
            }

            GUI.color = color;
            GUILayout.EndHorizontal();
            EditorGUILayout.Separator();

            GUILayoutUtils.EndContents(false);
        }

        void Apply()
        {
            dispatcherConfig.Apply(packagePath,filterType);
            EditorUtility.SetDirty(dispatcherConfig);
            AssetDatabase.SaveAssets();

            Initialize();
            Repaint();
            configChanged = false;
        }

        void ConfirmRemove()
        {
            bool checkRemove = EditorUtility.DisplayDialog("Remove Warning",
                "Sure to remove the AssetBundle dispatcher ?",
                "Confirm", "Cancel");
            if (!checkRemove)
            {
                return;
            }

            Remove();
        }

        void Remove()
        {
            GameUtility.SafeDeleteFile(databaseAssetPath);
            AssetDatabase.Refresh();

            Initialize();
            Repaint();
            configChanged = false;
        }

        void DrawAssetBundleDispatcherInspector()
        {
            if (GUILayoutUtils.DrawHeader("AssetBundle Dispatcher : ", inspectorSate, "DispatcherConfig", true, false))
            {
                DrawAssetDispatcherConfig();
            }
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (!AssetBundleInspectorUtils.CheckMaybeAssetBundleAsset(targetAssetPath))
            {
                return;
            }

            GUI.enabled = true;

            if (dispatcherConfig == null)
            {
                DrawCreateAssetBundleDispatcher();
            }
            else
            {
                DrawAssetBundleDispatcherInspector();
            }
        }

        void OnDisable()
        {
            if (configChanged)
            {
                bool checkApply = EditorUtility.DisplayDialog("Modify Warning",
                    "You have modified the AssetBundle dispatcher setting, Apply it ?",
                    "Confirm", "Cancel");
                if (checkApply)
                {
                    Apply();
                }
                else if (isNewCreate)
                {
                    Remove();
                }
            }

            dispatcherConfig = null;
            inspectorSate.Clear();
            isNewCreate = false;
        }
    }
}