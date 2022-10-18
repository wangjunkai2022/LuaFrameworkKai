using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using XLua;

namespace Editor.Xlua
{
    public static class XluaConfig
    {
        /***************如果你全lua编程，可以参考这份自动化配置***************/
        //--------------begin 纯lua编程配置参考----------------------------
        static List<string> exclude = new List<string>
        {
            "HideInInspector", "ExecuteInEditMode",
            "AddComponentMenu", "ContextMenu",
            "RequireComponent", "DisallowMultipleComponent",
            "SerializeField", "AssemblyIsEditorAssembly",
            "Attribute", "Types",
            "UnitySurrogateSelector", "TrackedReference",
            "TypeInferenceRules", "FFTWindow",
            "RPC", "Network", "MasterServer",
            "BitStream", "HostData",
            "ConnectionTesterStatus", "GUI", "EventType",
            "EventModifiers", "FontStyle", "TextAlignment",
            "TextEditor", "TextEditorDblClickSnapping",
            "TextGenerator", "TextClipping", "Gizmos",
            "ADBannerView", "ADInterstitialAd",
            "Android", "Tizen", "jvalue",
            "iPhone", "iOS", "Windows", "CalendarIdentifier",
            "CalendarUnit", "CalendarUnit",
            "ClusterInput", "FullScreenMovieControlMode",
            "FullScreenMovieScalingMode", "Handheld",
            "LocalNotification", "NotificationServices",
            "RemoteNotificationType", "RemoteNotification",
            "SamsungTV", "TextureCompressionQuality",
            "TouchScreenKeyboardType", "TouchScreenKeyboard",
            "MovieTexture", "UnityEngineInternal",
            "Terrain", "Tree", "SplatPrototype",
            "DetailPrototype", "DetailRenderMode",
            "MeshSubsetCombineUtility", "AOT", "Social", "Enumerator",
            "SendMouseEvents", "Cursor", "Flash", "ActionScript",
            "OnRequestRebuild", "Ping",
            "ShaderVariantCollection", "SimpleJson.Reflection",
            "CoroutineTween", "GraphicRebuildTracker",
            "Advertisements", "UnityEditor", "WSA",
            "EventProvider", "Apple",
            "ClusterInput", "Motion",
            "UnityEngine.UI.ReflectionMethodsCache", "NativeLeakDetection",
            "NativeLeakDetectionMode", "WWWAudioExtensions", "UnityEngine.Experimental",
#if UNITY_STANDALONE || UNITY_STANDALONE_OSX || PLATFORM_STANDALONE || UNITY_STANDALONE_OSX
            "UnityEngine.DrivenRectTransformTracker",
            "UnityEngine.LightingSettings",
#endif
#if UNITY_ANDROID || PLATFORM_ANDROID || UNITY_IOS || IOS || UNITY_WEBGL || PLATFORM_WEBGL
            "UnityEngine.ClusterSerialization",

            "UnityEngine.DrivenRectTransformTracker",
            "UnityEngine.LightingSettings",
#endif
#if UNITY_WEBGL || PLATFORM_WEBGL
            "UnityEngine.Microphone",
#endif
        };

        static bool isExcluded(Type type)
        {
            var fullName = type.FullName;
            for (int i = 0; i < exclude.Count; i++)
            {
                if (fullName.Contains(exclude[i]))
                {
                    return true;
                }
            }

            return false;
        }

        [LuaCallCSharp]
        public static IEnumerable<Type> LuaCallCSharp
        {
            get
            {
                List<string> namespaces = new List<string>() // 在这里添加名字空间
                {
                    "UnityEngine",
                    "UnityEngine.UI"
                };
                var unityTypes = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                    where !(assembly.ManifestModule is System.Reflection.Emit.ModuleBuilder)
                    from type in assembly.GetExportedTypes()
                    where type.Namespace != null && namespaces.Contains(type.Namespace) && !isExcluded(type)
                          && type.BaseType != typeof(MulticastDelegate) && !type.IsInterface && !type.IsEnum
                    select type);

                string[] customAssemblys = new string[]
                {
                    "Assembly-CSharp",
                };
                var customTypes = (from assembly in customAssemblys.Select(s => Assembly.Load(s))
                    from type in assembly.GetExportedTypes()
                    where type.Namespace == null || !type.Namespace.StartsWith("XLua")
                        && type.BaseType != typeof(MulticastDelegate) && !type.IsInterface && !type.IsEnum
                    select type);
                return unityTypes.Concat(customTypes);
            }
        }

