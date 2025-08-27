using UnityEngine;

public class ButtonCloseInventory : ButtonAbstract
{
   public virtual void CloseInventoryUI()
    {
        InventoryUI.Instance.Hide();
    }

    protected override void OnClick()
    {
        this.CloseInventoryUI();
    }
}
