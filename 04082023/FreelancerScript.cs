using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FreelancerScript : MonoBehaviour
{
    [SerializeField] private Animator transition, topText, bottomText, pablojump, pabloCoin, pabloJob, seanjump, seanCoin, seanJob;
    [SerializeField] private GameObject nextbutt, bottomTextGO, pabloGO, seanGO;
    private int pablocount, seancount, nextcount;
    [SerializeField] private TMP_Text pablotext, seantext, youtext, himtext;
    [SerializeField] private Button coopbutt, splitbutt;
    private float transitionTime = 1f;
    [SerializeField] private bool understand, pablocoop, seancoop;
    private void Start()
    {
        nextbutt.SetActive(false);
        bottomTextGO.SetActive(false);
        understand = false;
        pabloCoin = pabloGO.transform.GetChild(2).GetChild(0).GetComponent<Animator>();
        pabloJob = pabloGO.transform.GetChild(3).GetChild(0).GetComponent<Animator>();
        seanCoin = seanGO.transform.GetChild(2).GetChild(0).GetComponent<Animator>();
        seanJob = seanGO.transform.GetChild(3).GetChild(0).GetComponent<Animator>();
        nextcount = 0;
        pablocount = 0;
        seancount = 0;
        pablocoop = true;
        seancoop = true;
    }
    public void OnCoopButtonPressed()
    {
        SoundManager.instance.PlayButtonSound();
        if (!understand)
        {
            understand = true;
            topText.SetTrigger("Exit");
            bottomTextGO.SetActive(true);
        }
        else
        {
            coopbutt.interactable = false;
            splitbutt.interactable = false;
            seancoop = pablocoop;
            pablocoop = true;
            work();
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
        }
        else
        {
            coopbutt.interactable = false;
            splitbutt.interactable = false;
            seancoop = pablocoop;
            pablocoop = false;
            work();
        }
    }
    private void work()
    {
        if (nextcount > 4)
        {
            seancoop = false;
        }
        if (pablocoop && seancoop)
        {
            youtext.text = "Anda - Pembangun UI\nBekerjasama";
            himtext.text = "Pembangun Sistem\nBekerjasama";
            pablojump.SetTrigger("Jump");
            seanjump.SetTrigger("Jump");
            Invoke("pablotakejob", 1f);
            Invoke("seantakejob", 1f);
            Invoke("interactButton", 2f);
        }
        else if (pablocoop && !seancoop)
        {
            youtext.text = "Anda - Pembangun UI\nBekerjasama";
            himtext.text = "Pembangun Sistem\nTidak Bekerjasama";
            pablojump.SetTrigger("Jump");
            Invoke("pablotakejob", 1f);
            Invoke("seantakejob", 1f);
            Invoke("seantakejob", 3f);
            Invoke("interactButton", 4f);
        }
        else if (!pablocoop && seancoop)
        {
            youtext.text = "Anda - Pembangun UI\nTidak Bekerjasama";
            himtext.text = "Pembangun Sistem\nBekerjasama";
            seanjump.SetTrigger("Jump");
            Invoke("pablotakejob", 1f);
            Invoke("pablotakejob", 3f);
            Invoke("seantakejob", 1f);
            Invoke("interactButton", 4f);
        }
        else if (!pablocoop && !seancoop)
        {
            youtext.text = "Anda - Pembangun UI\nTidak Bekerjasama";
            himtext.text = "Pembangun Sistem\nTidak Bekerjasama";
            pabloJob.SetTrigger("Enter");
            seanJob.SetTrigger("Enter 0");
            Invoke("pabloJump", 1f);
            Invoke("seanJump", 1f);
            Invoke("interactButton", 1f);
        }
        else Debug.Log("Okay... What happened?");
    }
    private void pabloJump()
    {
        pablojump.SetTrigger("Jump");
    }
    private void pablotakejob()
    {
        SoundManager.instance.PlayJobSound();
        pabloJob.SetTrigger("Enter");
        Invoke("pablotakecoin", 1f);
    }
    private void pablotakecoin()
    {
        SoundManager.instance.PlayCoinSound();
        pabloCoin.SetTrigger("Enter");
        pablocount = pablocount + 50;
        pablotext.text = pablocount + "";
    }
    private void seanJump()
    {
        seanjump.SetTrigger("Jump");
    }
    private void seantakejob()
    {
        SoundManager.instance.PlayJobSound();
        seanJob.SetTrigger("Enter 0");
        Invoke("seantakecoin", 1f);
    }
    private void seantakecoin()
    {
        SoundManager.instance.PlayCoinSound();
        seanCoin.SetTrigger("Enter");
        seancount = seancount + 50;
        seantext.text = seancount + "";
    }
    private void seanMad()
    {
        seanjump.SetTrigger("Mad");
    }
    private void interactButton()
    {
        nextcount++;
        coopbutt.interactable = true;
        splitbutt.interactable = true;
        if (nextcount > 5) nextbutt.SetActive(true);
        if (nextcount == 4) Invoke("seanMad", 1f);
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
