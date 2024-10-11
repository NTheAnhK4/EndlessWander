using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityMovement : ChildBehavior
{
    [SerializeField] protected Transform entity;
    [SerializeField] protected float speed;
    [SerializeField] protected Vector3 direction;
    

    protected abstract Vector3 GetHorizontal();

    protected abstract Vector3 GetVertical();

    protected virtual Vector3 GetDirection()
    {
        return (GetHorizontal() + GetVertical()) * speed;
    }

    protected virtual void Update()
    {
        direction = GetDirection();
        entity.transform.Translate(direction * Time.deltaTime);
    }
}

