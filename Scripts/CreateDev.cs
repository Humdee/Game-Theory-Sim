using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateDev : MonoBehaviour
{
    List<GameObject> Devs = new List<GameObject>(0);
    public GameObject devPrefab;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-10,10), 2, Random.Range(-10, 10));
            GameObject d = Instantiate(devPrefab, randomSpawnPosition, Quaternion.identity);
            Devs.Add(d);
            //Debug.Log(Devs.Count);
        }
    }
}
