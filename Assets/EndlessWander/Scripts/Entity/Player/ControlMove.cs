using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMove : EntityComponent
{

    [SerializeField] protected Transform entity;
    [SerializeField] protected float speed = 5f;
    protected override void RegisterSignal()
    {
        base.RegisterSignal();
        dataRelay.RegisterSignal(eCompID.AutoMove,this);
    }

    protected override void LoadComponentInParent()
    {
        base.LoadComponentInParent();
        this.LoadEntity();
    }

    protected void LoadEntity()
    {
        if (entity != null) return;
        entity = dataRelay.transform;
    }

    protected Vector3 GetDirection()
    {
        return InputManager.Instance.GetHorizontal() + InputManager.Instance.GetVertical();
    }

    private void Update()
    {
        Vector3 direction = GetDirection();
        entity.Translate(direction * speed * Time.deltaTime);
    }
}
