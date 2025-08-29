using UnityEngine;

public class InputHotKey : SaiSingleton<InputHotKey>
{
    protected bool isToggleInventoryUI = false;
    public bool IsToggleInventoryUI => isToggleInventoryUI;

    protected virtual void Update()
    {
        this.OpenInventory();
    }

    protected virtual void OpenInventory()
    {
        this.isToggleInventoryUI = Input.GetKeyUp(KeyCode.I);
    }
}