using UnityEngine;

public class ButtonExit : ButtonAbstract
{
    protected override void OnClick()
    {
        GameManager.Instance.QuitGame();
    }

  
}
