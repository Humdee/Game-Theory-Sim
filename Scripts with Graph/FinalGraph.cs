using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalGraph : MonoBehaviour
{
    public static FinalGraph instance;
    private Window_Graph windowGraph;
    private FinalScript finalScript;
    private GameObject windowCanvas;
    [SerializeField] private float timerOneSecond, timerOneMinute;
    public bool startGraph, viewGraph;
    private void Awake() {
        instance = this;
        Setup();
        startGraph = false;
        viewGraph = false;
    }
    public void Setup() {
        windowCanvas = GameObject.Find("GraphCanvas");
        finalScript = GetComponent<FinalScript>();
        windowGraph = transform.Find("GraphCanvas/pfWindow_Graph").GetComponent<Window_Graph>();
        windowGraph.SetGetAxisLabelX((int _i) => {
            string minuteString = _i + " minutes";
            return minuteString;
        });
    }
    public void Update() {
        if (Input.GetKeyDown(KeyCode.Z)) {
            startGraph = !startGraph;
        }
        if (startGraph == true) {
            timerOneMinute += Time.deltaTime;
            if (timerOneMinute > 60) {
                FinalScript.instance.Clock_OnNewMinute();
                timerOneMinute = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            viewGraph = !viewGraph;
        }
        if (viewGraph)
        {
            timerOneSecond += Time.deltaTime;
            if (timerOneSecond > 1)
            {
                Show();
                timerOneSecond = 0;
            }
        }
        else Hide();
    }
    public void Show() {
        windowCanvas.gameObject.SetActive(true);
        finalScript = GetComponent<FinalScript>();
        windowGraph.ShowGraph(finalScript.submitCountList);
        finalScript.OnAddSubmit += SubmitLog_OnAddSubmit;
        finalScript.OnNewMinute += SubmitLog_OnNewMinute;
    }
    private void SubmitLog_OnNewMinute(object sender, EventArgs e) {
        windowGraph.ShowGraph(finalScript.submitCountList);
    }
    private void SubmitLog_OnAddSubmit(object sender, EventArgs e) {
        windowGraph.UpdateValue(finalScript.submitCountList.Count - 1, finalScript.submitCountList[finalScript.submitCountList.Count - 1]);
    }
    public void Hide() {
        windowCanvas.gameObject.SetActive(false);
        finalScript.OnAddSubmit -= SubmitLog_OnAddSubmit;
        finalScript.OnNewMinute -= SubmitLog_OnNewMinute;
    }
}