        //自动把LuaCallCSharp涉及到的delegate加到CSharpCallLua列表，后续可以直接用lua函数做callback
        [CSharpCallLua]
        public static List<Type> CSharpCallLua
        {
            get
            {
                var lua_call_csharp = LuaCallCSharp;
                var delegate_types = new List<Type>();
                var flag = BindingFlags.Public | BindingFlags.Instance
                                               | BindingFlags.Static | BindingFlags.IgnoreCase |
                                               BindingFlags.DeclaredOnly;
                foreach (var field in (from type in lua_call_csharp select type).SelectMany(
                    type => type.GetFields(flag)))
                {
                    if (typeof(Delegate).IsAssignableFrom(field.FieldType))
                    {
                        delegate_types.Add(field.FieldType);
                    }
                }

                foreach (var method in (from type in lua_call_csharp select type).SelectMany(type =>
                    type.GetMethods(flag)))
                {
                    if (typeof(Delegate).IsAssignableFrom(method.ReturnType))
                    {
                        delegate_types.Add(method.ReturnType);
                    }

                    foreach (var param in method.GetParameters())
                    {
                        var paramType = param.ParameterType.IsByRef
                            ? param.ParameterType.GetElementType()
                            : param.ParameterType;
                        if (typeof(Delegate).IsAssignableFrom(paramType))
                        {
                            delegate_types.Add(paramType);
                        }
                    }
                }

                return delegate_types.Where(t =>
                        t.BaseType == typeof(MulticastDelegate) && !hasGenericParameter(t) && !delegateHasEditorRef(t))
                    .Distinct().ToList();
            }
        }
        //--------------end 纯lua编程配置参考----------------------------

        /***************热补丁可以参考这份自动化配置***************/
        [Hotfix]
        static IEnumerable<Type> HotfixInject
        {
            get
            {
                return (from type in Assembly.Load("Assembly-CSharp").GetTypes()
                    where type.Namespace == null || !type.Namespace.StartsWith("XLua")
                    select type);
            }
        }

