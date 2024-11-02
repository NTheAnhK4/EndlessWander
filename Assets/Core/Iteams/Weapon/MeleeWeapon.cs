
using UnityEngine;

public class MeleeWeapon : Weapon
{
    [SerializeField] protected float damage;
    protected override void ResetValue()
    {
        base.ResetValue();
        attackSpeed = 3f;
        coolDown = 0f;
        damage = 1f;
        attackRange = 2f;
    }

    public EntityReceiver GetEntityReceiver(object target = null)
    {
        return target is Transform transform ? transform.GetComponent<EntityReceiver>() : null;
    }
    protected override void Attacking(object target = null)
    {
        GetEntityReceiver(target)?.TakeDamage(damage);
    }
}
