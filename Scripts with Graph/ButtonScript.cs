using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonScript : MonoBehaviour
{
    public List<GameObject> DevListToStart;
    private TMP_Text startWorkBtnText, showGraphBtntext;
    private TMP_Text devSliderText, workSliderText;
    private Slider devSlider, workSlider;
    private void Start() {
        startWorkBtnText = transform.Find("StartWorkButton/StartButtonText").GetComponent<TMP_Text>();
        showGraphBtntext = transform.Find("ShowGraphButton/GraphButtonText").GetComponent<TMP_Text>();

        devSlider = transform.Find("DevSlider").GetComponent<Slider>();
        devSliderText = transform.Find("DevSlider/DevSliderText").GetComponent<TMP_Text>();
        workSlider = transform.Find("WorkSlider").GetComponent<Slider>();
        workSliderText = transform.Find("WorkSlider/WorkSliderText").GetComponent<TMP_Text>();
    }
    public void OnStartWorkButtonPressed() {
        DevListToStart = CreateDev.instance.DevList;
        foreach (GameObject dev in DevListToStart)
        {
            dev.GetComponent<DevScript>().startWork = !dev.GetComponent<DevScript>().startWork;
            dev.GetComponent<DevScript>().StartWork();
        }
        FinalGraph.instance.startGraph = !FinalGraph.instance.startGraph;
        if (FinalGraph.instance.startGraph)
        {
            startWorkBtnText.text = "Stop work";
        } else startWorkBtnText.text = "Start work";
    }
    public void OnShowGraphButtonPressed() {
        FinalGraph.instance.viewGraph = !FinalGraph.instance.viewGraph;
        if (FinalGraph.instance.viewGraph)
        {
            showGraphBtntext.text = "Hide Graph";
        } else showGraphBtntext.text = "Show Graph";
    }
    public void OnCreateButtonPressed() {
        int devToCreate = Mathf.RoundToInt(devSlider.value);
        for (int i = 0; i < devToCreate; i++) {
            CreateDev.instance.CreateOneDev();
        }
        int workToCreate = Mathf.RoundToInt(workSlider.value);
        for (int j = 0; j < workToCreate; j++) {
            ToDoScript.instance.CreateOneWork();
        }
    }
    public void UpdateDevSliderText() {
        devSliderText.text = devSlider.value.ToString() + " Devs";
    }
    public void UpdateWorkSliderText() {
        workSliderText.text = workSlider.value.ToString() + " Works";
    }
}
