
using UnityEngine;

public abstract class Weapon : Item
{
    //only use as a weapon not charactor 
    [SerializeField] protected float attackRange;
    [SerializeField] protected float attackSpeed;
    [SerializeField] protected float coolDown;

    protected virtual void UpdateLogic()
    {
        coolDown += Time.deltaTime;
    }

    public override bool CanUse(object param = null)
    {
        return (float)param <= attackRange;
    }

    protected virtual bool CanAttack()
    {
        return coolDown >= attackSpeed;
    }
    protected virtual void UpdatePhysis(object target = null)
    {
        if(!CanAttack()) return;
        Attacking(target);
        coolDown = 0;
    }

    protected abstract void Attacking(object target = null);
    public override void Execute(object target = null)
    {
        UpdateLogic();
        UpdatePhysis(target);
    }
}
