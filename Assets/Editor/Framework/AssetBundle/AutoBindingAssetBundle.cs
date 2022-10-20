using System;
using System.IO;
using System.Linq;
using System.Text;
using BuildPackages;
using BuildPackages.Channel;
using UnityEditor;
using UnityEditor.Build.Content;
using UnityEditor.Build.Pipeline;
using UnityEngine;
using UnityEngine.Build.Pipeline;

namespace EditorAssetBundle
{
    public class AutoBindingAssetBundle
    {
        public static void SwitchChannel(string channelName)
        {
            var channelFolderPath =
                AssetBundleUtility.PackagePathToAssetsPath(AppConfig.GetResAppConfig().ChannelFolderName);
            var guids = AssetDatabase.FindAssets("t:textAsset", new string[] {channelFolderPath});
            foreach (var guid in guids)
            {
                var path = AssetDatabase.GUIDToAssetPath(guid);
                GameUtility.SafeWriteAllText(path, channelName);
            }

            AssetDatabase.Refresh();
        }

        public static void ClearAllAssetBundles()
        {
            var assebundleNames = AssetDatabase.GetAllAssetBundleNames();
            var length = assebundleNames.Length;
            var count = 0;
            foreach (var assetbundleName in assebundleNames)
            {
                count++;
                EditorUtility.DisplayProgressBar("删除所有绑定的AssetBundle:", assetbundleName, (float) count / length);
                AssetDatabase.RemoveAssetBundleName(assetbundleName, true);
            }

            AssetDatabase.Refresh();
            EditorUtility.ClearProgressBar();

            assebundleNames = AssetDatabase.GetAllAssetBundleNames();
            if (assebundleNames.Length != 0)
            {
                Logger.LogError("Something wrong!!!");
            }
        }

        /// <summary>
        /// 检查所有的AssetBundle配置文件
        /// </summary>
        /// <param name="checkChannel"></param>
        public static void RunAllCheckers(bool checkChannel)
        {
            try
            {
                var guids = AssetDatabase.FindAssets("t:AssetBundleDispatcherConfig",
                    new string[] {AssetBundleInspectorUtils.DatabaseRoot});
                var length = guids.Length;
                var count = 0;
                foreach (var guid in guids)
                {
                    count++;
                    var assetPath = AssetDatabase.GUIDToAssetPath(guid);
                    var config = AssetDatabase.LoadAssetAtPath<AssetBundleDispatcherConfig>(assetPath);
                    config.Load();
                    EditorUtility.DisplayProgressBar("正在绑定所有的AssetBundle资源:", config.PackagePath,
                        (float) count / length);
                    AssetBundleDispatcher.Run(config, checkChannel);
                }
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }
            finally
            {
                AssetDatabase.Refresh();
                EditorUtility.ClearProgressBar();
            }
        }

        public static void Run(bool checkChannel)
        {
            ClearAllAssetBundles();
            RunAllCheckers(checkChannel);
            AssetDatabase.Refresh();
            InnerBuildAssetBundles(EditorUserBuildSettings.activeBuildTarget, null, true);
        }

        public static void InnerBuildAssetBundles(BuildTarget buildTarget, ChannelObject channel, bool writeConfig)
        {
            string outPath = PackageUtils.GetAssetBundleOutputPath(buildTarget, channel);

            if (!Directory.Exists(outPath))
            {
                Directory.CreateDirectory(outPath);
            }
 
            var bundles = ContentBuildInterface.GenerateAssetBundleBuilds();
            for (var i = 0; i < bundles.Length; i++)
            {
                bundles[i].addressableNames = bundles[i].assetNames.Select(Path.GetFileName).ToArray();
            }

            var totalManifest = CompatibilityBuildPipeline.BuildAssetBundles(outPath, bundles,
                BuildAssetBundleOptions.ChunkBasedCompression, buildTarget);
            if (totalManifest != null && writeConfig)
            {
            }

            WriteBundlesVersionFile(totalManifest, buildTarget, channel);
        }

        public static void WriteBundlesVersionFile(CompatibilityAssetBundleManifest manifest, BuildTarget buildTarget,
            ChannelObject channel)
        {
            string outputPath = PackageUtils.GetAssetBundleOutputPath(buildTarget, channel);

            var allAssetbundles = manifest.GetAllAssetBundles();
            StringBuilder sb = new StringBuilder();
            if (allAssetbundles != null && allAssetbundles.Length > 0)
            {
                foreach (var assetbundle in allAssetbundles)
                {
                    FileInfo fileInfo = new FileInfo(Path.Combine(outputPath, assetbundle));

                    Hash128 hash = manifest.GetAssetBundleHash(assetbundle);
                    int size = (int) (fileInfo.Length / 1024) + 1;
                    sb.AppendFormat("{0}|{1}|{2}\n", GameUtility.FormatToUnityPath(assetbundle), hash, size);
                }
            }

            string content = sb.ToString().Trim();
            GameUtility.SafeWriteAllText(Path.Combine(outputPath, AppConfig.GetResAppConfig().VersionsFileName),
                content);
        }
    }
}