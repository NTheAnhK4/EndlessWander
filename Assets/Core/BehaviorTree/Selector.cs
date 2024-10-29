
using System.Collections.Generic;

public class Selector : DecisionNode
{
   // select one action to execute
   private List<DecisionNode> _children;

    public Selector(List<DecisionNode> children)
    {
        _children = children;
    }

    public override DecisionNodeStatus Evaluate()
    {
        foreach (var child in _children)
        {
            DecisionNodeStatus status = child.Evaluate();
            if (status != DecisionNodeStatus.Failure) return status;
        }

        return DecisionNodeStatus.Failure;
    }
}
