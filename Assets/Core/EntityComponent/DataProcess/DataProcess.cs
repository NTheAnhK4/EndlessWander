
using UnityEngine;

public class DataProcess : ChildBehavior
{
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

    
        
}
