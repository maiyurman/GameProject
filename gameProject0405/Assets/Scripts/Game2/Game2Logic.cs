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
    string musicOn;
    string currentMusic;



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
        currentMusic = "stage2Sentence1";
        Checkmusicbtns("stage2Sentence1");
        stage2Sentence1();
    }

    public void Checkmusicbtns(string musicBtnName)
    {
        musicOn = PlayerPrefs.GetString("isMusicOn");
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

    public void stage2Sentence1()
    {
        tamir.SetBool("isTalk", true);
        currentMusic = "stage2Sentence1";
        Checkmusicbtns(currentMusic);
        FindObjectOfType<audioManger>().Play("stage2Sentence1");
        FindObjectOfType<audioManger>().isPlaying("stage2Sentence1");
    }

    public void stage2Sentence2()
    {
        if (currentMusic == "stage2Sentence1")
        {
            stopMusic();
            tamir.SetBool("isTalk", true);
            currentMusic = "stage1Sentence2";
            Checkmusicbtns(currentMusic);
            FindObjectOfType<audioManger>().Play("stage1Sentence2");
            FindObjectOfType<audioManger>().isPlaying("stage1Sentence2");
        }
    }

    public void stage2Sentence3()
    {
        if (currentMusic == "stage2Sentence2")
        {
            stopMusic();
            tamir.SetBool("isTalk", true);
            currentMusic = "stage2Sentence3";
            Checkmusicbtns(currentMusic);
            FindObjectOfType<audioManger>().Play("stage2Sentence3");
            FindObjectOfType<audioManger>().isPlaying("stage2Sentence3");
        }
    }


    public void ClickSoundBtn(string sound)
    {
        FindObjectOfType<audioManger2>().click(sound);
    }

    public void stopMusic()
    {
        string musicName = currentMusic;
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
        loadStoryBtn.enableStoryBtn(myMaxLevel);
    }
}