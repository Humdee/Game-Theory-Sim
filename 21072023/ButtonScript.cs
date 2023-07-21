using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonScript : MonoBehaviour, IDataPersistence
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
    [SerializeField] private Animator transition;
    [SerializeField] private Button startWorkButton;
    private float transitionTime = 1f;
    private void Awake()
    {
        instance = this;
        devSlider = transform.Find("TAB/Tabs/Tab1/DevSlider").GetComponent<Slider>();
        devSliderText = transform.Find("TAB/Tabs/Tab1/DevSlider/DevSliderText").GetComponent<TMP_Text>();
        workSlider = transform.Find("TAB/Tabs/Tab1/WorkSlider").GetComponent<Slider>();
        workSliderText = transform.Find("TAB/Tabs/Tab1/WorkSlider/WorkSliderText").GetComponent<TMP_Text>();
    }
    private void Start()
    {
        startWorkButton.interactable = false;
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
            startWorkBtnText.text = "Berhenti";
        }
        else startWorkBtnText.text = "Mula Kerja";
        Clock.instance.startWork = !Clock.instance.startWork;
        stratButton.interactable = false;
    }
    public void OnResetButtonPressed()
    {
        // ScenesManager.instance.LoadScene(ScenesManager.Scene.SimulationScene);
        ScenesManager.instance.RefreshScene();
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
        startWorkButton.interactable = true;
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
        if (strat == "Mula Baiki")
        {
            strat = "Mula Campuran";
            foreach (GameObject dev in DevListToStrat)
            {
                dev.GetComponent<DevScript>().DevStrat = "Campuran";
            }
        }
        else if (strat == "Mula Campuran")
        {
            strat = "Mula Rawak";
            foreach (GameObject dev in DevListToStrat)
            {
                dev.GetComponent<DevScript>().DevStrat = "Rawak";
            }
        }
        else if (strat == "Mula Rawak")
        {
            strat = "Mula Baiki";
            foreach (GameObject dev in DevListToStrat)
            {
                dev.GetComponent<DevScript>().DevStrat = "Baiki";
            }
        }
        else Debug.Log("Hehehe Wrong Start Strategy");
        startStrategyText.text = strat;
    }
    public void changeStartStrategy()
    {
        DevListToChangeStrat = CreateDev.instance.DevList;
        if (strat == "Mula Baiki")
        {
            foreach (GameObject dev in DevListToChangeStrat)
            {
                dev.GetComponent<DevScript>().DevStrat = "Baiki";
            }
        }
        else if (strat == "Mula Campuran")
        {
            foreach (GameObject dev in DevListToChangeStrat)
            {
                dev.GetComponent<DevScript>().DevStrat = "Campuran";
            }
        }
        else if (strat == "Mula Rawak")
        {
            foreach (GameObject dev in DevListToChangeStrat)
            {
                dev.GetComponent<DevScript>().DevStrat = "Rawak";
            }
        }
        else Debug.Log("Hehehe can't change Strategy");
    }
    public void UpdateDevSliderText()
    {
        devSliderText.text = devSlider.value.ToString() + " Pembangun";
    }
    public void UpdateWorkSliderText()
    {
        workSliderText.text = workSlider.value.ToString() + " Kerja";
    }
    public void UpdateTimeSliderText()
    {
        timeSliderText.text = timeSlider.value.ToString() + " Minit";
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
    public void LoadData(GameData data)
    {
        this.devSlider.value = data.dev;
        this.workSlider.value = data.work;
        DoubleSliderScript.instance.sliderMin.value = data.fixRework;
        DoubleSliderScript.instance.sliderMax.value = data.kludgeRework;
        this.avrgWorkTimeSlider.value = data.averageWork;
        this.strat = data.startStrat;
        Clock.instance.hour = data.hour;
        Clock.instance.timeText.text = data.duration;
        WorkCounter.instance.quality = data.finalQuality;
        WorkCounter.instance.fixCount = data.finalFix;
        WorkCounter.instance.kludgeCount = data.finalKludge;
        FinalScript.instance.submitCountList = data.finalGraphArray;
        FixScript.instance.submitFixList = data.fixGraphArray;
        KludgeScript.instance.submitKludgeList = data.kludgeGraphArray;
        ToDoScript.instance.ToDoList = data.todoArray;
        DoneScript.instance.DoneList = data.doneArray;
        WorkCounter.instance.showCount();
        // OnCreateButtonPressed();
        TurnOnTabs(2);
    }
    public void SaveData(GameData data)
    {
        data.dev = this.devSlider.value;
        data.work = this.workSlider.value;
        data.fixRework = DoubleSliderScript.instance.sliderMin.value;
        data.kludgeRework = DoubleSliderScript.instance.sliderMax.value;
        data.averageWork = this.avrgWorkTimeSlider.value;
        data.startStrat = this.strat;
        data.hour = Clock.instance.hour;
        data.duration = Clock.instance.timeText.text;
        data.finalQuality = WorkCounter.instance.quality;
        data.finalFix = WorkCounter.instance.fixCount;
        data.finalKludge = WorkCounter.instance.kludgeCount;
        data.finalGraphArray = FinalScript.instance.submitCountList;
        data.fixGraphArray = FixScript.instance.submitFixList;
        data.kludgeGraphArray = KludgeScript.instance.submitKludgeList;
        data.todoArray = ToDoScript.instance.ToDoList;
        data.doneArray = DoneScript.instance.DoneList;
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
        if (tabs[3 - 1].activeSelf)
        {
            SaveSlotsMenu.instance.ActivateMenu();
        }
    }
    public void UpdateAvrgWorkTimeSlider()
    {
        avrgWorkTimeText.text = avrgWorkTimeSlider.value.ToString() + " minit purata kerja";
        NormalScript.instance.mean = avrgWorkTimeSlider.value;
    }
    public void OnNextButtonPressed()
    {
        SoundManager.instance.PlayButtonSound();
        // ScenesManager.instance.LoadNextScene();
        StartCoroutine(SceneTransition());
    }
    IEnumerator SceneTransition()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        ScenesManager.instance.LoadNextScene();
    }
}
