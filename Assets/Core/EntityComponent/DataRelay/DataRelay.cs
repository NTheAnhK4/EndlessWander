using System;

using System.Collections.Generic;
using UnityEngine;


public class DataRelay : ParentBehavior
{
    
    protected readonly Dictionary<object, Action<object>> signalCentral = new Dictionary<object, Action<object>>();
    public void ReceiveSignal(object actionType, Action<object> callBack)
    {
        signalCentral.TryAdd(actionType, null);
        signalCentral[actionType] += callBack;
    } 
    public void ReceiveSignal(object actionType, Action action)
    {
        Action<object> wrappedAction = (obj) => action();
        ReceiveSignal(actionType, wrappedAction);
    }

    public void SendSignal(object actionType, object param = null)
    {
        if (!signalCentral.ContainsKey(actionType))
        {
            Debug.Log(actionType.GetType() + "does not be contained in signalCentral");
            return;
        }

        var callBacks = signalCentral[actionType];
        if (callBacks != null) callBacks(param);
        else
        {
            Debug.Log("No listener remain");
            signalCentral.Remove(actionType);
        }
    }

    public void CancelSingnal(object actionType, Action<object> callBack)
    {
        if (signalCentral.ContainsKey(actionType)) signalCentral[actionType] -= callBack;
    }
    
    
   
}
