using System;

[Serializable]
public class UserStats
{
    public int dev, work, finalFix, finalKludge;
    public float finalQuality, averageWork, fixRework, kludgeRework;
    public string startStrat, username, duration;
    public int[] graphArray;
    public UserStats() {
        dev = CreateDev.instance.DevList.Count;
        work = WorkCounter.instance.works;
        averageWork = ButtonScript.instance.avrgWorkTimeSlider.value;
        fixRework = DoubleSliderScript.instance.sliderMin.value;
        kludgeRework = DoubleSliderScript.instance.sliderMax.value;
        startStrat = ButtonScript.instance.strat;
        duration = Clock.instance.timeText.text;
        finalQuality = WorkCounter.instance.quality;
        finalFix = WorkCounter.instance.fixCount;
        finalKludge = WorkCounter.instance.kludgeCount;
        graphArray = FinalScript.instance.submitCountList.ToArray();
    }
    public UserStats(string username) {
        this.username = username;
        dev = CreateDev.instance.DevList.Count;
        work = WorkCounter.instance.works;
        averageWork = ButtonScript.instance.avrgWorkTimeSlider.value;
        fixRework = DoubleSliderScript.instance.sliderMin.value;
        kludgeRework = DoubleSliderScript.instance.sliderMax.value;
        startStrat = ButtonScript.instance.strat;
        duration = Clock.instance.timeText.text;
        finalQuality = WorkCounter.instance.quality;
        finalFix = WorkCounter.instance.fixCount;
        finalKludge = WorkCounter.instance.kludgeCount;
        graphArray = FinalScript.instance.submitCountList.ToArray();
    }
}
