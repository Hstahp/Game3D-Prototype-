using UnityEngine;

public class ButtonSettingToggle : ButtonAbstract
{
    protected virtual void LateUpdate()
    {
        this.HotkeyToggleSetting();
    }

    protected override void OnClick()
    {
        UISetting.Instance.Toggle();
    }

    protected virtual void HotkeyToggleSetting()
    {
        if (InputHotKey.Instance.IsToggleSetting) UISetting.Instance.Toggle();
    }
}