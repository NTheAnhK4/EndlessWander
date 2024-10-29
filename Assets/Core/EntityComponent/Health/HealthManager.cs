using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : ChildBehavior
{
    [SerializeField] protected DataRelay dataRelay;
    [SerializeField] protected float maxHp = 10;
    [SerializeField] protected float curHp = 10;
    [SerializeField] protected float mediumHp;
    [SerializeField] protected float lowHp;
    protected override void ResetValue()
    {
        base.ResetValue();
        mediumHp = CreateValueInRange(0.4f, 0.6f);
        lowHp = CreateValueInRange(0.1f, 0.25f);

    }

    protected float CreateValueInRange(float l, float r)
    {
        float rate = Random.Range(l, r);
        return rate * maxHp;
    }

    protected override void LoadComponentInParent()
    {
        base.LoadComponentInParent();
        this.LoadDataRelay();
    }

    protected virtual void LoadDataRelay()
    {
        if (dataRelay != null) return;
        dataRelay = transform.GetComponentInParent<DataRelay>();
    }

    public void TakeDamage(float damage)
    {
        curHp -= damage;
        EvaluateHp();
    }

    protected void EvaluateHp()
    {
       if(curHp > mediumHp) dataRelay.SendSignal(HealthID.HighHealth);
       else if (curHp > lowHp) dataRelay.SendSignal(HealthID.MediumHealth);
       else if(curHp > 0) dataRelay.SendSignal(HealthID.LowHealth);
       else dataRelay.SendSignal(HealthID.OnDead);
    }
}
