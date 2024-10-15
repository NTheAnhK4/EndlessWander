using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityEye : ChildBehavior,IEye
{
    [SerializeField] protected EntityNerve nerve;
    [SerializeField] protected Transform entity;
    [SerializeField] protected float vision;
    [SerializeField] protected Collider2D[] entityList;
    protected override void LoadComponentInParent()
    {
        base.LoadComponentInParent();
        this.LoadNerve();
        this.LoadEntity();
    }

    protected virtual void LoadEntity()
    {
        if (entity != null) return;
        entity = nerve.transform;
        if(entity != null)
            Debug.Log(entity.name + " Load entity successful");
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

    protected virtual void Scan()
    {
        entityList = Physics2D.OverlapCircleAll(entity.position, vision);
    }

    protected virtual void Update()
    {
        Scan();
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(entity.position, vision);
    }
}
