using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevScript : MonoBehaviour
{
    [SerializeField] private bool startWork;
    [SerializeField] private float randomTak, randomMan, randomSub, timer;
    public float randomGen;
    public List<GameObject> DevWorkList;
    void Start() {
        startWork = false;
        randomTak = Mathf.Round(Random.value * 10f);
        randomMan = Mathf.Round(Random.value * 10f);
        randomSub = Mathf.Round(Random.value * 10f);
    }
    void Update() {
        timer += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Z))
        {
            startWork = !startWork;
            StartWork();
        }
    }
    void StartWork() {
        if (startWork == true)
        {
            Invoke("TakeWork", randomTak);
        }
    }
    void TakeWork() {
        if (ToDoScript.instance.ToDoList.Count > 0)
        {
            GameObject work = ToDoScript.instance.ToDoList[0];
            DevWorkList.Add(work);
            ToDoScript.instance.RemoveOneWork();
            Invoke("ManipulateWork", randomMan);
        }
    }
    void ManipulateWork() {
        if (DevWorkList.Count > 0)
        {
            randomGen = Mathf.Round(Random.value * 100f);
            DevWorkList[0].GetComponent<workScript>().randomNum = randomGen;
            DevWorkList[0].GetComponent<workScript>().StratChosen();
            Invoke("SubmitWork", randomSub);
        }
    }
    void SubmitWork() {
        if (DevWorkList.Count > 0)
        {
            GameObject work = DevWorkList[0];
            DoneScript.instance.DoneList.Add(work);
            DevWorkList.RemoveAt(0);
            if (startWork == true)
            {
                Invoke("TakeWork", randomTak);
            }
        }
    }
}