using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityBrain : ChildBehavior, IBrain
{
    /// <summary>
    /// used to process signal
    /// </summary>
    [SerializeField] protected EntityNerve nerve;
    [SerializeField] protected List<string> signalList;
    protected override void LoadComponentInParent()
    {
        base.LoadComponentInParent();
        this.LoadNerve();
    }

    protected virtual void LoadNerve()
    {
        if(nerve != null) return;
        nerve = transform.GetComponentInParent<EntityNerve>();
        if(nerve != null)
            Debug.Log(transform.parent.name + " Load nerve successful");
    }
    public virtual void ReceiveSignal(object bodyPart,object eventType = null, object param = null)
    {
        
    }

    protected virtual void OnThinking(object bodyPart, object eventType = null, object param = null)
    {
        
    }

    

   
}
