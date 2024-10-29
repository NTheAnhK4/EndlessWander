using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FDataDecider : DataDecider
{
    protected override void ResetValue()
    {
        base.ResetValue();
        behaviorTree = new Selector(
            new List<DecisionNode>()
            {
                new SignalNode(dataRelay,MoveActionID.Auto),
            }
        );
        
    }
}
