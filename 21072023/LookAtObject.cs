using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LookAtObject : MonoBehaviour
{
    [SerializeField] private GameObject whereIsCamera;
    [SerializeField] private TMP_Text iconText;
    [SerializeField] DevScript devScript;
    private void Start()
    {
        whereIsCamera = GameObject.Find("Main Camera");
        iconText = transform.Find("IconText").GetComponent<TMP_Text>();
        // get current list count of work
        devScript = GetComponentInParent<DevScript>();
    }
    private void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - whereIsCamera.transform.position);
        iconText.text = devScript.DevWorkList.Count.ToString();
        if (devScript.DevWorkList.Count < 3)
        {
            iconText.color = new Color(0, 255, 255);
        }
        else
        {
            iconText.color = new Color(255, 0, 0);
        }
    }
}
