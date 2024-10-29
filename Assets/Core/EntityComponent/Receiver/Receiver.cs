using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Receiver : ChildBehavior
{
    [SerializeField] protected HealthManager healthManager;
    protected override void LoadComponentInChild()
    {
        base.LoadComponentInChild();
        this.LoadHealthManager();
    }

    protected virtual void LoadHealthManager()
    {
        if (healthManager != null) return;
        healthManager = transform.GetComponentInChildren<HealthManager>();
    }
}
