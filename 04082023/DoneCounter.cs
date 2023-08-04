using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DoneCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text countText;
    private void Start()
    {
        countText = GetComponent<TMP_Text>();
    }
    private void Update()
    {
        countText.text = FinalScript.instance.FinalList.Count + " Done";
    }
}
