
using System.Collections.Generic;
using UnityEngine;


public class DataRelay : ParentBehavior
{
    protected readonly Dictionary<eCompID, EntityComponent> signalCentral = new Dictionary<eCompID, EntityComponent>();

    public void RegisterSignal(eCompID eID, EntityComponent eComponent)
    {
        signalCentral.TryAdd(eID, null);
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
