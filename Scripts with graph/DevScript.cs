using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevScript : MonoBehaviour
{
    public bool startWork;
    [SerializeField] private float randomTak, randomMan, randomSub, randomNex, repeatTimer;
    public string DevStrat;
    public bool isKludging, isFixing;
    public List<GameObject> DevWorkList;
    void Start() {
        startWork = false;
        isKludging = false;
        isFixing = true;
        DevStrat = "Fix";
        randomTak = Mathf.Round(Random.value * 10f);
        randomMan = Mathf.Round(Random.value * 10f);
        randomSub = Mathf.Round(Random.value * 10f);
        randomNex = Mathf.Round(Random.value * 10f);
    }
    void Update() {
        repeatTimer -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Z))
        {
            startWork = !startWork;
            StartWork();
        }
    }
    void timer() {
        repeatTimer = randomTak + randomMan + randomSub + randomNex;
    }
    public void StartWork() {
        if (startWork == true)
        {
            CheckStrat();
            timer();
            Invoke("TakeWork", randomTak);
        }
    }
    void CountWork() {
        if (DevWorkList.Count > 2)
        {
            DevStrat = "Kludge";
        } else
        {
            DevStrat = "Fix";
        }
    }
    void CheckStrat() {
        if (DevStrat == "Kludge" && isKludging == false && isFixing == true)
        {
            randomTak = randomTak/2;
            randomMan = randomMan/2;
            randomSub = randomSub/2;
            randomNex = randomNex/2;
            isKludging = true;
            isFixing = false;
        } else if (DevStrat == "Fix" && isKludging == true && isFixing == false)
        {
            randomTak = randomTak*2;
            randomMan = randomMan*2;
            randomSub = randomSub*2;
            randomNex = randomNex*2;
            isFixing = true;
            isKludging = false;
        } else if (DevStrat == "Random")
        {
            float rando = Mathf.Round(Random.value * 10f);
            if (rando <= 5)
            {
                DevStrat = "Fix";
            } else
            {
                DevStrat = "Kludge";
            }
            CheckStrat();
        }
    }
    void TakeWork() {
        if (ToDoScript.instance.ToDoList.Count > 0)
        {
            GameObject work = ToDoScript.instance.ToDoList[0];
            DevWorkList.Add(work);
            ToDoScript.instance.RemoveOneWork();
            Invoke("ManipulateWork", randomMan);
        } else if (DevWorkList.Count > 0)
        {
            Invoke("ManipulateWork", randomMan);
        }
    }
    void ManipulateWork() {
        if (DevWorkList.Count > 0)
        {
            DevWorkList[0].GetComponent<workScript>().Strat = DevStrat;
            DevWorkList[0].GetComponent<workScript>().getDevName(this);
            Invoke("SubmitWork", randomSub);
        }
    }
    void SubmitWork() {
        if (DevWorkList.Count > 0)
        {
            GameObject work = DevWorkList[0];
            DoneScript.instance.DoneList.Add(work);
            DevWorkList.RemoveAt(0);
            Invoke("NextWork", randomNex);
        }
    }
    void NextWork() {
        if (startWork == true)
            {
                CountWork();
                CheckStrat();
                timer();
                Invoke("TakeWork", randomTak);
            }
    }
}