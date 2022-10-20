using System.IO;
using UnityEngine;

public class GameUtility
{
    public const string AssetsFolderName = "Assets";

    /// <summary>
    /// 转化Windows下\\路径为linux（公用）路径
    /// </summary>
    /// <param name="path">需要转化的路径</param>
    /// <returns></returns>
    public static string FormatToUnityPath(string path)
    {
        return path.Replace("\\", "/");
    }

    public static string FormatToSysFilePath(string path)
    {
        return path.Replace("/", "\\");
    }

    /// <summary>
    /// 检查并创建文件夹
    /// </summary>
    /// <param name="folderPath">需要检测的文件夹全路径</param>
    public static void CheckDirAndCreateWhenNeeded(string folderPath)
    {
        if (string.IsNullOrEmpty(folderPath))
        {
            return;
        }

        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }
    }

    /// <summary>
    /// 检查并创建文件
    /// </summary>
    /// <param name="filePath">需要检测的文件全路径</param>
    public static void CheckFileAndCreateDirWhenNeeded(string filePath)
    {
        if (string.IsNullOrEmpty(filePath))
        {
            return;
        }

        FileInfo file_info = new FileInfo(filePath);
        DirectoryInfo dir_info = file_info.Directory;
        if (!dir_info.Exists)
        {
            Directory.CreateDirectory(dir_info.FullName);
        }
    }

    /// <summary>
    /// 读取文件为字节
    /// </summary>
    /// <param name="inFile">需要读取的文件</param>
    /// <returns></returns>
    public static byte[] SafeReadAllBytes(string inFile)
    {
        try
        {
            if (string.IsNullOrEmpty(inFile))
            {
                return null;
            }

            if (!File.Exists(inFile))
            {
                return null;
            }

            File.SetAttributes(inFile, FileAttributes.Normal);
            return File.ReadAllBytes(inFile);
        }
        catch (System.Exception ex)
        {
            Logger.LogError(string.Format("SafeReadAllBytes failed! path = {0} with err = {1}", inFile,
                ex.Message));
            return null;
        }
    }

    /// <summary>
    /// 读取文件为文字
    /// </summary>
    /// <param name="inFile">读取的文件</param>
    /// <returns></returns>
    public static string SafeReadAllText(string inFile)
    {
        try
        {
            if (string.IsNullOrEmpty(inFile))
            {
                return null;
            }

            if (!File.Exists(inFile))
            {
                return null;
            }

            File.SetAttributes(inFile, FileAttributes.Normal);
            return File.ReadAllText(inFile);
        }
        catch (System.Exception ex)
        {
            Logger.LogError(string.Format("SafeReadAllText failed! path = {0} with err = {1}", inFile, ex.Message));
            return null;
        }
    }

    /// <summary>
    /// 写入文本到文件
    /// </summary>
    /// <param name="outFile">需要写入的文件的路径</param>
    /// <param name="text">需要写入的文本</param>
    /// <returns></returns>
    public static bool SafeWriteAllText(string outFile, string text)
    {
        try
        {
            if (string.IsNullOrEmpty(outFile))
            {
                return false;
            }

            CheckFileAndCreateDirWhenNeeded(outFile);
            if (File.Exists(outFile))
            {
                File.SetAttributes(outFile, FileAttributes.Normal);
            }

            File.WriteAllText(outFile, text);
            return true;
        }
        catch (System.Exception ex)
        {
            Logger.LogError(
                string.Format("SafeWriteAllText failed! path = {0} with err = {1}", outFile, ex.Message));
            return false;
        }
    }

    /// <summary>
    /// 删除文件
    /// </summary>
    /// <param name="filePath">需要删除的文件的路径</param>
    /// <returns></returns>
    public static bool SafeDeleteFile(string filePath)
    {
        try
        {
            if (string.IsNullOrEmpty(filePath))
            {
                return true;
            }

            if (!File.Exists(filePath))
            {
                return true;
            }

            File.SetAttributes(filePath, FileAttributes.Normal);
            File.Delete(filePath);
            return true;
        }
        catch (System.Exception ex)
        {
            Logger.LogError(string.Format("SafeDeleteFile failed! path = {0} with err: {1}", filePath, ex.Message));
            return false;
        }
    }

    /// <summary>
    /// 全路径转为UnityAsset路径
    /// </summary>
    /// <param name="full_path">需要转化的路径</param>
    /// <returns>如果路径包含UnityAsset路径则返回转化后的路径 如果不包含Unity路径则为空</returns>
    public static string FullPathToAssetPath(string full_path)
    {
        full_path = FormatToUnityPath(full_path);
        if (!full_path.StartsWith(Application.dataPath))
        {
            return null;
        }

        string ret_path = full_path.Replace(Application.dataPath, "");
        return AssetsFolderName + ret_path;
    }
}