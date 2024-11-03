using System;
using UnityEditor;
using UnityEngine;

[Serializable]
public class InventoryData
{
    public int maxItem;
}
[Serializable]
public class EnermyHealthData
{
    public float minMoveHealth;
    public float maxMoveHealth;
    public float minInteractionHealth;
    public float maxInteractionHealth;
    public float minSensorHealth;
    public float maxSensorHealth;
    public float minDeciderHealth;
    public float maxDeciderHealth;
}


[Serializable]
public class EnermyMoveData
{
    public float runSpeed;
    public float walkSpeed;
}