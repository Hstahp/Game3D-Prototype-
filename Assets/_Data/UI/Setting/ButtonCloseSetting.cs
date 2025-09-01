using UnityEngine;

public class ButtonCloseSetting : ButtonAbstract
{
    public virtual void CloseInventoryUI()
    {
        UISetting.Instance.Hide();
    }

    protected override void OnClick()
    {
        this.CloseInventoryUI();
    }
}
