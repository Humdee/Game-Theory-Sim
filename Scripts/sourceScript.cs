using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sourceScript : MonoBehaviour
{
    public List<GameObject> sourceList;
    public GameObject workPrefab;
    void Update() {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GameObject work = Instantiate(workPrefab);
            sourceList.Add(work);
            Debug.Log("Created work.");
        }
        if (Input.GetKeyDown(KeyCode.W) && sourceList.Count > 0)
        {
            TransferGameObject();
            Debug.Log("Transfering.");
        }
    }
    private void TransferGameObject() {
        targetScript targetscript = FindObjectOfType<targetScript>();
        if (targetscript != null)
        {
            GameObject gameObjectToTransfer = sourceList[0];
            workScript workscript = gameObjectToTransfer.GetComponent<workScript>();
            if (workscript != null)
            {
                workscript.GenerateRandomNum();
            }
            targetscript.targetList.Add(gameObjectToTransfer);
            sourceList.Remove(gameObjectToTransfer);
        }
    }
}
