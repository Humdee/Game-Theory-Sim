using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DoubleSliderScript : MonoBehaviour
{
    public static DoubleSliderScript instance;
    public Slider sliderMin, sliderMax;
    private TMP_Text doubleSliderText;
    private string min, max;
    private float bothDistance;
    private void Awake()
    {
        instance = this;
        sliderMin = transform.Find("_sliderMin").GetComponent<Slider>();
        sliderMax = transform.Find("_sliderMax").GetComponent<Slider>();
        doubleSliderText = transform.Find("DoubleSliderText").GetComponent<TMP_Text>();
    }
    private void Start()
    {
        min = sliderMin.value.ToString();
        max = sliderMax.value.ToString();
        UpdateSliderText();
        TesterScript.instance.fixProb = sliderMin.value;
        TesterScript.instance.kludgeProb = sliderMax.value;
        bothDistance = 1;
    }
    public void UpdateSliderMin()
    {
        min = sliderMin.value.ToString();
        UpdateSliderText();
        if ((sliderMin.maxValue - sliderMin.value) < bothDistance)
        {
            sliderMin.value = sliderMin.maxValue - bothDistance;
        }
        TesterScript.instance.fixProb = sliderMin.value;
    }
    public void UpdateSliderMax()
    {
        max = sliderMax.value.ToString();
        UpdateSliderText();
        if ((sliderMax.value - sliderMax.minValue) < bothDistance)
        {
            sliderMax.value = sliderMax.minValue + bothDistance;
        }
        TesterScript.instance.kludgeProb = sliderMax.value;
    }
    private void UpdateSliderText()
    {
        doubleSliderText.text = min + "0 : " + max + "0 % Baiki Semula";
    }
}
