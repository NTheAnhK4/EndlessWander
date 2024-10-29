
using System.Collections.Generic;
using UnityEngine;

public class Sensor : ChildBehavior
{
    [SerializeField] protected DataRelay dataRelay;
    [SerializeField] protected Transform player;
    [SerializeField] protected List<Transform> herbivores;
    [SerializeField] protected List<Transform> carnivores;
    [SerializeField] protected List<Transform> toxicPlants;
    [SerializeField] protected List<Transform> medicinalPlants;
    [SerializeField] protected List<Transform> neutralPlants;
    [SerializeField] protected float radius = 5f;
    
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
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(dataRelay.transform.position, radius);
        if (hitColliders.Length == 0) return;
        Classification(hitColliders);
    }

    protected void Classification(Collider2D[] hitColliders)
    {
        foreach (Collider2D collider2D in hitColliders)
        {
            var entityTag = collider2D.tag;
            switch (entityTag)
            {
                case "Herbivore":
                    herbivores.Add(collider2D.transform.parent);
                    break;
                case "Carnivore":
                    carnivores.Add(collider2D.transform.parent);
                    break;
                case "ToxicPlant":
                    toxicPlants.Add(collider2D.transform.parent);
                    break;
                case "MedicinalPlant":
                    medicinalPlants.Add(collider2D.transform.parent);
                    break;
                case "NeutralPlant" :
                    neutralPlants.Add(collider2D.transform.parent);
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
