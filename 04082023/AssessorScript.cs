using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AssessorScript : MonoBehaviour
{
    [SerializeField] private Animator transition, mattanim, mattdoc, mattbug, aimeeanim, aimeedoc, aimeebug;
    [SerializeField] private GameObject bottomText, mattGO, aimeeGO, nexttext, nextbutt, devtextGO;
    [SerializeField] private Button honestbutt, dishonestbutt;
    [SerializeField] private TMP_Text mattcounttext, aimeecounttext, devtext, himtext, hertext;
    private int mattcount, aimeecount, devcount;
    private float transitionTime = 1f;
    [SerializeField] bool matthonest, aimeehonest;
    private void Start() {
        devtextGO.SetActive(false);
        bottomText.SetActive(false);
        nexttext.SetActive(false);
        nextbutt.SetActive(false);
        mattanim = mattGO.GetComponent<Animator>();
        aimeeanim = aimeeGO.GetComponent<Animator>();
        mattdoc = mattGO.transform.GetChild(2).GetChild(0).GetComponent<Animator>();
        mattbug = mattGO.transform.GetChild(3).GetChild(0).GetComponent<Animator>();
        aimeedoc = aimeeGO.transform.GetChild(2).GetChild(0).GetComponent<Animator>();
        aimeebug = aimeeGO.transform.GetChild(3).GetChild(0).GetComponent<Animator>();
        matthonest = true;
        mattcount = 0;
        aimeehonest = true;
        aimeecount = 0;
    }
    public void OnHonestButtonPressed()
    {
        if (devtextGO.activeSelf == false) devtextGO.SetActive(true);
        honestbutt.interactable = false;
        dishonestbutt.interactable = false;
        SoundManager.instance.PlayButtonSound();
        aimeehonest = matthonest;
        matthonest = true;
        jumping4noreason();
        if (matthonest && aimeehonest) Invoke("interactButton", 2.5f);
        else Invoke("interactButton", 3.5f);
        Invoke("matttakejob", 1f);
        Invoke("aimeetakejob", 1f);
    }
    public void OnDishonestButtonPressed()
    {
        if (devtextGO.activeSelf == false) devtextGO.SetActive(true);
        honestbutt.interactable = false;
        dishonestbutt.interactable = false;
        SoundManager.instance.PlayButtonSound();
        aimeehonest = matthonest;
        matthonest = false;
        jumping4noreason();
        if (matthonest && aimeehonest) Invoke("interactButton", 2.5f);
        else Invoke("interactButton", 3.5f);
        Invoke("matttakejob", 1f);
        Invoke("aimeetakejob", 1f);
    }
    private void jumping4noreason()
    {
        if (matthonest)
        {
            mattanim.SetTrigger("Jump");
        }
        if (aimeehonest)
        {
            aimeeanim.SetTrigger("Jump");
        }
    }
    private void matttakejob()
    {
        SoundManager.instance.PlayJobSound();
        mattdoc.SetTrigger("Doc1");
        if (matthonest)
        {
            Invoke("mattgetbug", 1f);
            himtext.text = "Badrul : Jujur";
        } else
        {
            himtext.text = "Badrul : Tidak Jujur";
            Invoke("mattgetbug", 1f);
            Invoke("mattgetbug", 1.5f);
            Invoke("mattgetbug", 2f);
        }
    }
    private void mattgetbug()
    {
        SoundManager.instance.PlayBugSound();
        mattbug.SetTrigger("Bugin");
        mattcount++;
        mattcounttext.text = mattcount + "";
        devcheck();
    }
    private void aimeetakejob()
    {
        SoundManager.instance.PlayJobSound();
        aimeedoc.SetTrigger("Doc1");
        if (aimeehonest)
        {
            hertext.text = "Alia : Jujur";
            Invoke("aimeegetbug", 1f);
        } else
        {
            hertext.text = "Alia : Tidak Jujur";
            Invoke("aimeegetbug", 1f);
            Invoke("aimeegetbug", 1.5f);
            Invoke("aimeegetbug", 2f);
        }
    }
    private void aimeegetbug()
    {
        SoundManager.instance.PlayBugSound();
        aimeebug.SetTrigger("Bugin0");
        aimeecount++;
        aimeecounttext.text = aimeecount + "";
        devcheck();
    }
    private void devcheck()
    {
        devcount++;
        if (devcount > 10 && devcount <= 20)
        {
            devtext.text = "[Prestasi Pembangun Perisian : Kurang Memuaskan]";
            devtext.color = Color.yellow;
        } else if (devcount > 20)
        {
            devtext.text = "[Prestasi Pembangun Perisian : Tergendala]";
            devtext.color = Color.red;
            bottomText.SetActive(true);
            Invoke("nextactive", 5f);
        }
        // interactButton();
    }
    private void interactButton()
    {
        honestbutt.interactable = true;
        dishonestbutt.interactable = true;
        // nextcount++;
        // if (nextcount > 10)
        // {
        //     bottomText.SetActive(true);
        //     Invoke("nextactive", 5f);
        // }
    }
    private void nextactive()
    {
        nexttext.SetActive(true);
        nextbutt.SetActive(true);
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
