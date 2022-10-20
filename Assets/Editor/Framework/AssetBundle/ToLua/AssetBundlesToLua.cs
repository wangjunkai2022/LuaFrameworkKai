using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using DG.Tweening.Plugins.Core.PathCore;
using UnityEditor;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.Build.Pipeline;
using Path = System.IO.Path;

namespace EditorAssetBundle
{
    class LuaObj
    {
        private string path = string.Empty;
        private string assbundleName = string.Empty;
        private string fileName = String.Empty;
    }


    /// <summary>
    /// AssetBundle转为Lua
    /// </summary>
    public class AssetBundlesToLua
    {
        /// <summary>
        /// 导出路径
        /// </summary>
        private const string LuaFilePath = "Assets/LuaScripts/AssetBundlePaths.lua";

        /// <summary>
        /// 模版文件
        /// </summary>
        public const string TEMPLATE_FILE =
            "Assets/Editor/Framework/AssetBundle/ToLua/AssetBundleNameClassTemplate.txt";

        public const string TEMPLATE_SPLIT = "------------------------------Split--------------------------------";

        #region 替换标记

        public const string CLASS_NAME_FLAG = "[CLASS NAME]";
        public const string CLASS_LIST_FLAG = "[CLASS LIST]";
        public const string FIELD_LIST_FLAG = "[FIELD LIST]";
        public const string FIELD_NAME_FLAG = "[FIELD NAME]";
        public const string FIELD_VALUE_FLAG = "[FIELD VALUE]";
        public const string EXPLAIN_FLAG = "[EXPLAIN]";

        #endregion

        string _mainClassT;
        string _explainT;
        string _classT;
        string _fieldT;

        public void Binding()
        {
            var dir = Directory.GetParent(LuaFilePath);
            if (false == dir.Exists)
            {
                dir.Create();
            }

            var template = File.ReadAllText(TEMPLATE_FILE).Split(new string[]
            {
                TEMPLATE_SPLIT
            }, StringSplitOptions.RemoveEmptyEntries);

            _mainClassT = template[0];
            _explainT = template[1];
            _classT = template[2];
            _fieldT = template[3];

            string classContent;
            var mainClassName = Path.GetFileNameWithoutExtension(LuaFilePath);
            classContent = _mainClassT.Replace(CLASS_NAME_FLAG, mainClassName + " = ");
            classContent = classContent.Replace(CLASS_LIST_FLAG, GenerateClassList());

            File.WriteAllText(LuaFilePath, classContent);
        }

        private string GenerateClassList()
        {
            StringBuilder sb = new StringBuilder();

            var bundles = ContentBuildInterface.GenerateAssetBundleBuilds();
            foreach (var vo in bundles)
            {
                foreach (var fileName in vo.assetNames)
                {
                    var classContent = GenerateClass(vo, fileName);
                    sb.Append(classContent);
                }
            }

            return sb.ToString();
        }

        private string GenerateClass(AssetBundleBuild vo, string filePath)
        {
            var fieldList = GenerateFieldList(vo.assetBundleName, filePath);

            var content = _classT;
            content = content.Replace(CLASS_NAME_FLAG,
                MakeFieldNameRightful(filePath.Replace("Assets/" + AppConfig.GetResAppConfig().AssetsFolderName +
                                                       "/", "")) + " = ");
            content = content.Replace(FIELD_LIST_FLAG, fieldList);
            if (string.IsNullOrEmpty(""))
            {
                content = content.Replace(EXPLAIN_FLAG, "");
            }
            else
            {
                content = content.Replace(EXPLAIN_FLAG, _explainT.Replace(EXPLAIN_FLAG, ""));
            }

            return content;
        }

        string GenerateFieldList(string abName, string filePath)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(GenerateFiled("ABName", abName));
            sb.Append(GenerateFiled("filePath", filePath));
            // sb.AppendLine();

            // foreach (var viewName in viewNameList)
            // {
            //     string fieldName = Path.GetFileNameWithoutExtension(viewName);
            //     fieldName += "Key";
            //     sb.Append(GenerateFiled(fieldName, Path.GetFileNameWithoutExtension(viewName)));
            //     //添加全名
            //     var assetPath = EditorCommonUtil.LinkAssetPath(abNameWithoutExt, viewName);
            //     fieldName = Path.GetFileNameWithoutExtension(viewName);
            //     sb.Append(GenerateFiled(fieldName + "Path", assetPath));
            // }

            return sb.ToString();
        }

        string GenerateFiled(string fieldName, string fieldValue)
        {
            fieldName = MakeFieldNameRightful(fieldName);
            return _fieldT.Replace(FIELD_NAME_FLAG, fieldName).Replace(FIELD_VALUE_FLAG, fieldValue);
        }

        string MakeFieldNameRightful(string fieldName)
        {
            fieldName = fieldName.Replace(' ', '_').Replace("-", "_").Replace(".", "_").Replace("/", "_");
            var firstChar = fieldName[0];
            Regex regex = new Regex("[a-zA-Z_]");
            if (false == regex.IsMatch(firstChar.ToString()))
            {
                Debug.LogWarningFormat("「{0}」字段不是合法的(前缀已自动添加下划线): {1}", LuaFilePath, fieldName);
                fieldName = "_" + fieldName;
            }

            if (fieldName.IndexOf('.') > -1)
            {
                Debug.LogWarningFormat("「{0}」字段不是合法的(已自动替换'.'为'_'): {1}", LuaFilePath, fieldName);
                fieldName = fieldName.Replace('.', '_');
            }

            return fieldName;
            // return fieldName.ToUpper();
        }


        public static void Run()
        {
            new AssetBundlesToLua().Binding();
        }
    }
}