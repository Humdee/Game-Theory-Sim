using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateWork : MonoBehaviour
{
    public static CreateWork instance;
    public List<GameObject> Works = new List<GameObject>(0);
    public GameObject workPrefab, workInst;

    void Awake() {
        instance = this;
    }
    void Start() {
        workInst = Instantiate(workPrefab, transform.position, Quaternion.identity);
    }
    void Update() {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            //Vector3 randomSpawnPosition = new Vector3(Random.Range(-5, 5), 1, Random.Range(-5, 5));
            //GameObject w = Instantiate(workPrefab, transform.position, Quaternion.identity);
            workInst.SetActive(true);
            Works.Add(workInst);
        }
        if (Works.Count == 0)
        {
            workInst.SetActive(false);
        }
    }
}