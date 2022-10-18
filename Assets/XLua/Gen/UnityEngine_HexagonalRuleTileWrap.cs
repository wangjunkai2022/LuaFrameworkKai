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
    public class UnityEngineHexagonalRuleTileWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(UnityEngine.HexagonalRuleTile);
			Utils.BeginObjectRegister(type, L, translator, 0, 4, 2, 1);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetOffsetPosition", _m_GetOffsetPosition);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetOffsetPositionReverse", _m_GetOffsetPositionReverse);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetRotatedPosition", _m_GetRotatedPosition);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetMirroredPosition", _m_GetMirroredPosition);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "m_RotationAngle", _g_get_m_RotationAngle);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "m_FlatTop", _g_get_m_FlatTop);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "m_FlatTop", _s_set_m_FlatTop);
            
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 3, 0, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "TilemapPositionToWorldPosition", _m_TilemapPositionToWorldPosition_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "WorldPositionToTilemapPosition", _m_WorldPositionToTilemapPosition_xlua_st_);
            
			
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					var gen_ret = new UnityEngine.HexagonalRuleTile();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.HexagonalRuleTile constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_TilemapPositionToWorldPosition_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Vector3Int _tilemapPosition;translator.Get(L, 1, out _tilemapPosition);
                    
                        var gen_ret = UnityEngine.HexagonalRuleTile.TilemapPositionToWorldPosition( _tilemapPosition );
                        translator.PushUnityEngineVector3(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_WorldPositionToTilemapPosition_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Vector3 _worldPosition;translator.Get(L, 1, out _worldPosition);
                    
                        var gen_ret = UnityEngine.HexagonalRuleTile.WorldPositionToTilemapPosition( _worldPosition );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetOffsetPosition(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.HexagonalRuleTile gen_to_be_invoked = (UnityEngine.HexagonalRuleTile)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Vector3Int _position;translator.Get(L, 2, out _position);
                    UnityEngine.Vector3Int _offset;translator.Get(L, 3, out _offset);
                    
                        var gen_ret = gen_to_be_invoked.GetOffsetPosition( _position, _offset );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetOffsetPositionReverse(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.HexagonalRuleTile gen_to_be_invoked = (UnityEngine.HexagonalRuleTile)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Vector3Int _position;translator.Get(L, 2, out _position);
                    UnityEngine.Vector3Int _offset;translator.Get(L, 3, out _offset);
                    
                        var gen_ret = gen_to_be_invoked.GetOffsetPositionReverse( _position, _offset );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetRotatedPosition(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.HexagonalRuleTile gen_to_be_invoked = (UnityEngine.HexagonalRuleTile)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Vector3Int _position;translator.Get(L, 2, out _position);
                    int _rotation = LuaAPI.xlua_tointeger(L, 3);
                    
                        var gen_ret = gen_to_be_invoked.GetRotatedPosition( _position, _rotation );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetMirroredPosition(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.HexagonalRuleTile gen_to_be_invoked = (UnityEngine.HexagonalRuleTile)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Vector3Int _position;translator.Get(L, 2, out _position);
                    bool _mirrorX = LuaAPI.lua_toboolean(L, 3);
                    bool _mirrorY = LuaAPI.lua_toboolean(L, 4);
                    
                        var gen_ret = gen_to_be_invoked.GetMirroredPosition( _position, _mirrorX, _mirrorY );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_RotationAngle(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.HexagonalRuleTile gen_to_be_invoked = (UnityEngine.HexagonalRuleTile)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.m_RotationAngle);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_FlatTop(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.HexagonalRuleTile gen_to_be_invoked = (UnityEngine.HexagonalRuleTile)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.m_FlatTop);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_FlatTop(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.HexagonalRuleTile gen_to_be_invoked = (UnityEngine.HexagonalRuleTile)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.m_FlatTop = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
