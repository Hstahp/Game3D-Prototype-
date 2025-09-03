using UnityEngine;
public abstract class SaveManager : SaiMonoBehaviour
{
    public abstract void SaveInit(string keyName, int number);
    public abstract int LoadInit(string keyName, int defaultValue = 0);

    //public abstract void SaveFloat(string keyName, float number);
    //public abstract float LoadFloat(string keyName, float defaultValue = 0f);

    //public abstract void SaveString(string keyName, string value);
    //public abstract string LoadString(string keyName, string defaultValue = "");
}
