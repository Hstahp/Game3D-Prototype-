using UnityEngine;

public class TextPlayerLvlCount : TextAbstract
{
    protected virtual void FixedUpdate()
    {
        this.LoadCount();
    }

    protected virtual void LoadCount()
    {
        this.textPro.text = PlayerController.Instance.Level.CurrentLevel.ToString();
    }
}
