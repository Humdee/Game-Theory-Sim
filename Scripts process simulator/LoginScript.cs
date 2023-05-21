using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoginScript : MonoBehaviour
{
    private string username;
    private TMP_Text showNaviText;
    private bool showNavi;
    private void Start() {
        showNaviText = transform.Find("ViewNaviButton/NaviText").GetComponent<TMP_Text>();
        showNavi = false;
    }
    public void OnLoginButtonPressed() {
        if (username != null) {
            PlayerPrefs.SetString("Username", username);
            ScenesManager.instance.LoadNextScene();
        } else Debug.Log("Username empty!");
        // ScenesManager.instance.LoadScene(ScenesManager.Scene.Synopsis);
    }
    public void ReadUsername(string s) {
        username = s;
    }
    public void OnNaviBarPressed() {
        showNavi = !showNavi;
        if (showNavi) {
            showNaviText.text = "YES";
        } else {
            showNaviText.text = "NO";
        }
    }
}
