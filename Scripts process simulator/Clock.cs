using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Clock : MonoBehaviour
{
    public static Clock instance;
    private const float real_second_per_ingame_Hour = 3600f;
    public bool startWork;
    private float hour;
    public TMP_Text timeText;
    private void Awake() {
        instance = this;
        timeText = transform.GetComponent<TMP_Text>();
    }
    private void Start() {
        startWork = false;
    }
    private void Update() {
        if (startWork == true) {
            hour += Time.deltaTime / real_second_per_ingame_Hour;
            float hourNormalized = hour % 1f;
            float minutesPerHour = 60f;
            string minuteString = Mathf.Floor(hourNormalized * minutesPerHour).ToString("00");
            float secondsPerMinute = 60f;
            string secondString = Mathf.Floor(((hourNormalized * minutesPerHour) % 1f) * secondsPerMinute).ToString("00");
            timeText.text = minuteString + ":" + secondString;
        }
    }
}
