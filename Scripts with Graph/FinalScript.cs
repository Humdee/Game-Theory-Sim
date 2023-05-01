using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey;
using CodeMonkey.Utils;

public class FinalScript : MonoBehaviour
{
    public static FinalScript instance;
    public List<GameObject> FinalList;
    public List<int> submitCountList;
    public event EventHandler OnAddSubmit;
    public event EventHandler OnNewMinute;
    public event EventHandler OnDataChanged;
    void Awake() {
        instance = this;
    }
    public void Clock_OnNewMinute() {
        submitCountList.Add(0);
        if (OnNewMinute != null) OnNewMinute(this, EventArgs.Empty);
    }
    public void AddSubmit() {
        submitCountList[submitCountList.Count - 1]++;
        if (OnAddSubmit != null) OnAddSubmit(this, EventArgs.Empty);
        TriggerOnDataChanged();
    }
    public void TriggerOnDataChanged() {
        if (OnDataChanged != null) OnDataChanged(this, EventArgs.Empty);
    }
}
