using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using TMPro;


public class Game2Logic : MonoBehaviour
{
    private loadStoryBtn loadStoryBtn;
    public Animator tamir;
    public navigation continuebtn;
    string musicOn;


    void Start()
    {
        loadStoryBtn = transform.gameObject.GetComponent<loadStoryBtn>();
        //כיבוי כל הסטורי
        loadStoryBtn.disableStoryBtnAll();
        Debug.Log(PlayerPrefs.GetInt("GameMax"));
        //להדליק את הסטורי שרלוונטיים לשלב המקסימלי
        int myMaxLevel = PlayerPrefs.GetInt("GameMax");
        Debug.Log("Max Level" + myMaxLevel);

        if (PlayerPrefs.GetInt("GameMax") != 0)
        {
            int MaxStage = PlayerPrefs.GetInt("GameMax");
            Debug.Log(MaxStage);
            loadStoryBtn.EnableStoryBtnsForLevel(MaxStage);
            Debug.Log(MaxStage);
        }
        continuebtn.disableBtn();
        FindObjectOfType<audioManger2>().Play("stage2Sentence1");
        Checkmusicbtns("stage2Sentence1");
        StartCoroutine(stage1Sentence1());
    }

    public void Checkmusicbtns(string musicBtnName)
    {
        musicOn = PlayerPrefs.GetString("isMusicOn");
        Debug.Log("סטטוס מוזיקה" + musicOn);
        //אם המוזיקה מופעלת
        if (musicOn == "true")
        {
            Debug.Log("שם המוזיקה" + musicBtnName);
            FindObjectOfType<audioManger2>().stayOn(musicBtnName);
        }
        else
        {
            FindObjectOfType<audioManger2>().stayOff(musicBtnName);
        }
    }

    IEnumerator stage1Sentence1()
    {
        yield return new WaitForSeconds(0.02f);
        tamir.SetBool("isTalk", false);
        continuebtn.enableBtn();
    }

    public void startstage2Sentence2()
    {
        tamir.SetBool("isTalk", true);
        FindObjectOfType<audioManger2>().Play("stage2Sentence2");
        StartCoroutine(stage2Sentence2());

    }

    IEnumerator stage2Sentence2()
    {
        yield return new WaitForSeconds(1);
        tamir.SetBool("isTalk", false);
    }

    public void startstage2Sentence3()
    {
        tamir.SetBool("isTalk", true);
        FindObjectOfType<audioManger2>().Play("stage2Sentence3");
        StartCoroutine(stage2Sentence3());
    }

    IEnumerator stage2Sentence3()
    {
        yield return new WaitForSeconds(1);
        tamir.SetBool("isTalk", false);
    }

    public void ClickSoundBtn(string sound)
    {
        FindObjectOfType<audioManger2>().click(sound);
    }

    public void stopMusic(string musicName)
    {
        StopAllCoroutines();
        FindObjectOfType<audioManger2>().StopPlaying(musicName);
    }


    //בלחיצה על כפתור סיום משחק
    public void finishGame()
    {
        //הפעלת כפתור סטורי
        if (PlayerPrefs.GetInt("GameMax") < 2)
        {
            PlayerPrefs.SetInt("GameMax", 2);
        }
     
        int myMaxLevel = PlayerPrefs.GetInt("GameMax");
        Debug.Log("Max Level" + myMaxLevel);
        loadStoryBtn.enableStoryBtn(myMaxLevel);
    }
}