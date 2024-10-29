
using System.Collections.Generic;


public class Sequence : DecisionNode
{
    private List<DecisionNode> _children;

    public Sequence(List<DecisionNode> children)
    {
        _children = children;
    }

    public override DecisionNodeStatus Evaluate()
    {
        foreach (var child in _children)
        { 
            DecisionNodeStatus status = child.Evaluate();
            if (status != DecisionNodeStatus.Success) return status;
        }

        return DecisionNodeStatus.Success;
    }
}
