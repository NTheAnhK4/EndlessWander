using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLeg : EntityLeg
{
    [SerializeField] protected Vector3 direction;
    protected override void ResetValue()
    {
        base.ResetValue();
        walkSpeed = 10f;
    }

    public override void ReceiveSignal(object bodyPart, object eventType = null, object param = null)
    {
        legEvent = eventType;
        if (param is Vector3 vParam) direction = vParam;
    }

    protected override void Walk()
    {
        entity.Translate(direction * walkSpeed * Time.deltaTime);
    }
}
