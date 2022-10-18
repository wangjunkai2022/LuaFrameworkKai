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
    public class UnityEngineRuleTileTilingRuleWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(UnityEngine.RuleTile.TilingRule);
			Utils.BeginObjectRegister(type, L, translator, 0, 4, 3, 3);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Clone", _m_Clone);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetNeighbors", _m_GetNeighbors);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ApplyNeighbors", _m_ApplyNeighbors);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetBounds", _m_GetBounds);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "m_Neighbors", _g_get_m_Neighbors);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "m_NeighborPositions", _g_get_m_NeighborPositions);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "m_RuleTransform", _g_get_m_RuleTransform);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "m_Neighbors", _s_set_m_Neighbors);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "m_NeighborPositions", _s_set_m_NeighborPositions);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "m_RuleTransform", _s_set_m_RuleTransform);
            
			
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
					
					var gen_ret = new UnityEngine.RuleTile.TilingRule();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.RuleTile.TilingRule constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Clone(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.RuleTile.TilingRule gen_to_be_invoked = (UnityEngine.RuleTile.TilingRule)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        var gen_ret = gen_to_be_invoked.Clone(  );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetNeighbors(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.RuleTile.TilingRule gen_to_be_invoked = (UnityEngine.RuleTile.TilingRule)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        var gen_ret = gen_to_be_invoked.GetNeighbors(  );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ApplyNeighbors(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.RuleTile.TilingRule gen_to_be_invoked = (UnityEngine.RuleTile.TilingRule)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    System.Collections.Generic.Dictionary<UnityEngine.Vector3Int, int> _dict = (System.Collections.Generic.Dictionary<UnityEngine.Vector3Int, int>)translator.GetObject(L, 2, typeof(System.Collections.Generic.Dictionary<UnityEngine.Vector3Int, int>));
                    
                    gen_to_be_invoked.ApplyNeighbors( _dict );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetBounds(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.RuleTile.TilingRule gen_to_be_invoked = (UnityEngine.RuleTile.TilingRule)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        var gen_ret = gen_to_be_invoked.GetBounds(  );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_Neighbors(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.RuleTile.TilingRule gen_to_be_invoked = (UnityEngine.RuleTile.TilingRule)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.m_Neighbors);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_NeighborPositions(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.RuleTile.TilingRule gen_to_be_invoked = (UnityEngine.RuleTile.TilingRule)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.m_NeighborPositions);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_RuleTransform(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.RuleTile.TilingRule gen_to_be_invoked = (UnityEngine.RuleTile.TilingRule)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.m_RuleTransform);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_Neighbors(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.RuleTile.TilingRule gen_to_be_invoked = (UnityEngine.RuleTile.TilingRule)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.m_Neighbors = (System.Collections.Generic.List<int>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<int>));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_NeighborPositions(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.RuleTile.TilingRule gen_to_be_invoked = (UnityEngine.RuleTile.TilingRule)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.m_NeighborPositions = (System.Collections.Generic.List<UnityEngine.Vector3Int>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<UnityEngine.Vector3Int>));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_RuleTransform(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.RuleTile.TilingRule gen_to_be_invoked = (UnityEngine.RuleTile.TilingRule)translator.FastGetCSObj(L, 1);
                UnityEngine.RuleTile.TilingRuleOutput.Transform gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.m_RuleTransform = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
