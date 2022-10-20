using System.IO;

namespace EditorAssetBundle
{
    public class AssetBundleInspectorUtils
    {
        public const string DatabaseRoot = "Assets/Editor/Framework/AssetBundle/Database";

        static public bool CheckMaybeAssetBundleAsset(string assetPath)
        {
            return assetPath.StartsWith("Assets/" + AppConfig.GetResAppConfig().AssetsFolderName);
        }

        /// <summary>
        /// Asset文件path转为Database中的路径
        /// </summary>
        /// <param name="assetPath"></param>
        /// <returns></returns>
        static public string AssetPathToDatabasePath(string assetPath)
        {
            if (!CheckMaybeAssetBundleAsset(assetPath))
            {
                return null;
            }

            assetPath = assetPath.Replace("Assets/", "");
            return Path.Combine(DatabaseRoot, assetPath + ".asset");
        }
    }
}