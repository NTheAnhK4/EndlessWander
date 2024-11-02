using System;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class PartHealth
{
    
    [SerializeField] private string name;
    [SerializeField] private float maxHp;
    [SerializeField] private float curHp;
    [SerializeField] private float dropRate;

    public float DropRate
    {
        get => dropRate;
        set => dropRate = value;
    }

    public float MaxHp => maxHp;
    public float CurHp
    {
        get => curHp;
        set => curHp = value;
    }
    public PartHealth(string name, float minHealth, float maxHealth)
    {
        this.name = name;
        this.maxHp = Random.Range(minHealth, maxHealth);
        this.curHp = this.maxHp;
        this.dropRate = 0; 
    }

    public PartHealth(string name, float health)
    {
        this.name = name;
        this.maxHp = health;
        this.curHp = maxHp;
        this.dropRate = 0;
    }
    
    public void TakeDamage(float damage)
    {
        curHp = Mathf.Max(curHp - damage, 0);
    }

    public void Heal(float amount)
    {
        curHp = Mathf.Min(curHp + amount, maxHp);
    }
    public bool IsFunctional => curHp > 0;
}
