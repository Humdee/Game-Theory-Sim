using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public long lastUpdated;
    public float dev, work;
    public string username;
    public GameData() 
    {
        this.username = "";
        this.dev = 0;
        this.work = 0;
    }
}