using UnityEngine;

public class ButtonInventoryToggle : ButtonAbstract
{
    protected override void OnClick()
    {
        InventoryUI.Instance.Toggle();
    }
}
