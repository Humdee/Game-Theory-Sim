using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;
using TMPro;

public class LoginScript : MonoBehaviour
{
    private string dataDirPath = "";
    private string username = "";
    private TMP_Text showNaviText;
    private bool showNavi;
    private void Awake() {
        dataDirPath = Application.persistentDataPath;
    }
    private void Start()
    {
        showNaviText = transform.Find("ViewNaviButton/NaviText").GetComponent<TMP_Text>();
        showNavi = false;
    }
    public void OnLoginButtonPressed()
    {
        if (username != null && username != "")
        {
            PlayerPrefs.SetString("Username", username);
            string userPath = Path.Combine(dataDirPath, username);
            Directory.CreateDirectory(userPath);
            ScenesManager.instance.LoadNextScene();
        }
        else Debug.Log("Username empty!");
        // ScenesManager.instance.LoadScene(ScenesManager.Scene.Synopsis);
    }
    public void OnNaviBarPressed()
    {
        showNavi = !showNavi;
        if (showNavi)
        {
            showNaviText.text = "YES";
        }
        else
        {
            showNaviText.text = "NO";
        }
    }
    public void ReadInputString(string u)
    {
        this.username = u;
    }
}
