using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBase : ActionBase
{
    [SerializeField] protected Transform entity;
    [SerializeField] protected float speed;
    [SerializeField] protected Vector3 direction;

    protected virtual Vector3 GetHorizontal()
    {
        return Vector3.right;
    }

    protected virtual Vector3 GetVertical()
    {
        return Vector3.up;
    }

    protected virtual Vector3 GetDirection()
    {
        return (GetHorizontal() + GetVertical()) * speed;
    }

    protected override void UpdateLogic()
    {
        base.UpdateLogic();
        direction = GetDirection();
    }

    protected override void UpdatePhysis()
    {
        base.UpdatePhysis();
        entity.transform.Translate(direction * Time.deltaTime);
    }
}
