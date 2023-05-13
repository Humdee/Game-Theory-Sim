using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginScript : MonoBehaviour
{
    public void OnLoginButtonPressed() {
        ScenesManager.instance.LoadNextScene();
        // ScenesManager.instance.LoadScene(ScenesManager.Scene.Synopsis);
    }
}
