using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SynopsisScript : MonoBehaviour
{
    [SerializeField] private Animator transition;
    private float transitionTime = 1f;
    private void Start()
    {
        if (!SoundManager.instance.bgsource.isPlaying) SoundManager.instance.PlayBGSound();
    }
    public void OnNextButtonPressed()
    {
        SoundManager.instance.PlayButtonSound();
        // ScenesManager.instance.LoadNextScene();
        StartCoroutine(SceneTransition());
    }
    public void OnNavi1Pressed()
    {
        ScenesManager.instance.LoadScene(ScenesManager.Scene.SynopsisScene);
    }
    public void OnNavi2Pressed()
    {
        ScenesManager.instance.LoadScene(ScenesManager.Scene.FreelancerScene);
    }
    public void OnNavi3Pressed()
    {
        ScenesManager.instance.LoadScene(ScenesManager.Scene.AssessorScene);
    }
    public void OnNavi4Pressed()
    {
        ScenesManager.instance.LoadScene(ScenesManager.Scene.ModelScene);
    }
    public void OnNavi5Pressed()
    {
        ScenesManager.instance.LoadScene(ScenesManager.Scene.SimulationScene);
    }
    public void OnNavi6Pressed()
    {
        ScenesManager.instance.LoadScene(ScenesManager.Scene.ConclusionScene);
    }
    IEnumerator SceneTransition()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        ScenesManager.instance.LoadNextScene();
    }
}
