using System;
using System.IO;
using BuildPackages.Channel;
using UnityEditor;

namespace BuildPackages
{
    public class PackageUtils
    {
        /// <summary>
        /// 根据平台和渠道变基获取路径地址
        /// </summary>
        /// <param name="target"></param>
        /// <param name="channel"></param>
        /// <returns></returns>
        public static string GetChannelRelativePath(BuildTarget target, ChannelObject channel)
        {
            string outputPath =
                Path.Combine(GetPlatformName(target), GetPlatformChannelFolderName(target, channel));
            return outputPath;
        }

        /// <summary>
        /// 获取打包平台的AssetBundle生成路径
        /// </summary>
        /// <param name="target"></param>
        /// <param name="channel"></param>
        /// <returns></returns>
        public static string GetAssetBundleRelativePath(BuildTarget target, ChannelObject channel)
        {
            string outputPath = GetChannelRelativePath(target, channel);
            outputPath = Path.Combine(outputPath, AppConfig.GetResAppConfig().ManifestBundleName);
            return outputPath;
        }

        /// <summary>
        /// 平台转路径字符串
        /// </summary>
        /// <param name="buildTarget"></param>
        /// <returns></returns>
        public static string GetPlatformName(BuildTarget buildTarget)
        {
            // switch (buildTarget)
            // {
            //     case BuildTarget.Android:
            //         return "Android";
            //     case BuildTarget.iOS:
            //         return "iOS";
            //     case BuildTarget.StandaloneOSX:
            //         return "StandaloneOSX";
            //     case BuildTarget.WebGL:
            //         return "WebGL";
            //     default:
            //         Logger.LogError("Error buildTarget!!!");
            //         return null;
            // }
            return Enum.GetName(typeof(BuildTarget), buildTarget);
        }

        /// <summary>
        /// 不同渠道获取不同路径地址
        /// </summary>
        /// <param name="target">打包的平台</param>
        /// <param name="channel">渠道名字</param>
        /// <returns></returns>
        public static string GetPlatformChannelFolderName(BuildTarget target, ChannelObject channel)
        {
            if (AppConfig.GetResAppConfig().AssetBundleIsChannel)
            {
                // 不同渠道的AB输出到不同的文件夹
                // return GetPlatformName(target) + "/" + channelName;
                return Path.Combine(GetPlatformName(target), channel.name);
            }
            else
            {
                // 否则写入通用的平台文件夹
                return GetPlatformName(target);
            }
        }


        /// <summary>
        /// 获取AssetBundle的输出地址
        /// </summary>
        /// <param name="target"></param>
        /// <param name="channelName"></param>
        /// <returns></returns>
        public static string GetAssetBundleOutputPath(BuildTarget target, ChannelObject channelName)
        {
            string outputPath = Path.Combine(System.Environment.CurrentDirectory,
                AppConfig.GetResAppConfig().AssetsFolderName);
            GameUtility.CheckDirAndCreateWhenNeeded(outputPath);
            outputPath = Path.Combine(outputPath,
                GetAssetBundleRelativePath(target, channelName));
            GameUtility.CheckDirAndCreateWhenNeeded(outputPath);
            return outputPath;
        }
    }
}