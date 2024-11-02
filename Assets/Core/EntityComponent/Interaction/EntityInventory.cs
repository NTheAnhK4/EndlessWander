
using System.Collections.Generic;
using UnityEngine;

public class EntityInventory : ChildBehavior
{
    [SerializeField] private int maxItem;
    [SerializeField] private List<Item> heldItem = new List<Item>();

    protected override void ResetValue()
    {
        base.ResetValue();
        maxItem = 5;
    }

    public void AddItem(Item item)
    {
        if (heldItem.Count >= maxItem) return;
        heldItem.Add(item);
    }

    public void RemoveItem(Item item)
    {
        if (item == null) return;
        heldItem.Remove(item);
    }

    public bool Contains(Item item)
    {
        return heldItem.Contains(item);
    }

    public Item CheckForItem<T>() where T : Item
    {
        foreach (var item in heldItem)
        {
            if (item is T) return item;
        }

        return null;
    }
    protected override void LoadComponentInChild()
    {
        base.LoadComponentInChild();
        if (heldItem.Count != 0) return;
        heldItem.AddRange(GetComponentsInChildren<Item>());
    }
    
    
}
