
using UnityEngine;

public class DataDecider : ChildBehavior
{
    [SerializeField] protected DataRelay dataRelay;
    [SerializeField] protected DataStore dataStore;
    protected DecisionNode behaviorTree;
    
    protected override void LoadComponentInParent()
    {
        base.LoadComponentInParent();
        this.LoadDataRelay();
    }

    protected override void LoadComponentInChild()
    {
        base.LoadComponentInChild();
        this.LoadDataStore();
    }

    protected virtual void LoadDataRelay()
    {
        if (dataRelay != null) return;
        dataRelay = transform.GetComponentInParent<DataRelay>();
    }

    protected virtual void LoadDataStore()
    {
        if (dataStore != null) return;
        dataStore = transform.GetComponentInChildren<DataStore>();
    }

    protected virtual void Update()
    {
        behaviorTree.Evaluate();
    }
    
}
