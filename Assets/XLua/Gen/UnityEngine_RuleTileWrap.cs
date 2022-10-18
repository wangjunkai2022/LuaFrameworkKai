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
    public class UnityEngineRuleTileWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(UnityEngine.RuleTile);
			Utils.BeginObjectRegister(type, L, translator, 0, 13, 8, 4);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "UpdateNeighborPositions", _m_UpdateNeighborPositions);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "StartUp", _m_StartUp);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetTileData", _m_GetTileData);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetTileAnimationData", _m_GetTileAnimationData);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "RefreshTile", _m_RefreshTile);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "RuleMatches", _m_RuleMatches);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ApplyRandomTransform", _m_ApplyRandomTransform);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetCustomFields", _m_GetCustomFields);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "RuleMatch", _m_RuleMatch);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetRotatedPosition", _m_GetRotatedPosition);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetMirroredPosition", _m_GetMirroredPosition);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetOffsetPosition", _m_GetOffsetPosition);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetOffsetPositionReverse", _m_GetOffsetPositionReverse);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "m_NeighborType", _g_get_m_NeighborType);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "m_RotationAngle", _g_get_m_RotationAngle);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "m_RotationCount", _g_get_m_RotationCount);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "neighborPositions", _g_get_neighborPositions);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "m_DefaultSprite", _g_get_m_DefaultSprite);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "m_DefaultGameObject", _g_get_m_DefaultGameObject);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "m_DefaultColliderType", _g_get_m_DefaultColliderType);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "m_TilingRules", _g_get_m_TilingRules);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "m_DefaultSprite", _s_set_m_DefaultSprite);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "m_DefaultGameObject", _s_set_m_DefaultGameObject);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "m_DefaultColliderType", _s_set_m_DefaultColliderType);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "m_TilingRules", _s_set_m_TilingRules);
            
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 2, 0, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "GetPerlinValue", _m_GetPerlinValue_xlua_st_);
            
			
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					var gen_ret = new UnityEngine.RuleTile();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.RuleTile constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdateNeighborPositions(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.RuleTile gen_to_be_invoked = (UnityEngine.RuleTile)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.UpdateNeighborPositions(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_StartUp(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.RuleTile gen_to_be_invoked = (UnityEngine.RuleTile)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Vector3Int _position;translator.Get(L, 2, out _position);
                    UnityEngine.Tilemaps.ITilemap _tilemap = (UnityEngine.Tilemaps.ITilemap)translator.GetObject(L, 3, typeof(UnityEngine.Tilemaps.ITilemap));
                    UnityEngine.GameObject _instantiatedGameObject = (UnityEngine.GameObject)translator.GetObject(L, 4, typeof(UnityEngine.GameObject));
                    
                        var gen_ret = gen_to_be_invoked.StartUp( _position, _tilemap, _instantiatedGameObject );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetTileData(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.RuleTile gen_to_be_invoked = (UnityEngine.RuleTile)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Vector3Int _position;translator.Get(L, 2, out _position);
                    UnityEngine.Tilemaps.ITilemap _tilemap = (UnityEngine.Tilemaps.ITilemap)translator.GetObject(L, 3, typeof(UnityEngine.Tilemaps.ITilemap));
                    UnityEngine.Tilemaps.TileData _tileData;translator.Get(L, 4, out _tileData);
                    
                    gen_to_be_invoked.GetTileData( _position, _tilemap, ref _tileData );
                    translator.Push(L, _tileData);
                        translator.Update(L, 4, _tileData);
                        
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetPerlinValue_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Vector3Int _position;translator.Get(L, 1, out _position);
                    float _scale = (float)LuaAPI.lua_tonumber(L, 2);
                    float _offset = (float)LuaAPI.lua_tonumber(L, 3);
                    
                        var gen_ret = UnityEngine.RuleTile.GetPerlinValue( _position, _scale, _offset );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetTileAnimationData(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.RuleTile gen_to_be_invoked = (UnityEngine.RuleTile)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Vector3Int _position;translator.Get(L, 2, out _position);
                    UnityEngine.Tilemaps.ITilemap _tilemap = (UnityEngine.Tilemaps.ITilemap)translator.GetObject(L, 3, typeof(UnityEngine.Tilemaps.ITilemap));
                    UnityEngine.Tilemaps.TileAnimationData _tileAnimationData;translator.Get(L, 4, out _tileAnimationData);
                    
                        var gen_ret = gen_to_be_invoked.GetTileAnimationData( _position, _tilemap, ref _tileAnimationData );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    translator.Push(L, _tileAnimationData);
                        translator.Update(L, 4, _tileAnimationData);
                        
                    
                    
                    
                    return 2;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RefreshTile(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.RuleTile gen_to_be_invoked = (UnityEngine.RuleTile)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Vector3Int _position;translator.Get(L, 2, out _position);
                    UnityEngine.Tilemaps.ITilemap _tilemap = (UnityEngine.Tilemaps.ITilemap)translator.GetObject(L, 3, typeof(UnityEngine.Tilemaps.ITilemap));
                    
                    gen_to_be_invoked.RefreshTile( _position, _tilemap );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RuleMatches(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.RuleTile gen_to_be_invoked = (UnityEngine.RuleTile)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 5&& translator.Assignable<UnityEngine.RuleTile.TilingRule>(L, 2)&& translator.Assignable<UnityEngine.Vector3Int>(L, 3)&& translator.Assignable<UnityEngine.Tilemaps.ITilemap>(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)) 
                {
                    UnityEngine.RuleTile.TilingRule _rule = (UnityEngine.RuleTile.TilingRule)translator.GetObject(L, 2, typeof(UnityEngine.RuleTile.TilingRule));
                    UnityEngine.Vector3Int _position;translator.Get(L, 3, out _position);
                    UnityEngine.Tilemaps.ITilemap _tilemap = (UnityEngine.Tilemaps.ITilemap)translator.GetObject(L, 4, typeof(UnityEngine.Tilemaps.ITilemap));
                    int _angle = LuaAPI.xlua_tointeger(L, 5);
                    
                        var gen_ret = gen_to_be_invoked.RuleMatches( _rule, _position, _tilemap, _angle );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 6&& translator.Assignable<UnityEngine.RuleTile.TilingRule>(L, 2)&& translator.Assignable<UnityEngine.Vector3Int>(L, 3)&& translator.Assignable<UnityEngine.Tilemaps.ITilemap>(L, 4)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 5)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 6)) 
                {
                    UnityEngine.RuleTile.TilingRule _rule = (UnityEngine.RuleTile.TilingRule)translator.GetObject(L, 2, typeof(UnityEngine.RuleTile.TilingRule));
                    UnityEngine.Vector3Int _position;translator.Get(L, 3, out _position);
                    UnityEngine.Tilemaps.ITilemap _tilemap = (UnityEngine.Tilemaps.ITilemap)translator.GetObject(L, 4, typeof(UnityEngine.Tilemaps.ITilemap));
                    bool _mirrorX = LuaAPI.lua_toboolean(L, 5);
                    bool _mirrorY = LuaAPI.lua_toboolean(L, 6);
                    
                        var gen_ret = gen_to_be_invoked.RuleMatches( _rule, _position, _tilemap, _mirrorX, _mirrorY );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 5&& translator.Assignable<UnityEngine.RuleTile.TilingRule>(L, 2)&& translator.Assignable<UnityEngine.Vector3Int>(L, 3)&& translator.Assignable<UnityEngine.Tilemaps.ITilemap>(L, 4)&& translator.Assignable<UnityEngine.Matrix4x4>(L, 5)) 
                {
                    UnityEngine.RuleTile.TilingRule _rule = (UnityEngine.RuleTile.TilingRule)translator.GetObject(L, 2, typeof(UnityEngine.RuleTile.TilingRule));
                    UnityEngine.Vector3Int _position;translator.Get(L, 3, out _position);
                    UnityEngine.Tilemaps.ITilemap _tilemap = (UnityEngine.Tilemaps.ITilemap)translator.GetObject(L, 4, typeof(UnityEngine.Tilemaps.ITilemap));
                    UnityEngine.Matrix4x4 _transform;translator.Get(L, 5, out _transform);
                    
                        var gen_ret = gen_to_be_invoked.RuleMatches( _rule, _position, _tilemap, ref _transform );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    translator.Push(L, _transform);
                        translator.Update(L, 5, _transform);
                        
                    
                    
                    
                    return 2;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.RuleTile.RuleMatches!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ApplyRandomTransform(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.RuleTile gen_to_be_invoked = (UnityEngine.RuleTile)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.RuleTile.TilingRuleOutput.Transform _type;translator.Get(L, 2, out _type);
                    UnityEngine.Matrix4x4 _original;translator.Get(L, 3, out _original);
                    float _perlinScale = (float)LuaAPI.lua_tonumber(L, 4);
                    UnityEngine.Vector3Int _position;translator.Get(L, 5, out _position);
                    
                        var gen_ret = gen_to_be_invoked.ApplyRandomTransform( _type, _original, _perlinScale, _position );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetCustomFields(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.RuleTile gen_to_be_invoked = (UnityEngine.RuleTile)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    bool _isOverrideInstance = LuaAPI.lua_toboolean(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetCustomFields( _isOverrideInstance );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RuleMatch(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.RuleTile gen_to_be_invoked = (UnityEngine.RuleTile)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _neighbor = LuaAPI.xlua_tointeger(L, 2);
                    UnityEngine.Tilemaps.TileBase _other = (UnityEngine.Tilemaps.TileBase)translator.GetObject(L, 3, typeof(UnityEngine.Tilemaps.TileBase));
                    
                        var gen_ret = gen_to_be_invoked.RuleMatch( _neighbor, _other );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
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
            
            
                UnityEngine.RuleTile gen_to_be_invoked = (UnityEngine.RuleTile)translator.FastGetCSObj(L, 1);
            
            
                
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
            
            
                UnityEngine.RuleTile gen_to_be_invoked = (UnityEngine.RuleTile)translator.FastGetCSObj(L, 1);
            
            
                
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
        static int _m_GetOffsetPosition(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.RuleTile gen_to_be_invoked = (UnityEngine.RuleTile)translator.FastGetCSObj(L, 1);
            
            
                
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
            
            
                UnityEngine.RuleTile gen_to_be_invoked = (UnityEngine.RuleTile)translator.FastGetCSObj(L, 1);
            
            
                
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
        static int _g_get_m_NeighborType(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.RuleTile gen_to_be_invoked = (UnityEngine.RuleTile)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.m_NeighborType);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_RotationAngle(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.RuleTile gen_to_be_invoked = (UnityEngine.RuleTile)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.m_RotationAngle);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_RotationCount(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.RuleTile gen_to_be_invoked = (UnityEngine.RuleTile)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.m_RotationCount);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_neighborPositions(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.RuleTile gen_to_be_invoked = (UnityEngine.RuleTile)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.neighborPositions);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_DefaultSprite(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.RuleTile gen_to_be_invoked = (UnityEngine.RuleTile)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.m_DefaultSprite);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_DefaultGameObject(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.RuleTile gen_to_be_invoked = (UnityEngine.RuleTile)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.m_DefaultGameObject);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_DefaultColliderType(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.RuleTile gen_to_be_invoked = (UnityEngine.RuleTile)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.m_DefaultColliderType);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_TilingRules(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.RuleTile gen_to_be_invoked = (UnityEngine.RuleTile)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.m_TilingRules);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_DefaultSprite(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.RuleTile gen_to_be_invoked = (UnityEngine.RuleTile)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.m_DefaultSprite = (UnityEngine.Sprite)translator.GetObject(L, 2, typeof(UnityEngine.Sprite));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_DefaultGameObject(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.RuleTile gen_to_be_invoked = (UnityEngine.RuleTile)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.m_DefaultGameObject = (UnityEngine.GameObject)translator.GetObject(L, 2, typeof(UnityEngine.GameObject));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_DefaultColliderType(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.RuleTile gen_to_be_invoked = (UnityEngine.RuleTile)translator.FastGetCSObj(L, 1);
                UnityEngine.Tilemaps.Tile.ColliderType gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.m_DefaultColliderType = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_TilingRules(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.RuleTile gen_to_be_invoked = (UnityEngine.RuleTile)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.m_TilingRules = (System.Collections.Generic.List<UnityEngine.RuleTile.TilingRule>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<UnityEngine.RuleTile.TilingRule>));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
