
using System.Collections.Generic;
using MBT;
using UnityEngine;

public class EntityClassifier
{
    public int CarnivoreEntityCount { get; private set; }
    public int HerbivoreEntityCount { get; private set; }
    public int ToxicPlantCount { get; private set; }
    public int MedicinalPlantCount { get; private set; }
    public int NeutralPlantCount { get; private set; }
    public Transform player { get; private set; }
    public EntityClassifier()
    {
        
    }

    public void ResetCount()
    {
        CarnivoreEntityCount = 0;
        HerbivoreEntityCount = 0;
        ToxicPlantCount = 0;
        MedicinalPlantCount = 0;
        NeutralPlantCount = 0;
        player = null;
    }

    private void ClassifyEntity(Transform obj)
    {
        if(obj == null) return;
        switch (obj.tag)
        {
            case "Carnivore":
                CarnivoreEntityCount++;
                break;
            case "Herbivore":
                HerbivoreEntityCount++;
                break;
            case "ToxicPlant":
                ToxicPlantCount++;
                break;
            case "MedicinalPlant":
                MedicinalPlantCount++;
                break;
            case "NeutralPlant":
                NeutralPlantCount++;
                break;
            case "Player":
                player = obj;
                break;
        }
    }

    public void ClassifyDetectedObjects(List<Transform> detectedObjects)
    {
        if (detectedObjects.Count <= 0) return;
        foreach (Transform obj in detectedObjects)
        {
            ClassifyEntity(obj);
        }
    }   
}
