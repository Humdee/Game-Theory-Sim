using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalGraph : MonoBehaviour
{
    public static FinalGraph instance;
    private Final_Window_Graph windowGraph;
    private FinalScript finalScript;
    public bool startGraph, viewGraph;
    [SerializeField] private float timerOneMinute;
    private void Awake()
    {
        instance = this;
        // Setup();
    }
    private void Start()
    {
        Setup();
        startGraph = false;
        viewGraph = false;
    }
    private void Setup()
    {
        finalScript = GetComponent<FinalScript>();
        windowGraph = GameObject.Find("TAB/Tabs/Tab2/Scroll View/Viewport/Content/Final_Window_Graph").GetComponent<Final_Window_Graph>();
        windowGraph.SetGetAxisLabelX((int _i) =>
        {
            string minuteString = _i + " minutes";
            return minuteString;
        });
        HideFinal();
    }
    private void Update()
    {
        if (startGraph == true)
        {
            timerOneMinute += Time.deltaTime;
            if (timerOneMinute > 60)
            {
                finalScript.Clock_OnNewMinute();
                timerOneMinute = 0;
            }
        }
    }
    public void ShowFinal()
    {
        windowGraph.gameObject.SetActive(true);
        windowGraph.ShowGraph(finalScript.submitCountList);
        finalScript.OnAddSubmit += SubmitLog_OnAddSubmit;
        finalScript.OnNewMinute += SubmitLog_OnNewMinute;
    }
    private void SubmitLog_OnNewMinute(object sender, EventArgs e)
    {
        windowGraph.ShowGraph(finalScript.submitCountList);
    }
    private void SubmitLog_OnAddSubmit(object sender, EventArgs e)
    {
        windowGraph.UpdateValue(finalScript.submitCountList.Count - 1, finalScript.submitCountList[finalScript.submitCountList.Count - 1]);
    }
    public void HideFinal()
    {
        windowGraph.gameObject.SetActive(false);
        finalScript.OnAddSubmit -= SubmitLog_OnAddSubmit;
        finalScript.OnNewMinute -= SubmitLog_OnNewMinute;
    }
}
