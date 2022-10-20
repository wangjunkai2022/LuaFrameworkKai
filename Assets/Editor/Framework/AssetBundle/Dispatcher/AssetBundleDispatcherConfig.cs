using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace EditorAssetBundle
{
    /// <summary>
    /// 当前AssetBundle文件配置枚举
    /// </summary>
    public enum AssetBundleDispatcherFilterType
    {
        /// <summary>
        /// 直接所有文件加入AssetBundle
        /// </summary>
        Root,

        /// <summary>
        /// 文件夹下所有文件和文件夹都加入到单独的AssetBundle中
        /// </summary>
        Children,

        /// <summary>
        /// 文件夹下所有文件夹都加入到单独的AssetBundle中
        /// </summary>
        ChildrenFoldersOnly,

        /// <summary>
        /// 文件夹下所有文件都加入到单独的AssetBundle中
        /// </summary>
        ChildrenFilesOnly,
    }

    /// <summary>
    /// 可视化AssetBundle的配置文件
    /// </summary>
    public class AssetBundleDispatcherConfig : ScriptableObject
    {
        [LabelText("当前的包路径")]
        [ShowInInspector, EnableGUI]
        public string PackagePath { private set; get; }

        [LabelText("当前文件的AssetBundle处理的类型")]
        [ShowInInspector, EnableGUI]
        public AssetBundleDispatcherFilterType Type { private set; get; }

        [LabelText("当前文件Filters")]
        [ShowInInspector, EnableGUI]
        public List<AssetBundleCheckerFilter> CheckerFilters { private set; get; }


        // 序列化用的，AssetBundleCheckerFilter的字段拆成两个数组
        // [SerializeField] [ShowInInspector] string[] RelativePaths = null;
        // [SerializeField] [ShowInInspector] string[] ObjectFilters = null;
        // [LabelText("当前文件Filters")]
        // private Dictionary<string, string> Filter;

        public AssetBundleDispatcherConfig()
        {
            PackagePath = string.Empty;
            Type = AssetBundleDispatcherFilterType.Root;
            CheckerFilters = new List<AssetBundleCheckerFilter>();
        }

        /// <summary>
        /// 加载此文件配置
        /// </summary>
        public void Load()
        {
            // CheckerFilters.Clear();
        }

        /// <summary>
        /// 保存文件
        /// </summary>
        public void Apply(string packagePath, AssetBundleDispatcherFilterType filterType)
        {
            PackagePath = packagePath;
            Type = filterType;
        }
    }
}