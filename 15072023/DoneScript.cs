using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoneScript : MonoBehaviour
{
    public static DoneScript instance;
    public List<GameObject> DoneList;
    void Awake()
    {
        instance = this;
    }
    public void RemoveOneDone()
    {
        GameObject WorkTakenByTester = DoneList[0];
        DoneList.Remove(WorkTakenByTester);
    }
}
