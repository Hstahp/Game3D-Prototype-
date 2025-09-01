using UnityEngine;

public class InputHotKey : SaiSingleton<InputHotKey>
{
    protected bool isToogleInventoryUI = false;
    public bool IsToggleInventoryUI => isToogleInventoryUI;

    protected bool isToggleMusic = false;
    public bool IsToggleMusic => isToggleMusic;

    protected bool isToggleSetting = false;
    public bool IsToggleSetting => isToggleSetting;

    protected virtual void Update()
    {
        this.OpenInventory();
        this.ToogleMusic();
        this.ToogleSetting();
    }

    protected virtual void OpenInventory()
    {
        this.isToogleInventoryUI = Input.GetKeyUp(KeyCode.I);
    }

    protected virtual void ToogleMusic()
    {
        this.isToggleMusic = Input.GetKeyUp(KeyCode.M);
    }

    protected virtual void ToogleSetting()
    {
        this.isToggleSetting = Input.GetKeyUp(KeyCode.N);
    }
}