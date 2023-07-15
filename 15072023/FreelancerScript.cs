using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreelancerScript : MonoBehaviour
{
    [SerializeField] private Animator transition, topText, bottomText, pablojump, seanjump;
    [SerializeField] private GameObject bottomTextGO, pabloGO, seanGO, coin;
    private float transitionTime = 1f;
    private bool understand;
    private void Start() {
        bottomTextGO.SetActive(false);
        understand = false;
    }
    public void OnCoopButtonPressed()
    {
        SoundManager.instance.PlayButtonSound();
        if (!understand)
        {
            understand = true;
            topText.SetTrigger("Exit");
            bottomTextGO.SetActive(true);
        } else {
            pablojump.SetTrigger("Jump");
            Instantiate(coin, new Vector3(pabloGO.transform.position.x + 1, 2, pabloGO.transform.position.z), Quaternion.identity);
        }
    }
    public void OnSplitButtonPressed()
    {
        SoundManager.instance.PlayButtonSound();
        if (!understand)
        {
            understand = true;
            topText.SetTrigger("Exit");
            bottomTextGO.SetActive(true);
        } else {
            seanjump.SetTrigger("Jump");
            Instantiate(coin, new Vector3(seanGO.transform.position.x - 1, 2, seanGO.transform.position.z), Quaternion.identity);
        }
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
    IEnumerator SceneTransition() {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        ScenesManager.instance.LoadNextScene();
    }
}
