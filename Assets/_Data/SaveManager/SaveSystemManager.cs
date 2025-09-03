using UnityEngine;
public class SaveSystemManager : SaveManager
{
    public override void SaveInit(string keyName, int number)
    {
        if (string.IsNullOrEmpty(keyName))
        {
            Debug.LogWarning("SaveInit failed: keyName is null or empty.");
            return;
        }

        PlayerPrefs.SetInt(keyName, number);
        SaveSystem.SetInt(keyName, number);
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
            int value = SaveSystem.GetInt(keyName);
            Debug.Log($"[LoadInit] Loaded key: {keyName}, value: {value}");
            return value;
        }
        else
        {
            Debug.LogWarning($"[LoadInit] Key not found: {keyName}. Returning default value: {defaultValue}");
            return defaultValue;
        }
    }
}

