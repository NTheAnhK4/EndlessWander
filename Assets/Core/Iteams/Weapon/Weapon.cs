
using UnityEngine;

public abstract class Weapon : Iteam
{
    [SerializeField] protected float attackSpeed;
    [SerializeField] protected float coolDown;

    protected virtual void UpdateLogic()
    {
        coolDown += Time.deltaTime;
    }

    protected virtual bool CanAttack()
    {
        return coolDown >= attackSpeed;
    }
    protected virtual void UpdatePhysis()
    {
        if(!CanAttack()) return;
        Attacking();
        coolDown = 0;
    }

    protected abstract void Attacking();
    public override void Execute()
    {
        UpdatePhysis();
        UpdateLogic();
    }
}
