using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToDoScript : MonoBehaviour
{
    public GameObject WorkPrefab;
    public List<GameObject> ToDoList;
    public static ToDoScript instance;
    void Awake() {
        instance = this;
    }
    void Update() {
        if (Input.GetKeyDown(KeyCode.A))
        {
            GameObject work = Instantiate(WorkPrefab);
            ToDoList.Add(work);
        }
    }
    public void RemoveOneWork() {
        GameObject WorkTakenByDev = ToDoList[0];
        ToDoList.Remove(WorkTakenByDev);
    }
}
