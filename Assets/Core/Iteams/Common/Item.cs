using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : ChildBehavior
{
    [SerializeField] protected Transform user;
    public abstract void Execute(object value = null);
    public abstract bool CanUse(object param = null);

    protected override void LoadComponentInParent()
    {
        base.LoadComponentInParent();
        user = transform.parent.name.Equals("Inventory") ? transform.parent.parent.parent : transform.parent.parent;
    }
}
