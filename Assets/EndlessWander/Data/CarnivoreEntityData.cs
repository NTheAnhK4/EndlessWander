using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Carnivore",menuName = "Data/Enemy/Carnivore")]
public class CarnivoreEntityData : ScriptableObject
{
    public List<CarnivoreParam> CarnivoreParams;
}
[Serializable]
public class CarnivoreParam
{
    public int id;
    public string name;
    public float energy;
    public InventoryData inventory;
    public EnermyHealthData health;
    public EnermyMoveData move;
}
