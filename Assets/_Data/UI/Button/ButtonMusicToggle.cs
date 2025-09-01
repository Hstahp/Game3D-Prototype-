using UnityEngine;

public class ButtonMusicToggle : ButtonAbstract
{
    protected virtual void LateUpdate()
    {
        this.HotkeyToogleMusic();
    }

    protected override void OnClick()
    {
        SoundManager.Instance.ToggleMusic();
    }

    protected virtual void HotkeyToogleMusic()
    {
        if (InputHotKey.Instance.IsToogleMusic) SoundManager.Instance.ToggleMusic();
    }
}