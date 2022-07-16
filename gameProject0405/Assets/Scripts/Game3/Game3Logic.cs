using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game3Logic : MonoBehaviour
{
    private loadStoryBtn loadStoryBtn;
    public Animator tamir;
    string musicOn;
    string currentMusic;
    public GameObject tamirGameObject;

    void Start()
    {
        loadStoryBtn = transform.gameObject.GetComponent<loadStoryBtn>();
        //כיבוי כל הסטורי
        loadStoryBtn.disableStoryBtnAll();
        Debug.Log(PlayerPrefs.GetInt("GameMax"));
        //להדליק את הסטורי שרלוונטיים לשלב המקסימלי
        int myMaxLevel = PlayerPrefs.GetInt("GameMax");
        Debug.Log("Max Level start" + myMaxLevel);

        if (PlayerPrefs.GetInt("GameMax") != 0)
        {
            int MaxStage = PlayerPrefs.GetInt("GameMax");
            Debug.Log(MaxStage);
            loadStoryBtn.EnableStoryBtnsForLevel(MaxStage);
            Debug.Log(MaxStage);
        }
        stage3Sentence1();
    }

    public void Checkmusicbtns(string musicBtnName)
    {
        musicOn = PlayerPrefs.GetString("isMusicOn");
        //אם המוזיקה מופעלת
        if (musicOn == "true")
        {
            FindObjectOfType<audioManger3>().stayOn(musicBtnName);
        }
        else
        {
            FindObjectOfType<audioManger3>().stayOff(musicBtnName);
        }
    }

    public void stage3Sentence1()
    {
        tamir.SetBool("isTalk", true);
        currentMusic = "stage3Sentence1";
        Checkmusicbtns(currentMusic);
        FindObjectOfType<audioManger3>().Play("stage3Sentence1");
        FindObjectOfType<audioManger3>().isPlaying("stage3Sentence1");
    }

    public void stage3Sentence2()
    {
        if (currentMusic == "stage3Sentence1")
        {
            stopMusic();
            tamir.SetBool("isTalk", true);
            currentMusic = "stage3Sentence2";
            Checkmusicbtns(currentMusic);
            FindObjectOfType<audioManger3>().Play("stage3Sentence2");
            FindObjectOfType<audioManger3>().isPlaying("stage3Sentence2");
        }
    }

    public void stage3Sentence3()
    {
        if (currentMusic == "stage3Sentence2")
        {
            stopMusic();
            tamir.SetBool("isTalk", true);
            currentMusic = "stage3Sentence3";
            Checkmusicbtns(currentMusic);
            FindObjectOfType<audioManger3>().Play("stage3Sentence3");
            FindObjectOfType<audioManger3>().isPlaying("stage3Sentence3");
        }
    }

    public void stage3Sentence4()
    {
        if (currentMusic == "stage3Sentence3")
        {
            stopMusic();
            tamir.SetBool("isTalk", true);
            currentMusic = "stage3Sentence4";
            Checkmusicbtns(currentMusic);
            FindObjectOfType<audioManger3>().Play("stage3Sentence4");
            FindObjectOfType<audioManger3>().isPlaying("stage3Sentence4");
        }
    }


    public void ClickSoundBtn(string sound)
    {
        FindObjectOfType<audioManger3>().click(sound);
    }

    public void stopMusic()
    {
        string musicName = currentMusic;
        FindObjectOfType<audioManger3>().StopPlaying(musicName);
    }


//בלחיצה על כפתור סיום משחק
    public void finishGame()
    {
        //הפעלת כפתור סטורי
        if (PlayerPrefs.GetInt("GameMax") < 3)
        {
            PlayerPrefs.SetInt("GameMax", 3);
        }
        int myMaxLevel = PlayerPrefs.GetInt("GameMax");
        Debug.Log("Max Level" + myMaxLevel);
        loadStoryBtn.enableStoryBtn(myMaxLevel);
        tamirGameObject.SetActive(true);

    }
}
