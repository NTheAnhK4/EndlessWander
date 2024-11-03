using System;

using UnityEngine;

public class PlayerHealth : ChildBehavior,IHealth
{
    [SerializeField] protected float maxHp = 100;
    [SerializeField] protected float curHp = 100;
    public void TakeDamage(float damage)
    {
        curHp = Mathf.Max(curHp - damage, 0);
    }

    public void Heal(float amount)
    {
        curHp = Mathf.Min(maxHp, curHp + amount);
    }
    private void EvaluateHp()
    {
        if(curHp == 0) OnDead();
    }

    private void OnDead()
    {
        Debug.Log("Player is dead");
    }
}
