using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KludgeScript : MonoBehaviour
{
    public static KludgeScript instance;
    public List<int> submitKludgeList;
    public event EventHandler KludgeAddSubmit;
    public event EventHandler KludgeNewMinute;
    public event EventHandler KludgeDataChanged;
    private void Awake()
    {
        instance = this;
    }
    public void Clock_KludgeNewMinute()
    {
        submitKludgeList.Add(0);
        Clock_KludgeNewMinute_Custom();
        if (KludgeNewMinute != null) KludgeNewMinute(this, EventArgs.Empty);
    }
    public void Clock_KludgeNewMinute_Custom() { }
    public void AddKludge()
    {
        submitKludgeList[submitKludgeList.Count - 1]++;
        if (KludgeAddSubmit != null) KludgeAddSubmit(this, EventArgs.Empty);
        TriggerOnKludgeChanged();
    }
    public void TriggerOnKludgeChanged()
    {
        if (KludgeDataChanged != null) KludgeDataChanged(this, EventArgs.Empty);
    }
}
