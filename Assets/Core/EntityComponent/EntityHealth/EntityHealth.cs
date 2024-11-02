
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EntityHealth : EntityComponent
{
    private List<PartHealth> partHealths;
    protected override void RegisterSignal()
    {
        base.RegisterSignal();
        dataRelay.RegisterSignal(eCompID.Health,this);
    }

    public void TakeDamage(float totalDamage)
    {
        float totalDamageRate = partHealths.Where(part => part.IsFunctional).Sum(part => part.DamageRate);
        
        foreach (var part in partHealths.Where(part => part.IsFunctional))
        {
            // Tính sát thương cho bộ phận theo tỷ lệ sát thương của nó
            float damageForPart = (part.DamageRate / totalDamageRate) * totalDamage;
            part.TakeDamage(damageForPart);
        }

    }
   
    
}
