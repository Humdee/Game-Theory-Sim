using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalGraph : MonoBehaviour
{
    public static FinalGraph instance;
    private Window_Graph windowGraph;
    private FinalScript finalScript;
    [SerializeField] private float timerOneMinute;
    public bool startGraph, viewGraph;
    void Awake() {
        instance = this;
        Setup();
    }
    void Start() {
        startGraph = false;
        viewGraph = false;
    }
    public void Setup() {
        finalScript = GetComponent<FinalScript>();
        windowGraph = transform.Find("GraphCanvas/pfWindow_Graph").GetComponent<Window_Graph>();
        windowGraph.SetGetAxisLabelX((int _i) => {
            string minuteString = _i + " minutes";
            return minuteString;
        });
        Hide();
    }
    public void Update() {
        if (Input.GetKeyDown(KeyCode.Z)) {
            startGraph = !startGraph;
        }
        if (startGraph == true) {
            timerOneMinute += Time.deltaTime;
            if (timerOneMinute > 60) {
                finalScript.Clock_OnNewMinute();
                timerOneMinute = 0;
            }
        }
        if (viewGraph)
        {
            Show();
        } else Hide();
    }
    public void Show() {
        windowGraph.gameObject.SetActive(true);
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
        windowGraph.gameObject.SetActive(false);
        finalScript.OnAddSubmit -= SubmitLog_OnAddSubmit;
        finalScript.OnNewMinute -= SubmitLog_OnNewMinute;
    }
}
