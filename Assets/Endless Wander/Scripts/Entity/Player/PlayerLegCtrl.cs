using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLegCtrl : EntityLegCtrl
{
    public override void ReceiveSignal(object bodyPart, object eventType = null, object param = null)
    {
        
        if (eventType is MainLegEvent)
        {
           
            legList[0].ReceiveSignal(bodyPart,eventType,param);
        }
    }
}
