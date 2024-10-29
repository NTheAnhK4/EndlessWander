
public class SignalNode : DecisionNode
{
    private DataRelay _dataRelay;
    private object _actionType;
    private object _value;
    public SignalNode(DataRelay dataRelay, object actionType, object value = null)
    {
        _dataRelay = dataRelay;
        _actionType = actionType;
        _value = value;
    }

    public override DecisionNodeStatus Evaluate()
    {
        _dataRelay.SendSignal(_actionType,_value);
        return DecisionNodeStatus.Running;
    }
}
