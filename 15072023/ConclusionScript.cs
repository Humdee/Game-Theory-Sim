using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConclusionScript : MonoBehaviour
{
    [SerializeField] private Animator transition;
    private float transitionTime = 1f;
    public void OnThanksButtonPressed()
    {
        SoundManager.instance.PlayButtonSound();
        // Application.Quit();
        ScenesManager.instance.LoadLoginMenu();
        // StartCoroutine(SceneTransition());
    }
    public void OnGraphButtonPressed()
    {
        SoundManager.instance.PlayButtonSound();
        ScenesManager.instance.LoadScene(ScenesManager.Scene.SimulationScene);
        // StartCoroutine(SceneTransition());
    }
    IEnumerator SceneTransition() {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        ScenesManager.instance.LoadNextScene();
    }
}
