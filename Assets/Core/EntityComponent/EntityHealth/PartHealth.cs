using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class PartHealth
{
    public string Name { get; }
    public float Health { get; private set; }
    public float DamageRate { get; }

    public PartHealth(string name, float health, float damageRate)
    {
        Name = name;
        Health = health;
        DamageRate = damageRate;
    }

    public void TakeDamage(float damage)
    {
        Health = Mathf.Max(Health - damage, 0);
    }

    public bool IsFunctional => Health > 0;
}
