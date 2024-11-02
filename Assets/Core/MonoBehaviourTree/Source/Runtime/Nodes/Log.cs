using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MBT
{
    [AddComponentMenu("")]
    [MBTNode(name = "Tasks/Log")]
    public class Log : Leaf
    {
        public string Comment;
        public string Text;
        public bool LogError;
        public override NodeResult Execute()
        {
            if(Text != String.Empty) Debug.Log(Text);
            return NodeResult.success;
        }
    }
}
