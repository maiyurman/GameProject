using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using TMPro;

public class Game2UiManager : MonoBehaviour
{

    //------> תפריט עליון
    public navigation messageBtn;
    public navigation musicBtn;
    public navigation userBtn;
    public navigation placeBtn;

    //------> תפריט סטורי
    public navigation[] storyBtns;

    //------>חלון פידבק
    public GameObject feedbackWindow;
    public TextMeshProUGUI feedbackTxt;

    //------>חלון משפיען עם הוראות
    public GameObject influenceInstractionWindow;
    public TextMeshProUGUI influenceInstractionTxt;

    //------>סטורי כניסה למשחק
    public navigation storyOpenGame2;

    //------>תפריט התקדמות
  

    public void Start()
    {
        storyOpenGame2.transform.gameObject.SetActive(false);
        //חלון פידבק
        feedbackWindow.SetActive(false);

    }

    public void openTamarStory()
    {
        storyOpenGame2.transform.gameObject.SetActive(true);
        storyOpenGame2.enableBtn();
    }

}
