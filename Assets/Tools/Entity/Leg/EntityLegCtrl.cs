
using System.Collections.Generic;
using UnityEngine;
using Object = System.Object;


public class EntityLegCtrl : ChildBehavior,ILeg
{
    
   
    [SerializeField] protected EntityNerve nerve;
    [SerializeField] protected List<EntityLeg> legList;
    
    public EntityNerve Nerve => nerve;

   

    protected override void LoadComponentInParent()
    {
        base.LoadComponentInParent();
        this.LoadNerve();
    }

    protected override void LoadComponentInChild()
    {
        base.LoadComponentInChild();
        this.LoadLegs();
    }

    protected virtual void LoadLegs()
    {
        if(legList.Count != 0) return;
        foreach (Transform child in transform)
        {
            legList.Add(child.GetComponent<EntityLeg>());
        }
        Debug.Log(transform.parent.name + " Load legs successful");
    }
    protected virtual void LoadNerve()
    {
        if (nerve != null) return;
        nerve = transform.GetComponentInParent<EntityNerve>();
        if(nerve != null) 
            Debug.Log(transform.parent + " Load nerver successful");
    }
    public  virtual void ReceiveSignal(object bodyPart,object eventType = null, object param = null)
    {
        
    }

    
    
}
