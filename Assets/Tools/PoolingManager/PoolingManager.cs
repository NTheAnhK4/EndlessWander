
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PoolingManager : Singeton<PoolingManager>
{ 
    protected Dictionary<string, List<Transform>> prefabList = new Dictionary<string, List<Transform>>();
    protected Dictionary<string, Transform> holderList = new Dictionary<string, Transform>();
    protected Dictionary<string, List<Transform>> pools = new Dictionary<string, List<Transform>>();
   
    protected override void LoadComponentInChild()
    {
        base.LoadComponentInChild();
        LoadPrefabs();
        LoadHolders();
    }

    protected virtual void LoadPrefabs()
    {
       
        Transform prefabs = transform.Find("Prefabs");
        
        foreach (Transform prefab in prefabs)
        {
            AddPrefabToDict(prefab);
        }
    }

    protected virtual void AddPrefabToDict(Transform prefabs)
    {
        prefabList[prefabs.name] = new List<Transform>(); 
        pools[prefabs.name] = new List<Transform>();
        foreach (Transform prefab in prefabs)
        {
            prefabList[prefabs.name].Add(prefab);
        }
        HirePrefab(prefabList[prefabs.name]);
    }

    protected virtual void HirePrefab(List<Transform> prefabs)
    {
        foreach (Transform prefab in prefabs)
        {
           prefab.gameObject.SetActive(false);
        }
    }

    protected virtual void LoadHolders()
    {
        
        Transform holders = transform.Find("Holders");
        foreach (Transform holder in holders)
        {
            holderList[holder.name] = holder;
        }
    }

    protected Transform GetObjectByName(string type, string prefabName)
    {
        foreach (Transform prefab in prefabList[type])
        {
            if (prefab.name == prefabName) return prefab;
        }

        return null;
    }

    protected Transform GetObjectFromPool(string type, string prefabName)
    {
        Transform prefab = GetObjectByName(type, prefabName);
        if (prefab == null)
        {
            Debug.LogWarning("Cannot find " + prefabName + " in " + type);
            return null;
        }
        foreach (Transform obj in pools[type])
        {
            if (obj.name == prefabName)
            {
                pools[type].Remove(obj);
                return obj;
            }
        }
        
        Transform newPrefab = Instantiate(prefab);
        newPrefab.gameObject.SetActive(false);
        newPrefab.name = prefabName;
        return newPrefab;
    }

    public Transform Spawn(string type, string prefabName, Vector3 position)
    {
        
        Transform prefab = GetObjectFromPool(type, prefabName);
       
        if (prefab == null) return null;
        
        prefab.SetParent(holderList[type]);
        prefab.SetPositionAndRotation(position,quaternion.identity);
        prefab.gameObject.SetActive(true);
        return prefab;
    }

    public Transform Spawn(string type, string prefabName, Vector3 position, Quaternion rot)
    {
        Transform prefab = Spawn(type, prefabName, position);
        prefab.SetPositionAndRotation(position,rot);
        return prefab;
    }
}
