
using System.Collections.Generic;
using UnityEngine;

public class Sensor : ChildBehavior
{
    [SerializeField] protected DataRelay dataRelay;
    [SerializeField] protected Transform player;
    [SerializeField] protected int herbivoreCount;
    [SerializeField] protected int carnivoreCount;
    [SerializeField] protected int toxicPlantCount;
    [SerializeField] protected int medicinalPlantCount;
    [SerializeField] protected int neutralPlantCount;
    
    [SerializeField] protected float radius = 5f;

    [SerializeField] protected Collider2D[] entityColliders;
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

    protected void Detection()
    {
        entityColliders = Physics2D.OverlapCircleAll(dataRelay.transform.position, radius);
        if (entityColliders.Length == 0) return;
        Classification();
    }

    protected void ResetEntityCount()
    {
        herbivoreCount = 0;
        carnivoreCount = 0;
        toxicPlantCount = 0;
        medicinalPlantCount = 0;
        neutralPlantCount = 0;
        player = null;
    }
    protected void Classification()
    {
       ResetEntityCount();
       foreach (Collider2D collider2D in entityColliders)
       {
           var entityTag = collider2D.tag;
           switch (entityTag)
           {
               case "Herbivore":
                   herbivoreCount++;
                   break;
               case "Carnivore":
                   carnivoreCount++;
                   break;
               case "ToxicPlant":
                   toxicPlantCount++;
                   break;
               case "MedicinalPlant":
                   medicinalPlantCount++;
                   break;
               case "NeutralPlant":
                   neutralPlantCount++;
                   break;
               case "Player":
                   player = collider2D.transform.parent;
                   break;
           }
       }
    }

    protected void Update()
    {
        Detection();
    }
}
