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
    private void Update() {
        if (Input.GetKeyDown(KeyCode.S))
        {
            GameObject dev = Instantiate(devPrefab);
            DevList.Add(dev);
        }
    }
}
