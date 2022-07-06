using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CloseGameLogic : MonoBehaviour
{
    public navigation place;
    public navigation chat;
    public navigation user;
    public navigation level1;
    public navigation level2;
    public navigation level3;
    public navigation level4;
    public navigation level5;



    //------>אנימציה תמיר 

    public Animator tamirTTB;
    string musicOn;

    private void Start()
    {
        place.disableBtn();
        chat.disableBtn();
        user.disableBtn();
        level1.enableBtn();
        level2.enableBtn();
        level3.enableBtn();
        level4.enableBtn();
        level5.enableBtn();
        tamirTTB.SetBool("isTalk", true);
        FindObjectOfType<audioMangerEnd>().Play("endSentence1");
        Checkmusicbtns("endSentence1");
        StartCoroutine(stageEndSentence1());

    }

    public void Checkmusicbtns(string musicBtnName)
    {
        musicOn = PlayerPrefs.GetString("isMusicOn");
        //אם המוזיקה מופעלת
        if (musicOn == "true")
        {
            FindObjectOfType<audioMangerEnd>().stayOn(musicBtnName);
        }
        else
        {
            FindObjectOfType<audioMangerEnd>().stayOff(musicBtnName);
        }
    }

    IEnumerator stageEndSentence1()
    {
        Debug.Log("enter to 1 before");
        yield return new WaitForSeconds(0.5f);
        tamirTTB.SetBool("isTalk", false);
        Debug.Log("finish 1 and" + tamirTTB.GetBool("isTalk"));
    }

    public void startstageEndSentence2()
    {
        tamirTTB.SetBool("isTalk", true);
        FindObjectOfType<audioMangerEnd>().Play("endSentence2");
        StartCoroutine(stageEndSentence2());

    }

    IEnumerator stageEndSentence2()
    {
        Debug.Log("enter to 2 before");
        yield return new WaitForSeconds(1.5f);
        tamirTTB.SetBool("isTalk", false);
        Debug.Log("finish 2 and" + tamirTTB.GetBool("isTalk"));

    }

    public void startstageEndSentence3()
    {
        tamirTTB.SetBool("isTalk", true);
        FindObjectOfType<audioMangerEnd>().Play("endSentence3");
        StartCoroutine(stageEndSentence3());
    }

    IEnumerator stageEndSentence3()
    {
        Debug.Log("enter to 3 before");
        yield return new WaitForSeconds(1.5f);
        tamirTTB.SetBool("isTalk", false);
        Debug.Log("finish 3 and" + tamirTTB.GetBool("isTalk"));
    }

    public void startstageEndSentence4()
    {
        tamirTTB.SetBool("isTalk", true);
        FindObjectOfType<audioMangerEnd>().Play("endSentence4");
        StartCoroutine(stageEndSentence4());
    }

    IEnumerator stageEndSentence4()
    {
        Debug.Log("enter to 4 before");
        yield return new WaitForSeconds(0.5f);
        tamirTTB.SetBool("isTalk", false);
        Debug.Log("finish 4 and" + tamirTTB.GetBool("isTalk"));
    }

    public void ClickSoundBtn(string sound)
    {
        FindObjectOfType<audioMangerEnd>().click(sound);
    }

    public void stopMusic(string musicName)
    {
        StopAllCoroutines();
        FindObjectOfType<audioMangerEnd>().StopPlaying(musicName);
    }

    public void startOverGame()
    {
        PlayerPrefs.SetInt("gameNumIn", 0);
        PlayerPrefs.SetInt("GameMax", 0);
        SceneManager.LoadScene("Game1");
    }

    public void closeGame()
    {
        SceneManager.LoadScene("menu");
    }

    public void stopTamirTalk()
    {
        tamirTTB.SetBool("isTalk", false);

    }

    public void startTamirTalk()
    {
        tamirTTB.SetBool("isTalk", true);

    }

}
