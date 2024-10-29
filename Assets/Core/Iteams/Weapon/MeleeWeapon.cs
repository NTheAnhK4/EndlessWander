
using UnityEngine;

public class MeleeWeapon : Weapon
{
    protected override void ResetValue()
    {
        base.ResetValue();
        attackSpeed = 3f;
        coolDown = 0f;
    }

    protected override void Attacking()
    {
        Debug.Log("Execute melee attack");
    }
}
