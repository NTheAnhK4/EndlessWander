using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearMovement : MovementBase
{
    [SerializeField] protected float slope = 1;

    //y = slope * x
    protected override Vector3 GetVertical()
    {
        
        return slope * Vector3.up;
    }

    protected override Vector3 GetHorizontal()
    {
        return Vector3.right;
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        entity = transform.parent;
        slope = 0;
        speed = 2;

    }
}
