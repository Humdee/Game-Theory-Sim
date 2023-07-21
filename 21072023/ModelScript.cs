using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelScript : MonoBehaviour
{
    [SerializeField] private Animator transition, todoanim, devanim, devanim2, doneanim, testeranim, testeranim2, finalanim;
    [SerializeField] private GameObject synopsis, top, top1, bottom, bottom1, bottom2, bottom3, bottom4, bottom5, conbutt, figure, nextbutt;
    private float transitionTime = 1f;
    private int understand;
    private void Start()
    {
        understand = 0;
        figure.SetActive(false);
        top.SetActive(false);
        top1.SetActive(false);
        bottom.SetActive(false);
        nextbutt.SetActive(false);
    }
    public void OnOkButtonPressed()
    {
        SoundManager.instance.PlayButtonSound();
        understand++;
        if (understand == 1)
        {
            conbutt.GetComponent<Animator>().SetTrigger("Down");
            synopsis.GetComponent<Animator>().SetTrigger("Out");
            top.SetActive(true);
            top1.SetActive(true);
            figure.SetActive(true);
        }
        else if (understand == 2)
        {
            top.GetComponent<Animator>().SetTrigger("Out");
            top1.GetComponent<Animator>().SetTrigger("Out");
            todoanim.SetTrigger("Enter");
            bottom.SetActive(true);
        }
        else if (understand == 3)
        {
            bottom.GetComponent<Animator>().SetTrigger("Out");
            devanim.SetTrigger("Enter");
            devanim2.SetTrigger("Enter");
            bottom1.SetActive(true);
        }
        else if (understand == 4)
        {
            bottom1.GetComponent<Animator>().SetTrigger("Out");
            doneanim.SetTrigger("Enter");
            bottom2.SetActive(true);
        }
        else if (understand == 5)
        {
            bottom2.GetComponent<Animator>().SetTrigger("Out");
            testeranim.SetTrigger("Enter");
            testeranim2.SetTrigger("Enter");
            bottom3.SetActive(true);
        }
        else if (understand == 6)
        {
            bottom3.GetComponent<Animator>().SetTrigger("Out");
            finalanim.SetTrigger("Enter");
            bottom4.SetActive(true);
        }
        else if (understand == 7)
        {
            bottom4.GetComponent<Animator>().SetTrigger("Out");
            bottom5.SetActive(true);
            conbutt.GetComponent<Animator>().SetTrigger("Out");
            nextbutt.SetActive(true);
            nextbutt.GetComponent<Animator>().SetTrigger("Next");
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
    IEnumerator SceneTransition()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        ScenesManager.instance.LoadNextScene();
    }
}
