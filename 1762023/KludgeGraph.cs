using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KludgeGraph : MonoBehaviour
{
    public static KludgeGraph instance;
    private Kludge_Window_Graph windowgraph;
    private KludgeScript kludgeScript;
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
        kludgeScript = GetComponent<KludgeScript>();
        windowgraph = GameObject.Find("TAB/Tabs/Tab2/Scroll View/Viewport/Content/Kludge_Window_Graph").GetComponent<Kludge_Window_Graph>();
        windowgraph.SetGetAxisLabelX((int _i) =>
        {
            string minuteString = _i + " kludges";
            return minuteString;
        });
        HideKludge();
    }
    private void Update()
    {
        if (startGraph == true)
        {
            timerOneMinute += Time.deltaTime;
            if (timerOneMinute > 60)
            {
                kludgeScript.Clock_KludgeNewMinute();
                timerOneMinute = 0;
            }
        }
    }
    public void ShowKludge()
    {
        windowgraph.gameObject.SetActive(true);
        windowgraph.ShowGraph(kludgeScript.submitKludgeList, windowgraph.lineGraphVisual);
        kludgeScript.KludgeAddSubmit += SubmitLog_KludgeAddSubmit;
        kludgeScript.KludgeNewMinute += SubmitLog_KludgeNewMinute;
    }
    private void SubmitLog_KludgeNewMinute(object sender, EventArgs e)
    {
        windowgraph.ShowGraph(kludgeScript.submitKludgeList, windowgraph.lineGraphVisual);
    }
    private void SubmitLog_KludgeAddSubmit(object sender, EventArgs e)
    {
        windowgraph.UpdateValue(kludgeScript.submitKludgeList.Count - 1, kludgeScript.submitKludgeList[kludgeScript.submitKludgeList.Count - 1]);
    }
    public void HideKludge()
    {
        windowgraph.gameObject.SetActive(false);
        kludgeScript.KludgeAddSubmit -= SubmitLog_KludgeAddSubmit;
        kludgeScript.KludgeNewMinute -= SubmitLog_KludgeNewMinute;
    }
}
