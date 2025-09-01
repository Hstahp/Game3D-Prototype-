using UnityEngine;

public class InputHotKey : SaiSingleton<InputHotKey>
{
    protected bool isToggleInventoryUI = false;
    public bool IsToggleInventoryUI => isToggleInventoryUI;
    protected bool isToogleMusic = false;
    public bool IsToogleMusic => isToogleMusic;

    protected virtual void Update()
    {
        this.OpenInventory();
        this.ToogleMusic();
    }

    protected virtual void OpenInventory()
    {
        this.isToggleInventoryUI = Input.GetKeyUp(KeyCode.I);
    }

    protected virtual void ToogleMusic()
    {
        this.isToogleMusic = Input.GetKeyUp(KeyCode.M);
    }
}