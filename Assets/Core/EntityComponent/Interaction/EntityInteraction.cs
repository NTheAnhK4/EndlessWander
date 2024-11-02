
using MBT;
using UnityEngine;

public class EntityInteraction : EntityComponent
{
    [SerializeField] protected EntityInventory inventory;
    [SerializeField] protected Item currentItem;
    
    protected override void LoadComponentInChild()
    {
        base.LoadComponentInChild();
        inventory = LoadComponent<EntityInventory>(inventory, "Inventory");
    }
    
    protected override void RegisterSignal()
    {
        base.RegisterSignal();
        dataRelay.RegisterSignal(eCompID.Interaction,this);
    }

    public void HasMeleeWeapon(FunctionCallerNode functionCallerNode)
    {
        Item item = inventory.CheckForItem<MeleeWeapon>();
        if (item == null)
        {
            functionCallerNode.Result = NodeResult.failure;
            return;
        }

        currentItem = item;
        functionCallerNode.Result = NodeResult.success;
    }

    public void CanUseWeapon(FunctionCallerNode functionCallerNode)
    {
        if (currentItem == null)
        {
            functionCallerNode.Result = NodeResult.failure;
            return;
        }

        var dataStore = dataRelay.GetEntityComponent<DataStore>(eCompID.DataStore);
        float distance = Vector2.Distance(dataStore.player.Value.transform.parent.position, dataStore.entity.Value.position);
        functionCallerNode.Result = currentItem.CanUse(distance) ? NodeResult.success : NodeResult.failure;
    }

    public void UseItem(object param = null)
    {
        var entityEnergy = dataRelay.GetEntityComponent<EntityEnergy>(eCompID.Energy);
        if(!entityEnergy.CanUseEnergy(2f)) return;
        entityEnergy.UseEnergy(Time.deltaTime * 2f);
        currentItem.Execute(param);
    }
    
}
