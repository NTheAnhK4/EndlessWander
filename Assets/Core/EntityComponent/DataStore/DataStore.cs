
using System;
using System.Collections.Generic;
using UnityEngine;


public class DataStore : ChildBehavior
{
    
    protected readonly Dictionary<ComponentID, List<object>> dataSet = new Dictionary<ComponentID, List<object>>();
    [SerializeField] protected DataRelay dataRelay;
    protected override void LoadComponentInParent()
    {
        base.LoadComponentInParent();
        this.LoadDataRelay();
    }

    protected virtual void LoadDataRelay()
    {
        if (dataRelay != null) return;
        dataRelay = transform.GetComponentInParent<DataRelay>();
    }

    protected override void Start()
    {
        base.Start();
        dataRelay.ReceiveSignal(DProcID.DataCollection,DataCollection);
    }
    protected virtual void DataCollection(object data)
    {
        if (data is Tuple<ComponentID,object> signal)
        {
            StoreData(signal.Item1,signal.Item2);
        }
        else
        {
            Debug.Log("Type of signal is wrong");
        }
    }
    public void StoreData(ComponentID compId, object status)
    {
        dataSet.TryAdd(compId, new List<object>());
        dataSet[compId].Add(status);
    }
}
