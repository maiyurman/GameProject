using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game3Logic : MonoBehaviour
{
    private loadStoryBtn loadStoryBtn;
    public Animator tamir;
    string musicOn;

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
        FindObjectOfType<audioManger3>().Play("stage3Sentence1");
        Checkmusicbtns("stage3Sentence1");
        StartCoroutine(stage3Sentence1());
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

    IEnumerator stage3Sentence1()
    {
        yield return new WaitForSeconds(0.02f);
        tamir.SetBool("isTalk", false);
    }

    public void startstage3Sentence2()
    {
        tamir.SetBool("isTalk", true);
        FindObjectOfType<audioManger3>().Play("stage3Sentence2");
        StartCoroutine(stage3Sentence2());

    }

    IEnumerator stage3Sentence2()
    {
        yield return new WaitForSeconds(1);
        tamir.SetBool("isTalk", false);
    }

    public void startstage3Sentence3()
    {
        tamir.SetBool("isTalk", true);
        FindObjectOfType<audioManger3>().Play("stage3Sentence3");
        StartCoroutine(stage3Sentence3());
    }

    IEnumerator stage3Sentence3()
    {
        yield return new WaitForSeconds(1);
        tamir.SetBool("isTalk", false);
    }

    public void startstage3Sentence4()
    {
        tamir.SetBool("isTalk", true);
        FindObjectOfType<audioManger3>().Play("stage3Sentence4");
        StartCoroutine(stage3Sentence4());
    }

    IEnumerator stage3Sentence4()
    {
        yield return new WaitForSeconds(1);
        tamir.SetBool("isTalk", false);
    }

    public void ClickSoundBtn(string sound)
    {
        FindObjectOfType<audioManger3>().click(sound);
    }

    public void stopMusic(string musicName)
    {
        StopAllCoroutines();
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

    }
}
