using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : Weapon
{
    protected override void ResetValue()
    {
        base.ResetValue();
        attackSpeed = 1f;
        coolDown = 0f;
    }

    protected override void Attacking(object target = null)
    {
        
    }
}
