using UnityEngine;
using UnityEngine.Events;


namespace MBT
{
    [System.Serializable]
    public class NodeResultEvent : UnityEvent<FunctionCallerNode> { }
    [AddComponentMenu("")]
    [MBTNode("Tasks/Function Caller")]
    public class FunctionCallerNode : Leaf
    {
        public NodeResultEvent onCallFunction;
        public NodeResult Result { get; set; } = NodeResult.failure;
        public override NodeResult Execute()
        {
            if (onCallFunction != null)
            {
                Result = NodeResult.failure;
                onCallFunction.Invoke(this); 
                return Result; 
            }
            return NodeResult.failure; 
        }

        
    }
}