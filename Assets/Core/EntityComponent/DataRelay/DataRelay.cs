
using System.Collections.Generic;


public class DataRelay : ParentBehavior
{
    protected readonly Dictionary<eCompID, EntityComponent> signalCentral = new Dictionary<eCompID, EntityComponent>();

    public void RegisterSignal(eCompID eID, EntityComponent eComponent)
    {
        signalCentral[eID] = eComponent;
    }

    public T GetEntityComponent<T>(eCompID id) where T : EntityComponent
    {
        if (signalCentral.TryGetValue(id, out EntityComponent component))
        {
            return component as T;
        }
        return null;
    }
    
    
}
