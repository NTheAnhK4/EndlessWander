using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityEye : ChildBehavior,IEye
{
    [SerializeField] protected EntityNerve nerve;
    protected override void LoadComponentInParent()
    {
        base.LoadComponentInParent();
        this.LoadNerve();
    }

    protected virtual void LoadNerve()
    {
        if (nerve != null) return;
        nerve = transform.GetComponentInParent<EntityNerve>();
        if(nerve != null) 
            Debug.Log(transform.parent + " Load nerver successful");
    }
    public void ReceiveSignal(object bodyPart,object eventType = null, object param = null)
    {
        
    }
}
