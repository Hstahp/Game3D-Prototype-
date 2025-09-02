using UnityEngine;

public class ButtonExit : ButtonAbstract
{
    protected override void OnClick()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }

  
}
