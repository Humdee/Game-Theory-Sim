using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReworkCounter : MonoBehaviour
{
    public static ReworkCounter instance;
    [SerializeField] private TMP_Text countText;
    public int totalWork;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        countText = GetComponent<TMP_Text>();
    }
    private void Update()
    {
        int cal = totalWork - (ToDoScript.instance.ToDoList.Count + FinalScript.instance.FinalList.Count);
        countText.text = cal + " Reworks";
    }
}
