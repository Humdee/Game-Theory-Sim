using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveParameter(ButtonScript parameter) {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/parameter.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        UserData data = new UserData(parameter);
        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static UserData LoadData() {
        string path = Application.persistentDataPath + "/parameter.fun";
        Debug.Log(path);
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            UserData data = formatter.Deserialize(stream) as UserData;
            stream.Close();
            return data;
        } else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
