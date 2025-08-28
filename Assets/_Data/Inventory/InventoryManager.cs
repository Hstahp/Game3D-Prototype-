using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class InventoryManager : SaiSingleton<InventoryManager>
{
    [SerializeField] protected List<InventoryCtrl> inventories;
    [SerializeField] protected List<ItemProfileSO> itemProfiles;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadInventories();
    }

    protected override void Start()
    {
        base.Start();
        this.AddTestGold(100);
        this.AddTestItems(20);
        Invoke(nameof(this.AddTestItemDelay), 7f);
    }

    protected virtual void AddTestItemDelay()
    {
        this.AddTestItems(2);
    }

    protected virtual void AddTestGold(int count)
    {
        InventoryCtrl inventoryCtrl = this.GetByName(InvCodeName.Monies);

        ItemInventory gold = new();
        gold.itemProfile = this.GetProfileByCode(ItemCode.Gold);
        gold.itemName = gold.itemProfile.itemName;
        gold.itemCount = count;
        inventoryCtrl.AddItem(gold);
    }

    protected virtual void AddTestItems(int count)
    {
        InventoryCtrl items = this.GetByName(InvCodeName.Items);
        for (int i = 0; i < count; i++)
        {
            ItemInventory wand = new();
            wand.itemProfile = this.GetProfileByCode(ItemCode.Wand);
            wand.itemName = wand.itemProfile.itemName;
            wand.itemCount = 1;
            items.AddItem(wand);
        }
    }

    protected virtual void LoadInventories()
    {
        if (this.inventories.Count > 0) return;
        foreach(Transform child in transform)
        {
            InventoryCtrl inventoryCtrl = child.GetComponent<InventoryCtrl>();
            if(inventoryCtrl == null) continue;
            this.inventories.Add(inventoryCtrl);
        }
        Debug.Log(transform.name + ": LoadInventories", gameObject);
    }

    public virtual InventoryCtrl GetByName(InvCodeName inventoryName)
    {
        foreach(InventoryCtrl inventory in this.inventories){
            if (inventory.GetName() == inventoryName) return inventory;
        }
        return null;
    }
    public virtual ItemProfileSO GetProfileByCode(ItemCode itemCodeName)
    {
        foreach(ItemProfileSO itemProfile in this.itemProfiles){
            if (itemProfile.itemCode == itemCodeName) return itemProfile;
        }
        return null;
    }

    public virtual InventoryCtrl Monies()
    {
        return this.GetByName(InvCodeName.Monies);
    }

    public virtual InventoryCtrl Items()
    {
        return this.GetByName(InvCodeName.Items);
    }
}
