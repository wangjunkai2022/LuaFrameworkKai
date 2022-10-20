using Sirenix.OdinInspector;
using UnityEngine;

namespace EditorAssetBundle
{
    /// <summary>
    /// AssetBundle 版本配置文件
    /// </summary>
    public class AssetBundleResVersionConfig : ScriptableObject
    {
        [BoxGroup("AssetBundle")] [LabelText("配子文件存放路径")]
        public const string RES_PATH = AssetBundleInspectorUtils.DatabaseRoot + "/AssetBundleResVersionConfig.asset";

        [BoxGroup("AssetBundle")] [LabelText("当前App版本")]
        public string appVersion = "1.0.0";

        [BoxGroup("AssetBundle")] [LabelText("当前资源版本")]
        public string resVersion = "1.0.0";
    }
}