using System.Collections.Generic;
using UnityEngine;

public class InputHotKey : SaiSingleton<InputHotKey>
{
    protected bool isToogleInventoryUI = false;
    public bool IsToggleInventoryUI => isToogleInventoryUI;

    protected bool isToggleMusic = false;
    public bool IsToggleMusic => isToggleMusic;

    protected bool isToggleSetting = false;
    public bool IsToggleSetting => isToggleSetting;

    [SerializeField] protected KeyCode keyCode;
    public KeyCode KeyCode => keyCode;
    [SerializeField] protected bool isPlaceTower;
    public bool IsPlaceTower => isPlaceTower;
    protected virtual void Update()
    {
        this.OpenInventory();
        this.ToogleMusic();
        this.ToogleSetting();
        this.ToggleNumber();
    }

    protected virtual void OpenInventory()
    {
        this.isToogleInventoryUI = Input.GetKeyUp(KeyCode.I);
    }

    protected virtual void ToogleMusic()
    {
        this.isToggleMusic = Input.GetKeyUp(KeyCode.M);
    }

    protected virtual void ToggleNumber()
    {
        this.isPlaceTower = Input.GetKeyUp(KeyCode.C);

        for (int i = 1; i <= 9; i++)
        {
            KeyCode code = KeyCode.Alpha0 + i; // Alpha1 -> Alpha9
            if (Input.GetKeyDown(code))
            {
                this.keyCode = (this.keyCode == code) ? KeyCode.None : code;
            }
        }
    }


    protected virtual void ToogleSetting()
    {
        this.isToggleSetting = Input.GetKeyUp(KeyCode.N);
    }
}