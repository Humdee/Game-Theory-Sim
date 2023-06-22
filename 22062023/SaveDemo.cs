using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class SaveDemo : MonoBehaviour
{
    private IDataService DataService = new JsonDataService();
    private bool EncryptionEnabled;
    public void SerializeJson()
    {
        string savedUsername = PlayerPrefs.GetString("Username", "defaultUsername");
        UserStats UserStats = new UserStats(savedUsername);
        if (DataService.SaveData("/" + savedUsername + ".json", UserStats, EncryptionEnabled))
        {
            Debug.Log("Okay, saved.");
        }
        else
        {
            Debug.LogError("Could not save file! Show something on the UI about it!");
        }
    }
    public void DeserializeJson()
    {
        try
        {
            string savedUsername = PlayerPrefs.GetString("Username", "defaultUsername");
            UserStats data = DataService.LoadData<UserStats>("/" + savedUsername + ".json", EncryptionEnabled);
            Debug.Log(JsonConvert.SerializeObject(data, Formatting.Indented));
            ButtonScript.instance.LoadData(data);
        }
        catch (Exception e)
        {
            Debug.LogError($"Could not read file! Show something on the UI here!" + e);
        }
    }
}
