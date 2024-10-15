
public interface IBrain : IEntity{
    protected void OnThinking(object bodyPart, object eventType = null, object param = null)
    {
        
    }

    protected virtual void OnProcessSignal()
    {
        
    }
}
