using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixScript : MonoBehaviour
{
    public static FixScript instance;
    public List<int> submitFixList;
    public event EventHandler FixAddSubmit;
    public event EventHandler FixNewMinute;
    public event EventHandler FixDataChanged;
    private void Awake()
    {
        instance = this;
    }
    public void Clock_FixNewMinute()
    {
        submitFixList.Add(0);
        Clock_FixNewMinute_Custom();
        if (FixNewMinute != null) FixNewMinute(this, EventArgs.Empty);
    }
    public void Clock_FixNewMinute_Custom() { }
    public void AddFix()
    {
        submitFixList[submitFixList.Count - 1]++;
        if (FixAddSubmit != null) FixAddSubmit(this, EventArgs.Empty);
        TriggerOnFixChanged();
    }
    public void TriggerOnFixChanged()
    {
        if (FixDataChanged != null) FixDataChanged(this, EventArgs.Empty);
    }
}