        // --------------begin 热补丁自动化配置-------------------------
        static bool hasGenericParameter(Type type)
        {
            if (type.IsGenericTypeDefinition) return true;
            if (type.IsGenericParameter) return true;
            if (type.IsByRef || type.IsArray)
            {
                return hasGenericParameter(type.GetElementType());
            }

            if (type.IsGenericType)
            {
                foreach (var typeArg in type.GetGenericArguments())
                {
                    if (hasGenericParameter(typeArg))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        static bool typeHasEditorRef(Type type)
        {
            if (type.Namespace != null &&
                (type.Namespace == "UnityEditor" || type.Namespace.StartsWith("UnityEditor.")))
            {
                return true;
            }

            if (type.IsNested)
            {
                return typeHasEditorRef(type.DeclaringType);
            }

            if (type.IsByRef || type.IsArray)
            {
                return typeHasEditorRef(type.GetElementType());
            }

            if (type.IsGenericType)
            {
                foreach (var typeArg in type.GetGenericArguments())
                {
                    if (typeArg.IsGenericParameter)
                    {
                        //skip unsigned type parameter
                        continue;
                    }

                    if (typeHasEditorRef(typeArg))
                    {
                        return true;
                    }
                }
            }

// #if UNITY_STANDALONE || UNITY_STANDALONE_OSX || PLATFORM_STANDALONE || UNITY_STANDALONE_OSX || UNITY_ANDROID || PLATFORM_ANDROID || UNITY_IOS || PLATFORM_IOS
            if (type.FullName != null && type.FullName.Contains("<"))
            {
                return true;
            }

            if (type.FullName != null && type.FullName.Contains("CanvasRenderer"))
            {
                return true;
            }
// #endif

            return false;
        }

        static bool delegateHasEditorRef(Type delegateType)
        {
            if (typeHasEditorRef(delegateType)) return true;
            var method = delegateType.GetMethod("Invoke");
            if (method == null)
            {
                return false;
            }

            if (typeHasEditorRef(method.ReturnType)) return true;
            return method.GetParameters().Any(pinfo => typeHasEditorRef(pinfo.ParameterType));
        }

        // 配置某Assembly下所有涉及到的delegate到CSharpCallLua下，Hotfix下拿不准那些delegate需要适配到lua function可以这么配置
        [CSharpCallLua]
        static IEnumerable<Type> AllDelegate
        {
            get
            {
                BindingFlags flag = BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static |
                                    BindingFlags.Public;
                List<Type> allTypes = new List<Type>();
                var allAssemblys = new Assembly[]
                {
                    Assembly.Load("Assembly-CSharp")
                };
                foreach (var t in (from assembly in allAssemblys from type in assembly.GetTypes() select type))
                {
                    var p = t;
                    while (p != null)
                    {
                        allTypes.Add(p);
                        p = p.BaseType;
                    }
                }

                allTypes = allTypes.Distinct().ToList();
                var allMethods = from type in allTypes
                    from method in type.GetMethods(flag)
                    select method;
                var returnTypes = from method in allMethods
                    select method.ReturnType;
                var paramTypes = allMethods.SelectMany(m => m.GetParameters()).Select(pinfo =>
                    pinfo.ParameterType.IsByRef ? pinfo.ParameterType.GetElementType() : pinfo.ParameterType);
                var fieldTypes = from type in allTypes
                    from field in type.GetFields(flag)
                    select field.FieldType;
                return (returnTypes.Concat(paramTypes).Concat(fieldTypes)).Where(t =>
                        t.BaseType == typeof(MulticastDelegate) && !hasGenericParameter(t) && !delegateHasEditorRef(t))
                    .Distinct();
            }
        }
        //--------------end 热补丁自动化配置-------------------------


        //黑名单
        [BlackList] public static List<List<string>> BlackList = new List<List<string>>()
        {
#if !UNITY_ANDROID && !PLATFORM_ANDROID
            new List<string>() {"UnityEngine.Light", "SetLightDirty",},
            new List<string>() {"UnityEngine.Light", "shadowRadius",},
            new List<string>() {"UnityEngine.Light", "shadowAngle",},
#endif
#if !IOS && !UNITY_IOS
            new List<string>() {"UnityEngine.Caching", "SetNoBackupFlag", "UnityEngine.CachedAssetBundle",},
            new List<string>() {"UnityEngine.Caching", "SetNoBackupFlag", "System.String", "UnityEngine.Hash128",},
            new List<string>() {"UnityEngine.Caching", "ResetNoBackupFlag", "UnityEngine.CachedAssetBundle",},
            new List<string>() {"UnityEngine.Caching", "ResetNoBackupFlag", "System.String", "UnityEngine.Hash128",},
#endif
            new List<string>() {"UnityEngine.AudioSettings", "GetSpatializerPluginNames",},
            new List<string>() {"UnityEngine.AudioSettings", "SetSpatializerPluginName", "System.String",},
            new List<string>() {"UnityEngine.AudioSource", "PlayOnGamepad", "System.Int32",},
            new List<string>() {"UnityEngine.AudioSource", "DisableGamepadOutput",},
            new List<string>()
                {"UnityEngine.AudioSource", "SetGamepadSpeakerMixLevel", "System.Int32", "System.Int32",},
            new List<string>() {"UnityEngine.AudioSource", "SetGamepadSpeakerMixLevelDefault", "System.Int32"},
            new List<string>()
                {"UnityEngine.AudioSource", "SetGamepadSpeakerRestrictedAudio", "System.Int32", "System.Boolean",},
            new List<string>()
            {
                "UnityEngine.AudioSource", "GamepadSpeakerSupportsOutputType", "UnityEngine.GamepadSpeakerOutputType",
            },
            new List<string>() {"UnityEngine.AudioSource", "gamepadSpeakerOutputType",},
            new List<string>() {"UnityEngine.Input", "IsJoystickPreconfigured", "System.String"},
            new List<string>() {"UnityEngine.LightProbeGroup", "dering",},
            new List<string>() {"UnityEngine.LightProbeGroup", "probePositions",},
            new List<string>() {"UnityEngine.Texture", "imageContentsHash",},

            new List<string>() {"UnityEngine.ParticleSystemRenderer", "supportsMeshInstancing",},
            new List<string>() {"UnityEngine.UI.DefaultControls", "factory",},
            new List<string>() {"UnityEngine.UI.Graphic", "OnRebuildRequested",},
            new List<string>() {"UnityEngine.UI.Text", "OnRebuildRequested",},
            new List<string>() {"UnityEngine.AnimatorControllerParameter", "name",},
            new List<string>() {"UnityEngine.MeshRenderer", "scaleInLightmap",},
            new List<string>() {"UnityEngine.MeshRenderer", "receiveGI",},
            new List<string>() {"UnityEngine.MeshRenderer", "stitchLightmapSeams",},

            new List<string>() {"UnityEngine.ParticleSystemForceField", "FindAll",},
        };
    }
}