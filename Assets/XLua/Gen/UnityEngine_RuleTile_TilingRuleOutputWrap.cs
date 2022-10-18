#if USE_UNI_LUA
using LuaAPI = UniLua.Lua;
using RealStatePtr = UniLua.ILuaState;
using LuaCSFunction = UniLua.CSharpFunctionDelegate;
#else
using LuaAPI = XLua.LuaDLL.Lua;
using RealStatePtr = System.IntPtr;
using LuaCSFunction = XLua.LuaDLL.lua_CSFunction;
#endif

using XLua;
using System.Collections.Generic;


namespace XLua.CSObjectWrap
{
    using Utils = XLua.Utils;
    public class UnityEngineRuleTileTilingRuleOutputWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(UnityEngine.RuleTile.TilingRuleOutput);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 9, 9);
			
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "m_Id", _g_get_m_Id);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "m_Sprites", _g_get_m_Sprites);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "m_GameObject", _g_get_m_GameObject);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "m_MinAnimationSpeed", _g_get_m_MinAnimationSpeed);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "m_MaxAnimationSpeed", _g_get_m_MaxAnimationSpeed);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "m_PerlinScale", _g_get_m_PerlinScale);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "m_Output", _g_get_m_Output);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "m_ColliderType", _g_get_m_ColliderType);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "m_RandomTransform", _g_get_m_RandomTransform);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "m_Id", _s_set_m_Id);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "m_Sprites", _s_set_m_Sprites);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "m_GameObject", _s_set_m_GameObject);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "m_MinAnimationSpeed", _s_set_m_MinAnimationSpeed);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "m_MaxAnimationSpeed", _s_set_m_MaxAnimationSpeed);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "m_PerlinScale", _s_set_m_PerlinScale);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "m_Output", _s_set_m_Output);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "m_ColliderType", _s_set_m_ColliderType);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "m_RandomTransform", _s_set_m_RandomTransform);
            
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 1, 0, 0);
			
			
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					var gen_ret = new UnityEngine.RuleTile.TilingRuleOutput();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.RuleTile.TilingRuleOutput constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_Id(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.RuleTile.TilingRuleOutput gen_to_be_invoked = (UnityEngine.RuleTile.TilingRuleOutput)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.m_Id);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_Sprites(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.RuleTile.TilingRuleOutput gen_to_be_invoked = (UnityEngine.RuleTile.TilingRuleOutput)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.m_Sprites);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_GameObject(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.RuleTile.TilingRuleOutput gen_to_be_invoked = (UnityEngine.RuleTile.TilingRuleOutput)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.m_GameObject);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_MinAnimationSpeed(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.RuleTile.TilingRuleOutput gen_to_be_invoked = (UnityEngine.RuleTile.TilingRuleOutput)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.m_MinAnimationSpeed);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_MaxAnimationSpeed(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.RuleTile.TilingRuleOutput gen_to_be_invoked = (UnityEngine.RuleTile.TilingRuleOutput)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.m_MaxAnimationSpeed);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_PerlinScale(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.RuleTile.TilingRuleOutput gen_to_be_invoked = (UnityEngine.RuleTile.TilingRuleOutput)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.m_PerlinScale);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_Output(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.RuleTile.TilingRuleOutput gen_to_be_invoked = (UnityEngine.RuleTile.TilingRuleOutput)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.m_Output);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_ColliderType(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.RuleTile.TilingRuleOutput gen_to_be_invoked = (UnityEngine.RuleTile.TilingRuleOutput)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.m_ColliderType);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_RandomTransform(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.RuleTile.TilingRuleOutput gen_to_be_invoked = (UnityEngine.RuleTile.TilingRuleOutput)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.m_RandomTransform);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_Id(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.RuleTile.TilingRuleOutput gen_to_be_invoked = (UnityEngine.RuleTile.TilingRuleOutput)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.m_Id = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_Sprites(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.RuleTile.TilingRuleOutput gen_to_be_invoked = (UnityEngine.RuleTile.TilingRuleOutput)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.m_Sprites = (UnityEngine.Sprite[])translator.GetObject(L, 2, typeof(UnityEngine.Sprite[]));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_GameObject(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.RuleTile.TilingRuleOutput gen_to_be_invoked = (UnityEngine.RuleTile.TilingRuleOutput)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.m_GameObject = (UnityEngine.GameObject)translator.GetObject(L, 2, typeof(UnityEngine.GameObject));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_MinAnimationSpeed(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.RuleTile.TilingRuleOutput gen_to_be_invoked = (UnityEngine.RuleTile.TilingRuleOutput)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.m_MinAnimationSpeed = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_MaxAnimationSpeed(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.RuleTile.TilingRuleOutput gen_to_be_invoked = (UnityEngine.RuleTile.TilingRuleOutput)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.m_MaxAnimationSpeed = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_PerlinScale(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.RuleTile.TilingRuleOutput gen_to_be_invoked = (UnityEngine.RuleTile.TilingRuleOutput)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.m_PerlinScale = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_Output(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.RuleTile.TilingRuleOutput gen_to_be_invoked = (UnityEngine.RuleTile.TilingRuleOutput)translator.FastGetCSObj(L, 1);
                UnityEngine.RuleTile.TilingRuleOutput.OutputSprite gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.m_Output = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_ColliderType(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.RuleTile.TilingRuleOutput gen_to_be_invoked = (UnityEngine.RuleTile.TilingRuleOutput)translator.FastGetCSObj(L, 1);
                UnityEngine.Tilemaps.Tile.ColliderType gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.m_ColliderType = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_RandomTransform(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.RuleTile.TilingRuleOutput gen_to_be_invoked = (UnityEngine.RuleTile.TilingRuleOutput)translator.FastGetCSObj(L, 1);
                UnityEngine.RuleTile.TilingRuleOutput.Transform gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.m_RandomTransform = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
