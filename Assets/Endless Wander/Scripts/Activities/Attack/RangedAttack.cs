
using UnityEngine;

public class RangedAttack : AttackBase
{
    [SerializeField] protected string bulletName;
    
    protected override void OnAttack()
    {
        base.OnAttack();
        Debug.Log("Attacking");
    }
    
    protected override void ResetValue()
    {
        entity = transform.parent;
        attackSpeed = 3;
        timer = 0;
    }
}
