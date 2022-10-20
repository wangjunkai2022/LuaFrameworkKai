using EditorAssetBundle;
using UnityEditor;

namespace ClientWindows
{
    public class ClientToolsMainWindow
    {
        [MenuItem("Tools/客户端工具集")]
        public static void Run()
        {
            // AutoBindingAssetBundle.Run(false);
            AssetBundlesToLua.Run();
            // AutoBindingAssetBundle.ClearAllAssetBundles();
        }
    }
}