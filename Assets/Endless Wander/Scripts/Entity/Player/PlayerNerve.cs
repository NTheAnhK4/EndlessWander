using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNerve : EntityNerve
{
    public override void ReceiveSignal(object bodyPart,object eventType = null, object param = null)
    {
        if (bodyPart is not BodyPart bp) return;
        switch (bp)
        {
            case BodyPart.Brain:
                brain.ReceiveSignal(bodyPart,eventType,param);
               
                break;
            case BodyPart.MainLeg:
                legCtrl.ReceiveSignal(bodyPart,eventType,param);
                
                break;
        }
    }
}
