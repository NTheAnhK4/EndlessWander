
using System;
using UnityEngine;
using Random = UnityEngine.Random;


public class EntityLeg : ChildBehavior, ILeg
{
    [SerializeField] protected Transform target;
    [SerializeField] protected EntityLegCtrl legCtrl;
    [SerializeField] protected Transform entity;
    [SerializeField] protected float walkSpeed = 1f;
    [SerializeField] protected object legEvent;
    

    protected override void ResetValue()
    {
        base.ResetValue();
        walkSpeed = 2;
       
    }

    protected override void LoadComponentInParent()
    {
        base.LoadComponentInParent();
        this.LoadLegCtrl();
        this.LoadEntity();
    }

    protected virtual void LoadLegCtrl()
    {
        if(legCtrl != null) return;
        legCtrl = transform.GetComponentInParent<EntityLegCtrl>();
        if(legCtrl != null) Debug.Log(transform.parent.parent.name + " Load leg ctrl successful");
    }

    protected virtual void LoadEntity()
    {
        if(entity != null) return;
        entity = legCtrl.Nerve.transform;
        Debug.Log(transform.parent.parent.name + " Load entity successful");
    }

    public virtual void ReceiveSignal(object bodyPart,object eventType = null, object param = null)
    {
        
    }

    protected virtual void Stand()
    {
        
    }

    protected virtual void Walk()
    {
        if (target != null) WalkToTarget();
        else WalkRandom();
    }

    protected virtual void WalkToTarget()
    {
        Vector3 direction = (target.position - entity.position).normalized;
        entity.Translate(direction * walkSpeed * Time.deltaTime);
    }
    
    protected virtual void WalkRandom()
    {
        
    }

    protected virtual void Update()
    {
        if (legEvent is MainLegEvent mainLeg)
        {
            switch (mainLeg)
            {
                case MainLegEvent.Walk:
                    Walk();
                    break;
            }
        }
    }
}
