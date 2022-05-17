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