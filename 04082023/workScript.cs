using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class workScript : MonoBehaviour
{
    public string Strat;
    public GameObject rememberedDev;
    private void Start()
    {
        rememberedDev = null;
    }
    public void isRememberedDev()
    {
        if (rememberedDev != null)
        {
            passToRememberedDev();
        }
        else
        {
            ToDoScript.instance.ToDoList.Add(this.gameObject);
        }
    }
    public void getDevName(DevScript devScript)
    {
        rememberedDev = devScript.gameObject;
    }
    public void passToRememberedDev()
    {
        GameObject thisWorkScript = this.gameObject;
        rememberedDev.GetComponent<DevScript>().DevWorkList.Add(thisWorkScript);
    }
}
