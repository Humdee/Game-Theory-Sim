using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonScript : MonoBehaviour
{
    public static ButtonScript instance;
    public List<GameObject> DevListToStart, DevListToStrat, DevListToChangeStrat;
    private TMP_Text startWorkBtnText, showGraphBtntext;
    private TMP_Text devSliderText, workSliderText, timeSliderText, startStrategyText, testerSliderText, avrgWorkTimeText;
    public string strat;
    public Slider devSlider, workSlider, timeSlider, avrgWorkTimeSlider;
    public Button createButton, stratButton;
    public GameObject[] tabs;
    public int[] graphArray;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
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
        avrgWorkTimeSlider = transform.Find("TAB/Tabs/Tab1/AverageTimeSlider").GetComponent<Slider>();
        avrgWorkTimeText = transform.Find("TAB/Tabs/Tab1/AverageTimeSlider/AverageTimeText").GetComponent<TMP_Text>();

        createButton = transform.Find("TAB/Tabs/Tab1/CreateButton").GetComponent<Button>();
        stratButton = transform.Find("TAB/Tabs/Tab1/StartStrategyButton").GetComponent<Button>();

        for (int i = 0; i < tabs.Length; i++)
        {
            tabs[i].SetActive(false);
        }
        tabs[0].SetActive(true);
    }
    public void OnStartWorkButtonPressed()
    {
        changeStartStrategy();
        DevListToStart = CreateDev.instance.DevList;
        foreach (GameObject dev in DevListToStart)
        {
            dev.GetComponent<DevScript>().startWork = !dev.GetComponent<DevScript>().startWork;
            dev.GetComponent<DevScript>().StartWork();
        }
        FinalGraph.instance.startGraph = !FinalGraph.instance.startGraph;
        FixGraph.instance.startGraph = !FixGraph.instance.startGraph;
        KludgeGraph.instance.startGraph = !KludgeGraph.instance.startGraph;
        if (FinalGraph.instance.startGraph)
        {
            startWorkBtnText.text = "Stop work";
        }
        else startWorkBtnText.text = "Start work";
        Clock.instance.startWork = !Clock.instance.startWork;
        stratButton.interactable = false;
    }
    public void OnResetButtonPressed()
    {
        ScenesManager.instance.LoadScene(ScenesManager.Scene.SimulationScene);
    }
    public void OnShowGraphButtonPressed()
    {
        FinalGraph.instance.viewGraph = !FinalGraph.instance.viewGraph;
        if (FinalGraph.instance.viewGraph)
        {
            showGraphBtntext.text = "Hide Graph";
        }
        else showGraphBtntext.text = "Show Graph";
    }
    public void OnCreateButtonPressed()
    {
        int devToCreate = Mathf.RoundToInt(devSlider.value);
        for (int i = 0; i < devToCreate; i++)
        {
            // CreateDev.instance.CreateOneDev();
            CreateDev.instance.CreateOneSpriteDev();
        }
        int workToCreate = Mathf.RoundToInt(workSlider.value);
        for (int j = 0; j < workToCreate; j++)
        {
            ToDoScript.instance.CreateOneWork();
        }
        devSlider.interactable = false;
        workSlider.interactable = false;
        DoubleSliderScript.instance.sliderMin.interactable = false;
        DoubleSliderScript.instance.sliderMax.interactable = false;
        avrgWorkTimeSlider.interactable = false;
        createButton.interactable = false;
    }
    public void OnStartStrategyButtonPressed()
    {
        DevListToStrat = CreateDev.instance.DevList;
        if (strat == "Start Fix")
        {
            strat = "Start Kludge";
            foreach (GameObject dev in DevListToStrat)
            {
                dev.GetComponent<DevScript>().DevStrat = "Kludge";
            }
        }
        else if (strat == "Start Kludge")
        {
            strat = "Start Random";
            foreach (GameObject dev in DevListToStrat)
            {
                dev.GetComponent<DevScript>().DevStrat = "Random";
            }
        }
        else if (strat == "Start Random")
        {
            strat = "Start Fix";
            foreach (GameObject dev in DevListToStrat)
            {
                dev.GetComponent<DevScript>().DevStrat = "Fix";
            }
        }
        else Debug.Log("Hehehe Wrong Start Strategy");
        startStrategyText.text = strat;
    }
    public void changeStartStrategy()
    {
        DevListToChangeStrat = CreateDev.instance.DevList;
        if (strat == "Start Fix")
        {
            foreach (GameObject dev in DevListToChangeStrat)
            {
                dev.GetComponent<DevScript>().DevStrat = "Fix";
            }
        }
        else if (strat == "Start Kludge")
        {
            foreach (GameObject dev in DevListToChangeStrat)
            {
                dev.GetComponent<DevScript>().DevStrat = "Kludge";
            }
        }
        else if (strat == "Start Random")
        {
            foreach (GameObject dev in DevListToChangeStrat)
            {
                dev.GetComponent<DevScript>().DevStrat = "Random";
            }
        }
        else Debug.Log("Hehehe can't change Strategy");
    }
    public void UpdateDevSliderText()
    {
        devSliderText.text = devSlider.value.ToString() + " Devs";
    }
    public void UpdateWorkSliderText()
    {
        workSliderText.text = workSlider.value.ToString() + " Works";
    }
    public void UpdateTimeSliderText()
    {
        timeSliderText.text = timeSlider.value.ToString() + " Minutes";
    }
    public void OnSaveButtonPressed()
    {
        getGraphList();
        SaveSystem.SaveParameter(this);
    }
    public void OnLoadButtonPressed()
    {
        UserData data = SaveSystem.LoadData();
        devSlider.value = data.dev;
        workSlider.value = data.work;
        FinalScript.instance.submitCountList = data.graphArray.ToList();
    }
    public void LoadData(UserStats data)
    {
        devSlider.value = data.dev;
        workSlider.value = data.work;
        avrgWorkTimeSlider.value = data.averageWork;
        DoubleSliderScript.instance.sliderMin.value = data.fixRework;
        DoubleSliderScript.instance.sliderMax.value = data.kludgeRework;
        strat = data.startStrat;
        Clock.instance.timeText.text = data.duration;
        WorkCounter.instance.quality = data.finalQuality;
        WorkCounter.instance.fixCount = data.finalFix;
        WorkCounter.instance.kludgeCount = data.finalKludge;
        FinalScript.instance.submitCountList = data.finalGraphArray.ToList();
        FixScript.instance.submitFixList = data.fixGraphArray.ToList();
        KludgeScript.instance.submitKludgeList = data.kludgeGraphArray.ToList();
        WorkCounter.instance.showCount();
    }
    public void getGraphList()
    {
        graphArray = FinalScript.instance.submitCountList.ToArray();
    }
    public void TurnOnTabs(int tab)
    {
        for (int i = 0; i < tabs.Length; i++)
        {
            tabs[i].SetActive(false);
        }
        tabs[tab - 1].SetActive(true);
        if (tabs[2 - 1].activeSelf)
        {
            FinalGraph.instance.ShowFinal();
            FixGraph.instance.Showfix();
            KludgeGraph.instance.ShowKludge();
            showGraphBtntext.text = "Show Graph";
        }
        else
        {
            FinalGraph.instance.HideFinal();
            FixGraph.instance.Hidefix();
            KludgeGraph.instance.HideKludge();
            showGraphBtntext.text = "Hide Graph";
        }
    }
    public void UpdateAvrgWorkTimeSlider()
    {
        avrgWorkTimeText.text = avrgWorkTimeSlider.value.ToString() + " minute average work";
        NormalScript.instance.mean = avrgWorkTimeSlider.value;
    }
}
