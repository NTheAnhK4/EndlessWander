

using UnityEngine;

public class AttackBase : ActionBase
{
    [SerializeField] protected Transform entity;
    [SerializeField] protected float attackSpeed;
    [SerializeField] protected float timer;
    protected override void UpdateLogic()
    {
        base.UpdateLogic();
        timer += Time.deltaTime;
    }

    protected virtual bool CanAttack()
    {
        if (timer >= attackSpeed)
        {
            timer = 0;
            return true;
        }

        return false;
    }

    protected virtual void OnAttack()
    {
        
    }

    protected override void UpdatePhysis()
    {
        base.UpdatePhysis();
        if (!CanAttack()) return;
        OnAttack();
    }
}
