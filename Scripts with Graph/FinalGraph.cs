using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey;
using CodeMonkey.Utils;

public class FinalGraph : MonoBehaviour
{
    private Window_Graph windowGraph;
    private FinalScript finalScript;
    private GameObject windowCanvas;
    [SerializeField] private float timerOneSecond, timerOneMinute;
    [SerializeField] private bool startWork;
    private void Awake() {
        startWork = false;
        Setup();
    }
    public void Setup() {
        windowCanvas = GameObject.Find("Canvas");
        finalScript = GetComponent<FinalScript>();
        windowGraph = transform.Find("Canvas/pfWindow_Graph").GetComponent<Window_Graph>();
        windowGraph.SetGetAxisLabelX((int _i) => {
            string minuteString = _i.ToString();
            return minuteString + " minutes";
        });
    }
    public void Update() {
        // if (Input.GetKeyDown(KeyCode.Z)) {
        //     startWork = !startWork;
        // }
        // if (startWork == true) {
        //     timerOneSecond += Time.deltaTime;
        //     timerOneMinute += Time.deltaTime;
        //     if (timerOneSecond > 1) {
        //         windowGraph.ShowGraph(finalScript.submitCountList);
        //         finalScript.OnAddSubmit += SubmitLog_OnAddSubmit;
        //         finalScript.OnNewMinute += SubmitLog_OnNewMinute;
        //         timerOneSecond = 0;
        //     }
        //     if (timerOneMinute > 60) {
        //         FinalScript.instance.Clock_OnNewMinute();
        //         timerOneMinute = 0;
        //     }
        // }
        if (Input.GetKeyDown(KeyCode.X))
        {
            Show();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            Hide();
        }
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
