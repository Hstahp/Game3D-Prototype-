using UnityEngine;

public class BtnItemInventory : ButtonAbstract
{
    protected ItemInventory itemInventory;
    public ItemInventory ItemInventory => itemInventory;    

    public virtual void SetItem(ItemInventory itemInventory)
    {
        this.itemInventory = itemInventory;
    }

    protected override void OnClick()
    {
        Debug.Log("Item Click");
    }

}
