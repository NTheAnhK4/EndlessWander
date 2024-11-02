using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityEnergy : EntityComponent
{
    [SerializeField] protected float maxEnergy = 50f;
    [SerializeField] protected float curEnergy = 50f;
    protected override void RegisterSignal()
    {
        base.RegisterSignal();
        dataRelay.RegisterSignal(eCompID.Energy,this);
    }

    public bool CanUseEnergy(float amount)
    {
        return curEnergy > amount;
    }
    public void UseEnergy(float amount)
    {
        curEnergy = Mathf.Max(curEnergy - amount, 0);
    }

    public void RecoverEnergy(float amount)
    {
        curEnergy = Mathf.Min(curEnergy + amount, maxEnergy);
    }
}
