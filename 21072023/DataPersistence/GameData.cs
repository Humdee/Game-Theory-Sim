using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public long lastUpdated;
    public int finalFix, finalKludge;
    public float dev, work, fixRework, kludgeRework, averageWork, hour, finalQuality;
    public string username, startStrat, duration;
    public List<int> finalGraphArray, fixGraphArray, kludgeGraphArray;
    public List<GameObject> todoArray, doneArray;
    public GameData()
    {
        this.username = "";
        this.dev = 0;
        this.work = 0;
        this.fixRework = 2;
        this.kludgeRework = 8;
        this.averageWork = 10;
        this.startStrat = "Mula Baiki";
        this.hour = 0;
        this.duration = "00:00";
        this.finalQuality = 100;
        this.finalFix = 0;
        this.finalKludge = 0;
        this.finalGraphArray = new List<int>();
        this.fixGraphArray = new List<int>();
        this.kludgeGraphArray = new List<int>();
        this.todoArray = new List<GameObject>();
        this.doneArray = new List<GameObject>();
    }
}