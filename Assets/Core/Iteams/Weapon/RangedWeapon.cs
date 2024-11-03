
using UnityEngine;


public class RangedWeapon : Weapon
{
    [SerializeField] public Transform bullet;
    [SerializeField] protected Collider2D entityCollider;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        if (entityCollider != null) return;
        entityCollider = user.GetComponentInChildren<Collider2D>();
        
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        attackSpeed = 1f;
        coolDown = 0f;
        attackRange = 15f;
    }

    protected override void Attacking(object target = null)
    {
        Quaternion targetRotation = GetBulletRotation(target);
        Collider2D bulletCollider = PoolingManager.Spawn(bullet.gameObject, user.position, targetRotation, this.transform).GetComponentInChildren<BoxCollider2D>();
        Physics2D.IgnoreCollision(bulletCollider, entityCollider);
    }

    protected Quaternion GetBulletRotation(object target = null)
    {
        Quaternion targetRotation = default;
        if (target is Transform targetTrf)
        {
            Vector3 direction = (targetTrf.parent.position - user.position).normalized;
            if (direction != Vector3.zero)
            {
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
            }
        }

        return targetRotation;
    }
}
