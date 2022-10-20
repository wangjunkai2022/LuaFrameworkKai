using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace BuildPackages.Channel
{
    public class ChannelObject
    {
        [ShowInInspector] [LabelText("渠道名字")] public string name = String.Empty;
    }
    
    [CreateAssetMenu]
    public class ChannelConfig : ScriptableObject
    {
        [ShowInInspector, LabelText("所有的渠道集合")]
        public ChannelObject list;

        public ChannelConfig()
        {
            list = new ChannelObject();
        }
    }
}