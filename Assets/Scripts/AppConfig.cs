using System;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;
using XLua;

/// <summary>
/// App配置文件
/// </summary>
[CreateAssetMenu]
public class AppConfig : ScriptableObject
{
    [BoxGroup("AssetBundle")] [LabelText("存放资源的路径")]
    public String AssetsFolderName = "AssetPackages";

    [BoxGroup("AssetBundle")] [LabelText("多渠道 文件名字")]
    public String ChannelFolderName = "Channel";

    [BoxGroup("AssetBundle")] [LabelText("后缀名")]
    public string AssetBundleSuffix = ".assetbundle";

    [BoxGroup("AssetBundle")] [LabelText("生成的AssetBundle的名字")]
    public string ManifestBundleName = "AssetBundles";

    [BoxGroup("AssetBundle")] [LabelText("是否启动多渠道功能")]
    public bool AssetBundleIsChannel = false;

    [BoxGroup("AssetBundle")] [LabelText("Assetbundle版本管理文件名")]
    public string VersionsFileName = "versions.bytes";

    public AppConfig()
    {
    }

    /// <summary>
    /// 获取Resource中的配置
    /// </summary>
    /// <returns></returns>
    public static AppConfig GetResAppConfig()
    {
        var config = Resources.Load<AppConfig>("AppConfig");
        if (null == config)
        {
            config = CreateInstance<AppConfig>();
#if UNITY_EDITOR
            AssetDatabase.CreateAsset(config, "Assets/Resources/AppConfig.asset");
#else
            Logger.LogError("配置文件是空 请先创建配置文件在Resource中");
#endif
        }

        return config;
    }
}