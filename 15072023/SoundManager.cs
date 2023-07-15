using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioSource bgsource, buttonsource;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    private void Start()
    {
        if (ScenesManager.instance.GetCurrentScene() >= 1) PlayBGSound();
    }
    public void PlayBGSound()
    {
        bgsource.Play();
    }
    public void PlayButtonSound()
    {
        buttonsource.Play();
    }
}
