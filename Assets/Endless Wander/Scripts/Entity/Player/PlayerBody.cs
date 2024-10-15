

using System;
using UnityEngine;

public class PlayerBody : EntityBody
{
    private void Update()
    {
        Vector3 direction = InputManager.Instance.GetHorizontal() + InputManager.Instance.GetVertical();
        nerve.ReceiveSignal(BodyPart.Brain,MainLegEvent.Walk,direction);
    }
}
