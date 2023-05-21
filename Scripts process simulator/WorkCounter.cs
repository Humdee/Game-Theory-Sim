using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WorkCounter : MonoBehaviour
{
    public static WorkCounter instance;
    public int fixCount, kludgeCount, works;
    [SerializeField] private float kludgePoint;
    public float quality;
    private TMP_Text CountText;
    private void Awake() {
        instance = this;
    }
    private void Start() {
        CountText = GetComponent<TMP_Text>();
        quality = 100f;
        kludgePoint = .05f;
    }
    public void addWork() {
        works++;
    }
    public void addFix() {
        fixCount++;
        showCount();
    }
    public void addKludge() {
        kludgeCount++;
        quality = quality - kludgePoint;
        showCount();
    }
    private void showCount() {
        CountText.text = "Final Software Quality : " + Mathf.Round(quality * 100)/100f + "%\n" + "Fixes : " + fixCount + "\nKludges : " + kludgeCount;
    }
}
