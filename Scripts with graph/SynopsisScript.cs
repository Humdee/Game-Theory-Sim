using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SynopsisScript : MonoBehaviour
{
    public void OnNextButtonPressed() {
        ScenesManager.instance.LoadNextScene();
    }
}
