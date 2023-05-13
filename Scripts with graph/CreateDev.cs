using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateDev : MonoBehaviour
{
    public static CreateDev instance;
    public GameObject devPrefab;
    public List<GameObject> DevList;
    void Awake() {
        instance = this;
    }
    void Update() {
        if (Input.GetKeyDown(KeyCode.S))
        {
            CreateOneDev();
        }
    }
    public void CreateOneDev() {
        GameObject dev = Instantiate(devPrefab);
        DevList.Add(dev);
    }
}
