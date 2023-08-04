using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CreateDev : MonoBehaviour
{
    public static CreateDev instance;
    public GameObject devPrefab;
    public List<GameObject> devPrefabList;
    public List<GameObject> DevList;
    public float maxHeight;
    void Awake()
    {
        instance = this;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            CreateOneSpriteDev();
        }
    }
    public void CreateOneDev()
    {
        GameObject dev = Instantiate(devPrefab);
        DevList.Add(dev);
    }
    public void CreateOneSpriteDev()
    {
        NavMeshTriangulation navMeshData = NavMesh.CalculateTriangulation();
        int randomIndex = Random.Range(0, navMeshData.indices.Length - 3);
        Vector3 spawnPosition = Vector3.Lerp(navMeshData.vertices[navMeshData.indices[randomIndex]], navMeshData.vertices[navMeshData.indices[randomIndex + 1]], Random.value);
        spawnPosition = Vector3.Lerp(spawnPosition, navMeshData.vertices[navMeshData.indices[randomIndex + 2]], Random.value);
        NavMeshHit hit;
        if (NavMesh.SamplePosition(spawnPosition, out hit, 1.0f, NavMesh.AllAreas))
        {
            if (hit.position.y > maxHeight)
            {
                // Position is too high, spawn somewhere else
                CreateOneSpriteDev();
                return;
            }
            int indexDev = Random.Range(0, devPrefabList.Count);
            GameObject dev = Instantiate(devPrefabList[indexDev], hit.position, Quaternion.identity);
            DevList.Add(dev);
        }
        else
        {
            // Invalid position, spawn somewhere else
            CreateOneSpriteDev();
        }
        // Vector3 randomSpawnPosition = new Vector3(Random.Range(-10,10), 2, Random.Range(-10, 10));
        // int indexDev = Random.Range(0, devPrefabList.Count);
        // GameObject dev = Instantiate(devPrefabList[indexDev], spawnPosition, Quaternion.identity);
        // DevList.Add(dev);
    }
}
