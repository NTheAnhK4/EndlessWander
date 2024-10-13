using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadraticMovement : MovementBase
{
    [SerializeField] protected float quadraticCoefficien;
    [SerializeField] protected float linearCoefficient;
    [SerializeField] protected float x;
    [SerializeField] protected bool isVerticalMove;

    protected virtual float GetDerivative()
    {
        return 2 * quadraticCoefficien * x + linearCoefficient;
    }
    protected override Vector3 GetHorizontal()
    {
        return Vector3.right * (isVerticalMove ? 1 : GetDerivative());
    }

    protected override Vector3 GetVertical()
    {

        return Vector3.up * (isVerticalMove ? GetDerivative() : 1);
    }

    protected override void UpdateLogic()
    {
        x += Time.deltaTime;
        base.UpdateLogic();
    }

    protected override void ResetValue()
    {
        entity = transform;
        speed = 1f;
        quadraticCoefficien = 1;
        linearCoefficient = 1;
        x = -0.5f;
        isVerticalMove = true;
    }
}
