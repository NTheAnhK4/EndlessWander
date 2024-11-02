using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EntityHealth : EntityComponent, IHealth
{
    public PartHealth coreHealth;
    public List<PartHealth> partHealths;

    protected override void ResetValue()
    {
        base.ResetValue();
        partHealths = new List<PartHealth>
        {
            new PartHealth("Move",5,10),
            new PartHealth("Interaction", 3,7),
            new PartHealth("Sensor",3,5),
            new PartHealth("Decider",5,10)
        };
        coreHealth = new PartHealth("Core Health", partHealths.Sum(health => health.MaxHp));
        AssignRandomDropRate();
    }
    protected override void RegisterSignal()
    {
        base.RegisterSignal();
        dataRelay.RegisterSignal(eCompID.Health, this);
    }
    private void AssignRandomDropRate()
    {
        List<float> randomValues = partHealths.Select(_ => Random.Range(1f, 100f)).ToList();
        float total = randomValues.Sum();
        for (int i = 0; i < partHealths.Count; ++i)
        {
            partHealths[i].DropRate = (randomValues[i] / total) * 100;
        }
    }

    private  PartHealth GetPart()
    {
        var availableParts = partHealths.Where(part => part.IsFunctional).ToList();
        if (availableParts.Count == 0) return null;
        float totalDropRate = availableParts.Sum(part => part.DropRate);
        float randomRate = Random.Range(0, totalDropRate);

        float cumulativeRate = 0;

        foreach (var part in availableParts)
        {
            cumulativeRate += part.DropRate;
            if (randomRate <= cumulativeRate) return part;
        }

        return null;
    }
    public void TakeDamage(float damage)
    {
        GetPart()?.TakeDamage(damage);
        coreHealth.TakeDamage(damage);
    }

    public void Heal(float amount)
    {
        foreach (var health in partHealths)
        {
            health.Heal(amount);
        }
    }
}