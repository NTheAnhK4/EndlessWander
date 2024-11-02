
using UnityEngine;

public class EntityComponent : ChildBehavior
{
    [SerializeField] protected DataRelay dataRelay;
    protected override void LoadComponentInParent()
    {
        base.LoadComponentInParent();
        this.LoadDataRelay();
        this.RegisterSignal();
    }

    protected void LoadDataRelay()
    {
        if (dataRelay != null) return;
        dataRelay = transform.GetComponentInParent<DataRelay>();
    }

    protected virtual void RegisterSignal()
    {
        
    }
    
}
