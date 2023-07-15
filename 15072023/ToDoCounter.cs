using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ToDoCounter : MonoBehaviour
{
    // [SerializeField] private GameObject whereIsCamera;
    [SerializeField] private TMP_Text countText;
    private void Start()
    {
        // whereIsCamera = GameObject.Find("Main Camera");
        countText = GetComponent<TMP_Text>();
        // transform.rotation = Quaternion.LookRotation(transform.position - whereIsCamera.transform.position);
    }
    private void Update()
    {
        countText.text = ToDoScript.instance.ToDoList.Count + " Kerja Dibuat";
    }
}
