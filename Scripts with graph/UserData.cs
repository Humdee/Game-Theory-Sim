using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UserData
{
    public float dev, work;
    public int[] graphArray;

    public UserData (ButtonScript parameter) {
        dev = parameter.devSlider.value;
        work = parameter.workSlider.value;

        graphArray = parameter.graphArray;
    }
}
