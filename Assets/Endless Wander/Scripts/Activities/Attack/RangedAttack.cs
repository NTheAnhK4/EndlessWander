
using UnityEngine;

public class RangedAttack : AttackBase
{
    [SerializeField] protected string bulletName;
    
    protected override void OnAttack()
    {
        base.OnAttack();
        PoolingManager.Instance.Spawn("Bullets", "Bubble", entity.position);
    }
    
    protected override void ResetValue()
    {
        entity = transform.parent;
        attackSpeed = 3;
        timer = 0;
    }
}
