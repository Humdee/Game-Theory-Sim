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
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        CountText = GetComponent<TMP_Text>();
        quality = 100f;
        kludgePoint = .15f;
    }
    public void addWork()
    {
        works++;
    }
    public void addFix()
    {
        fixCount++;
        showCount();
    }
    public void addKludge()
    {
        kludgeCount++;
        quality = quality - kludgePoint;
        showCount();
    }
    public void showCount()
    {
        CountText.text = "Kualiti Perisian Akhir : " + Mathf.Round(quality * 100) / 100f + "%\n" + "Anggun : " + fixCount + "\nPintas : " + kludgeCount;
    }
}
