using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmitWork : MonoBehaviour
{
    public GameObject workPrefab;
    public List<GameObject> Dones = new List<GameObject>(0);
    void OnCollisionEnter(Collision doneCollider) {
        if (doneCollider.gameObject.tag == "dev")
        {
            Dones.Add(workPrefab);
            Debug.Log("Work sent!");
        }
    }
}