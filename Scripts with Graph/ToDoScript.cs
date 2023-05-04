using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToDoScript : MonoBehaviour
{
    public GameObject WorkPrefab;
    public List<GameObject> ToDoList;
    public static ToDoScript instance;
    private int Create50work;
    void Awake() {
        instance = this;
        Create50work = 0;
    }
    void Update() {
        if (Input.GetKeyDown(KeyCode.A))
        {
            GameObject work = Instantiate(WorkPrefab);
            ToDoList.Add(work);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            CreateBunchWork();
        }
    }
    public void CreateOneWork() {
        GameObject work = Instantiate(WorkPrefab);
        ToDoList.Add(work);
    }
    private void CreateBunchWork() {
        while (Create50work < 50)
        {
            GameObject work = Instantiate(WorkPrefab);
            ToDoList.Add(work);
            Create50work++;
        }
        Create50work = 0;
    }
    public void RemoveOneWork() {
        GameObject WorkTakenByDev = ToDoList[0];
        ToDoList.Remove(WorkTakenByDev);
    }
}
