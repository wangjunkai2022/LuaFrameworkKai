using System;

public class AssetBundleUtility
{
    /// <summary>
    /// assetbundlePackage的路径转为unity Assets 下路径
    /// </summary>
    /// <param name="assetPath">assetbundlePackage 路径</param>
    /// <returns></returns>
    public static string PackagePathToAssetsPath(string assetPath)
    {
        return "Assets/" + AppConfig.GetResAppConfig().AssetsFolderName + "/" + assetPath;
    }

    /// <summary>
    /// 转化AssetBundle路径为AssetBundle名字
    /// </summary>
    /// <param name="assetPath"></param>
    /// <returns></returns>
    public static string AssetBundlePathToAssetBundleName(string assetPath)
    {
        if (!string.IsNullOrEmpty(assetPath))
        {
            if (assetPath.StartsWith("Assets/"))
            {
                assetPath = AssetsPathToPackagePath(assetPath);
            }

            //no " "
            assetPath = assetPath.Replace(" ", "");
            //there should not be any '.' in the assetbundle name
            //otherwise the variant handling in client may go wrong
            assetPath = assetPath.Replace(".", "_");
            //add after suffix ".assetbundle" to the end
            // assetPath = assetPath + AppConfig.GetResAppConfig().AssetBundleSuffix;
            //使用MD5名字
            assetPath = MD5Util.FromString(assetPath) + AppConfig.GetResAppConfig().AssetBundleSuffix;
            return assetPath.ToLower();
        }

        return null;
    }

    /// <summary>
    /// 把Assets下全路径转化为在AssetPackage资源路径
    /// </summary>
    /// <param name="assetPath"></param>
    /// <returns></returns>
    public static string AssetsPathToPackagePath(string assetPath)
    {
        string path = "Assets/" + AppConfig.GetResAppConfig().AssetsFolderName + "/";
        if (assetPath.StartsWith(path))
        {
            return assetPath.Substring(path.Length);
        }
        else
        {
            Logger.LogError($"Asset path is not a package path! \n{assetPath}");
            return assetPath;
        }
    }

    /// <summary>
    /// 路径是否是Asset的资源路径
    /// </summary>
    /// <param name="assetPath"></param>
    /// <returns></returns>
    public static bool IsPackagePath(string assetPath)
    {
        string path = "Assets/" + AppConfig.GetResAppConfig().AssetsFolderName + "/";
        return assetPath.StartsWith(path);
    }
}