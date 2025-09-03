using UnityEngine;
public class PlayerPrefsSaveManager : SaveManager
{
    public override void SaveInit(string keyName, int number)
    {
        if (string.IsNullOrEmpty(keyName))
        {
            Debug.LogWarning("SaveInit failed: keyName is null or empty.");
            return;
        }

        PlayerPrefs.SetInt(keyName, number);
        PlayerPrefs.Save();

        Debug.Log($"[SaveInit] Saved key: {keyName}, value: {number}");
    }

    public override int LoadInit(string keyName, int defaultValue = 0)
    {
        if (string.IsNullOrEmpty(keyName))
        {
            Debug.LogWarning("LoadInit failed: keyName is null or empty.");
            return defaultValue;
        }

        if (PlayerPrefs.HasKey(keyName))
        {
            int value = PlayerPrefs.GetInt(keyName);
            Debug.Log($"[LoadInit] Loaded key: {keyName}, value: {value}");
            return value;
        }
        else
        {
            Debug.LogWarning($"[LoadInit] Key not found: {keyName}. Returning default value: {defaultValue}");
            return defaultValue;
        }
    }


    //public override void SaveFloat(string keyName, float number)
    //{
    //    if (string.IsNullOrEmpty(keyName)) return;
    //    PlayerPrefs.SetFloat(keyName, number);
    //    PlayerPrefs.Save();
    //}

    //public override float LoadFloat(string keyName, float defaultValue = 0f)
    //{
    //    if (string.IsNullOrEmpty(keyName)) return defaultValue;
    //    return PlayerPrefs.HasKey(keyName) ? PlayerPrefs.GetFloat(keyName) : defaultValue;
    //}

    //public override void SaveString(string keyName, string value)
    //{
    //    if (string.IsNullOrEmpty(keyName)) return;
    //    PlayerPrefs.SetString(keyName, value);
    //    PlayerPrefs.Save();
    //}

    //public override string LoadString(string keyName, string defaultValue = "")
    //{
    //    if (string.IsNullOrEmpty(keyName)) return defaultValue;
    //    return PlayerPrefs.HasKey(keyName) ? PlayerPrefs.GetString(keyName) : defaultValue;
    //}
}

