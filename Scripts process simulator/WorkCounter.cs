using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WorkCounter : MonoBehaviour
{
    public static WorkCounter instance;
    public int fixCount, kludgeCount;
    private TMP_Text CountText;
    private void Awake() {
        instance = this;
    }
    private void Start() {
        CountText = GetComponent<TMP_Text>();
    }
    public void addFix() {
        fixCount++;
        showCount();
    }
    public void addKludge() {
        kludgeCount++;
        showCount();
    }
    private void showCount() {
        CountText.text = fixCount + " Fixes\n" + kludgeCount + " Kludges";
    }
}
