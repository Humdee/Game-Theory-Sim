using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonScript : MonoBehaviour
{
    public bool startWork;
    public List<GameObject> DevListToStart;
    public TMP_Text startWorkBtnText;
    private void Start() {
        startWorkBtnText = transform.Find("Button/StartButtonText").GetComponent<TMP_Text>();
    }
    public void OnStartWorkButtonPressed() {
        startWork = !startWork;
        DevListToStart = CreateDev.instance.DevList;
        foreach (GameObject dev in DevListToStart)
        {
            dev.GetComponent<DevScript>().startWork = !dev.GetComponent<DevScript>().startWork;
            dev.GetComponent<DevScript>().StartWork();
        }
        FinalGraph.instance.startGraph = !FinalGraph.instance.startGraph;
        if (startWork)
        {
            startWorkBtnText.text = "Stop work";
        } else startWorkBtnText.text = "Start work";
    }
}
