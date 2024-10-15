using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityHandCtrl : ChildBehavior, IHand
{
    [SerializeField] protected List<EntityHand> handList;
    [SerializeField] protected EntityNerve nerve;
    protected override void LoadComponentInChild()
    {
        base.LoadComponentInChild();
        this.LoadHands();
    }

    protected override void LoadComponentInParent()
    {
        base.LoadComponentInParent();
        this.LoadNerve();
    }

    protected virtual void LoadHands()
    {
        if (handList.Count != 0) return;
        foreach (Transform child in transform)
        {
            handList.Add(child.GetComponent<EntityHand>());
        }
        Debug.Log(transform.parent + " Load hands successful");
    }

    protected virtual void LoadNerve()
    {
        if(nerve != null) return;
        nerve = transform.GetComponentInParent<EntityNerve>();
        if(nerve != null)
            Debug.Log(transform.parent + " Load nerve successful");
    }
    public void ReceiveSignal(object bodyPart,object eventType = null, object param = null)
    {
        
    }
}
