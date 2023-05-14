using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonScript : MonoBehaviour
{
    public List<GameObject> DevListToStart, DevListToStrat;
    private TMP_Text startWorkBtnText, showGraphBtntext;
    private TMP_Text devSliderText, workSliderText, timeSliderText, startStrategyText, testerSliderText;
    private string strat;
    public Slider devSlider, workSlider, timeSlider;
    public GameObject[] tabs;
    public int[] graphArray;
    private void Start() {
        startWorkBtnText = transform.Find("StartWorkButton/StartButtonText").GetComponent<TMP_Text>();
        showGraphBtntext = transform.Find("ShowGraphButton/GraphButtonText").GetComponent<TMP_Text>();
        startStrategyText = transform.Find("TAB/Tabs/Tab1/StartStrategyButton/StartStrategyText").GetComponent<TMP_Text>();
        strat = startStrategyText.text;

        devSlider = transform.Find("TAB/Tabs/Tab1/DevSlider").GetComponent<Slider>();
        devSliderText = transform.Find("TAB/Tabs/Tab1/DevSlider/DevSliderText").GetComponent<TMP_Text>();
        workSlider = transform.Find("TAB/Tabs/Tab1/WorkSlider").GetComponent<Slider>();
        workSliderText = transform.Find("TAB/Tabs/Tab1/WorkSlider/WorkSliderText").GetComponent<TMP_Text>();
        timeSlider = transform.Find("TimeSlider").GetComponent<Slider>();
        timeSliderText = transform.Find("TimeSlider/TimeSliderText").GetComponent<TMP_Text>();

        for (int i = 0; i < tabs.Length; i++)
        {
            tabs[i].SetActive(false);
        } tabs[0].SetActive(true);
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
        Clock.instance.startWork = !Clock.instance.startWork;
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
    public void OnStartStrategyButtonPressed() {
        DevListToStrat = CreateDev.instance.DevList;
        if (strat == "Start Fix")
        {
            strat = "Start Kludge";
            foreach (GameObject dev in DevListToStrat)
            {
                dev.GetComponent<DevScript>().DevStrat = "Kludge";
            }
        } else if (strat == "Start Kludge")
        {
            strat = "Start Random";
            foreach (GameObject dev in DevListToStrat)
            {
                dev.GetComponent<DevScript>().DevStrat = "Random";
            }
        } else if (strat == "Start Random")
        {
            strat = "Start Fix";
            foreach (GameObject dev in DevListToStrat)
            {
                dev.GetComponent<DevScript>().DevStrat = "Fix";
            }
        } else Debug.Log("Hehehe Wrong Start Strategy");
        startStrategyText.text = strat;
    }
    public void UpdateDevSliderText() {
        devSliderText.text = devSlider.value.ToString() + " Devs";
    }
    public void UpdateWorkSliderText() {
        workSliderText.text = workSlider.value.ToString() + " Works";
    }
    public void UpdateTimeSliderText() {
        timeSliderText.text = timeSlider.value.ToString() + " Minutes";
    }
    public void OnSaveButtonPressed() {
        getGraphList();
        SaveSystem.SaveParameter(this);
    }
    public void OnLoadButtonPressed() {
        UserData data = SaveSystem.LoadData();
        devSlider.value = data.dev;
        workSlider.value = data.work;
        FinalScript.instance.submitCountList = data.graphArray.ToList();
    }
    public void getGraphList() {
        graphArray = FinalScript.instance.submitCountList.ToArray();
    }
    public void TurnOnTabs(int tab) {
        for (int i = 0; i < tabs.Length; i++)
        {
            tabs[i].SetActive(false);
        }
        tabs[tab - 1].SetActive(true);
        if (tabs[2 - 1].activeSelf) {
            FinalGraph.instance.Show();
            showGraphBtntext.text = "Show Graph";
        } else {
            FinalGraph.instance.Hide();
            showGraphBtntext.text = "Hide Graph";
        }
    }
}
