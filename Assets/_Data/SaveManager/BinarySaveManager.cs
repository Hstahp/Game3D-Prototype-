using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class BinarySaveManager : SaveManager
{
    private string GetFilePath(string keyName)
    {
        return Path.Combine(Application.persistentDataPath, keyName + ".dat");
    }

    public override void SaveInit(string keyName, int number)
    {
        SaveData(keyName, number);
    }

    public override int LoadInit(string keyName, int defaultValue = 0)
    {
        object data = LoadData(keyName);
        return data is int i ? i : defaultValue;
    }

    //public override void SaveFloat(string keyName, float number)
    //{
    //    SaveData(keyName, number);
    //}

    //public override float LoadFloat(string keyName, float defaultValue = 0f)
    //{
    //    object data = LoadData(keyName);
    //    return data is float f ? f : defaultValue;
    //}

    //public override void SaveString(string keyName, string value)
    //{
    //    SaveData(keyName, value);
    //}

    //public override string LoadString(string keyName, string defaultValue = "")
    //{
    //    object data = LoadData(keyName);
    //    return data is string s ? s : defaultValue;
    //}

    private void SaveData(string keyName, object data)
    {
        if (string.IsNullOrEmpty(keyName)) return;

        string path = GetFilePath(keyName);
        using (FileStream stream = new FileStream(path, FileMode.Create))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, data);
        }
    }

    private object LoadData(string keyName)
    {
        if (string.IsNullOrEmpty(keyName)) return null;

        string path = GetFilePath(keyName);
        if (!File.Exists(path)) return null;

        using (FileStream stream = new FileStream(path, FileMode.Open))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            return formatter.Deserialize(stream);
        }
    }
}
