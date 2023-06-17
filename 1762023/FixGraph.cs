using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixGraph : MonoBehaviour
{
    public static FixGraph instance;
    private Fix_Window_Graph fixwindowGraph;
    private FixScript fixScript;
    public bool startGraph, viewGraph;
    [SerializeField] private float timerOneMinute;
    private void Awake()
    {
        instance = this;
        Setup();
    }
    private void Start()
    {
        startGraph = false;
        viewGraph = false;
    }
    private void Setup()
    {
        fixScript = GetComponent<FixScript>();
        fixwindowGraph = GameObject.Find("TAB/Tabs/Tab2/Scroll View/Viewport/Content/Fix_Window_Graph").GetComponent<Fix_Window_Graph>();
        fixwindowGraph.SetGetAxisLabelX((int _i) =>
        {
            string minuteString = _i + " fixes";
            return minuteString;
        });
        Hidefix();
    }
    private void Update()
    {
        if (startGraph == true)
        {
            timerOneMinute += Time.deltaTime;
            if (timerOneMinute > 60)
            {
                fixScript.Clock_FixNewMinute();
                timerOneMinute = 0;
            }
        }
    }
    public void Showfix()
    {
        fixwindowGraph.gameObject.SetActive(true);
        fixwindowGraph.ShowGraph(fixScript.submitFixList, fixwindowGraph.lineGraphVisual);
        fixScript.FixAddSubmit += SubmitLog_FixAddSubmit;
        fixScript.FixNewMinute += SubmitLog_FixNewMinute;
    }
    private void SubmitLog_FixNewMinute(object sender, EventArgs e)
    {
        fixwindowGraph.ShowGraph(fixScript.submitFixList, fixwindowGraph.lineGraphVisual);
    }
    private void SubmitLog_FixAddSubmit(object sender, EventArgs e)
    {
        fixwindowGraph.UpdateValue(fixScript.submitFixList.Count - 1, fixScript.submitFixList[fixScript.submitFixList.Count - 1]);
    }
    public void Hidefix()
    {
        fixwindowGraph.gameObject.SetActive(false);
        fixScript.FixAddSubmit -= SubmitLog_FixAddSubmit;
        fixScript.FixNewMinute -= SubmitLog_FixNewMinute;
    }
}
