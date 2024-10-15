


public interface IEntity 
{
   

    public void ReceiveSignal(object bodyPart,object eventType = null, object param = null)
    {
        
    }
}

public enum BodyPart
{
    Brain,
    Hand,
    Leg,
    MainLeg,
    Eye,
    Body
    
}
