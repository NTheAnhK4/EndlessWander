using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBrain : EntityBrain
{
    public override void ReceiveSignal(object bodyPart, object eventType = null, object param = null)
    {
        OnThinking(bodyPart,eventType,param);
        
    }

    protected override void OnThinking(object bodyPart, object eventType = null, object param = null)
    {
        if (eventType is MainLegEvent lE)
        {
            nerve.ReceiveSignal(BodyPart.MainLeg,eventType,param);
        }
    }
}
