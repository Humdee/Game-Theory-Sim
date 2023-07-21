using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DevScript : MonoBehaviour
{
    public bool startWork;
    [SerializeField] private float randomTak, randomMan, randomSub, randomNex, repeatTimer;
    public string DevStrat;
    public bool isKludging, isFixing;
    private bool isWalkTodo, isWalkDone;
    public List<GameObject> DevWorkList;
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] NavMeshAgent navSelf;
    [SerializeField] private GameObject todo, done;
    [SerializeField] private Transform todoPoint, donePoint;
    void Start()
    {
        navSelf = GetComponent<NavMeshAgent>();
        sr = transform.Find("sr").GetComponent<SpriteRenderer>();
        startWork = false;
        isKludging = false;
        isFixing = true;
        DevStrat = "Fix";
        randomTak = Mathf.Round(NormalScript.instance.GenerateRandomNumber());
        randomMan = Mathf.Round(NormalScript.instance.GenerateRandomNumber());
        randomSub = Mathf.Round(NormalScript.instance.GenerateRandomNumber());
        randomNex = Mathf.Round(NormalScript.instance.GenerateRandomNumber());
        isWalkTodo = false;
        isWalkDone = false;
        todo = GameObject.Find("ToDoEnv");
        todoPoint = todo.transform;
        done = GameObject.Find("DoneEnv");
        donePoint = done.transform;
    }
    void Update()
    {
        repeatTimer -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Z))
        {
            startWork = !startWork;
            StartWork();
        }
        if (isWalkTodo == true && isWalkDone == false)
        {
            GetComponent<RandomMovement>().enabled = false;
            gotoTodo();
        }
        if (isWalkDone == true && isWalkTodo == false)
        {
            GetComponent<RandomMovement>().enabled = false;
            gotoDone();
        }
    }
    void timer()
    {
        repeatTimer = randomTak + randomMan + randomSub + randomNex;
    }
    public void StartWork()
    {
        if (startWork == true)
        {
            CheckStrat();
            timer();
            Invoke("TakeWork", randomTak);
        }
    }
    void CountWork()
    {
        if (DevWorkList.Count > 2)
        {
            DevStrat = "Campuran";
        }
        else
        {
            DevStrat = "Baiki";
        }
    }
    void CheckStrat()
    {
        if (DevStrat == "Campuran" && isKludging == false && isFixing == true)
        {
            randomTak = randomTak / 2;
            randomMan = randomMan / 2;
            randomSub = randomSub / 2;
            randomNex = randomNex / 2;
            isKludging = true;
            isFixing = false;
        }
        else if (DevStrat == "Baiki" && isKludging == true && isFixing == false)
        {
            randomTak = randomTak * 2;
            randomMan = randomMan * 2;
            randomSub = randomSub * 2;
            randomNex = randomNex * 2;
            isFixing = true;
            isKludging = false;
        }
        else if (DevStrat == "Rawak")
        {
            float rando = Mathf.Round(Random.value * 10f);
            if (rando <= 5)
            {
                DevStrat = "Baiki";
            }
            else
            {
                DevStrat = "Campuran";
            }
            CheckStrat();
        }
    }
    void TakeWork()
    {
        isWalkTodo = true;
        isWalkDone = false;
        if (ToDoScript.instance.ToDoList.Count > 0)
        {
            GameObject work = ToDoScript.instance.ToDoList[0];
            DevWorkList.Add(work);
            ToDoScript.instance.RemoveOneWork();
            Invoke("ManipulateWork", randomMan);
        }
        else if (DevWorkList.Count > 0)
        {
            Invoke("ManipulateWork", randomMan);
        }
    }
    void ManipulateWork()
    {
        if (DevWorkList.Count > 0)
        {
            DevWorkList[0].GetComponent<workScript>().Strat = DevStrat;
            DevWorkList[0].GetComponent<workScript>().getDevName(this);
            Invoke("SubmitWork", randomSub);
        }
    }
    void SubmitWork()
    {
        isWalkTodo = false;
        isWalkDone = true;
        if (DevWorkList.Count > 0)
        {
            GameObject work = DevWorkList[0];
            DoneScript.instance.DoneList.Add(work);
            DevWorkList.RemoveAt(0);
            Invoke("NextWork", randomNex);
        }
    }
    void NextWork()
    {
        if (startWork == true)
        {
            CountWork();
            CheckStrat();
            timer();
            Invoke("TakeWork", randomTak);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "station")
        {
            freeRoam();
        }
    }
    void freeRoam()
    {
        resetPath();
        isWalkTodo = false;
        isWalkDone = false;
        GetComponent<RandomMovement>().enabled = true;
    }
    void gotoTodo() { navSelf.speed = 10; navSelf.destination = todoPoint.position; faceCheck(); }
    void gotoDone() { navSelf.speed = 10; navSelf.destination = donePoint.position; faceCheck(); }
    void resetPath() { navSelf.isStopped = true; navSelf.ResetPath(); navSelf.speed = 3.5f; navSelf.isStopped = false; }
    void faceCheck()
    {
        float xMovement = navSelf.velocity.x;
        if (xMovement != 0 && xMovement < 0)
        {
            sr.flipX = true;
        }
        else if (xMovement != 0 && xMovement > 0)
        {
            sr.flipX = false;
        }
    }
}
// randomTak = Mathf.Round(Random.Range(5f, 10f));
// randomMan = Mathf.Round(Random.Range(5f, 10f));
// randomSub = Mathf.Round(Random.Range(5f, 10f));
// randomNex = Mathf.Round(Random.Range(5f, 10f));