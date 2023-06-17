using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public long lastUpdated;
    public int dev, work;
    public GameData() 
    {
        this.dev = 0;
        this.work = 0;
    }
}