using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConclusionScript : MonoBehaviour
{
    public void OnThanksButtonPressed() {
        // Application.Quit();
        ScenesManager.instance.LoadLoginMenu();
    }
    public void OnGraphButtonPressed() {
        ScenesManager.instance.LoadScene(ScenesManager.Scene.SimulationScene);
    }
}
