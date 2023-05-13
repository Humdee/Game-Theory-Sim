using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesterScript : MonoBehaviour
{
    [SerializeField] private float timer;
    public List<GameObject> TesterWorkList;
    void Start() {
        timer = 0;
    }
    void Update() {
        timer += Time.deltaTime;
        if (timer > 1)
        {
            timer = 0;
            CheckDone();
        }
    }
    void CheckDone() {
        if (DoneScript.instance.DoneList.Count > 0)
        {
            GameObject workToCheck = DoneScript.instance.DoneList[0];
            TesterWorkList.Add(workToCheck);
            DoneScript.instance.RemoveOneDone();
            Invoke("TestWork", 1);
        }
    }
    void TestWork() {
        if (TesterWorkList.Count > 0)
        {
            GameObject workToTest = TesterWorkList[0];
            if (workToTest.GetComponent<workScript>().Strat == "Fix")
            {
                float randomTest = Mathf.Round(Random.value * 100f);
                if (randomTest <= 20)
                {
                    SubmitRework();
                } else
                {
                    SubmitFinal();
                }
            } else if (workToTest.GetComponent<workScript>().Strat == "Kludge")
            {
                float randomTest = Mathf.Round(Random.value * 100f);
                if (randomTest <= 80)
                {
                    SubmitRework();
                } else
                {
                    SubmitFinal();
                }
            } else
            {
                Debug.Log("There is problem here..");
            }
        }
    }
    void SubmitRework() {
        GameObject Rework = TesterWorkList[0];
        Rework.GetComponent<workScript>().isRememberedDev();
        // ToDoScript.instance.ToDoList.Add(Rework);
        TesterWorkList.RemoveAt(0);
    }
    void SubmitFinal() {
        GameObject Final = TesterWorkList[0];
        FinalScript.instance.FinalList.Add(Final);
        FinalScript.instance.AddSubmit();
        TesterWorkList.RemoveAt(0);
    }
}
