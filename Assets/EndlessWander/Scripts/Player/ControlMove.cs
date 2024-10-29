using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMove : ChildBehavior
{
    [SerializeField] protected DataRelay dataRelay;
    [SerializeField] protected Transform player;
    [SerializeField] protected float speed = 5f;
    protected override void LoadComponentInParent()
    {
        base.LoadComponentInParent();
        this.LoadDataRelay();
        this.LoadPlayer();
    }

    protected virtual void LoadDataRelay()
    {
        if(dataRelay != null) return;
        dataRelay = transform.GetComponentInParent<DataRelay>();
    }

    protected virtual void LoadPlayer()
    {
        if (player != null) return;
        player = dataRelay.transform;
    }

    protected Vector3 GetDirection()
    {
        return InputManager.Instance.GetHorizontal() + InputManager.Instance.GetVertical();
    }
    private void Update()
    {
        Vector3 direction = GetDirection();
        player.transform.Translate(direction * speed * Time.deltaTime);
    }
}
