using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using TMPro;

public class Game2UiManager : MonoBehaviour
{
    private loadStoryBtn loadStoryBtn;

    public GameObject tamir;

    //------> תפריט עליון
    public navigation messageBtn;
    public navigation userBtn;
    public navigation placeBtn;

    //------> תפריט סטורי
    public navigation[] storyBtns;

    //------>חלון פידבק
    public GameObject feedbackWindow;
    public TextMeshProUGUI feedbackTxt;
    public navigation cheakBtn;
    public TextMeshProUGUI truefeedback;
    public navigation nextQuestionBtn1;
    public navigation nextQuestionBtn2;
    public navigation nextQuestionBtn3;
    public navigation nextQuestionBtn4;
    public navigation nextQuestionBtn5;
    public navigation finishgame;

    //------>סטורי כניסה למשחק
    public navigation storyOpenGame2;

    //------>אנימצית סיום   
    public GameObject finishAnimation1;
    public GameObject finishAnimation2;
    public GameObject finishAnimation3;
    public GameObject finishAnimation4;
    public GameObject finishAnimation5;
    public GameObject finishAnimation6;

    //------>אנימציה תמיר
    public Animator tamirAnimator;

    public void Start()
    {
        PlayerPrefs.SetString("Active", "false");
        PlayerPrefs.SetString("Numbers", "false");
        storyOpenGame2.transform.gameObject.SetActive(false);

        //פידבק
        feedbackWindow.SetActive(false);
        feedbackTxt.transform.gameObject.SetActive(false);
        truefeedback.transform.gameObject.SetActive(false);
        cheakBtn.transform.gameObject.SetActive(false);

        nextQuestionBtn1.transform.gameObject.SetActive(false);
        nextQuestionBtn2.transform.gameObject.SetActive(false);
        nextQuestionBtn3.transform.gameObject.SetActive(false);
        nextQuestionBtn4.transform.gameObject.SetActive(false);
        nextQuestionBtn5.transform.gameObject.SetActive(false);
        finishgame.transform.gameObject.SetActive(false);
        finishAnimation1.SetActive(false);
        finishAnimation2.SetActive(false);
        finishAnimation3.SetActive(false);
        finishAnimation4.SetActive(false);
        finishAnimation5.SetActive(false);
        finishAnimation6.SetActive(false);


        tamir.SetActive(true);

        messageBtn.disableBtn();
        userBtn.disableBtn();
        placeBtn.disableBtn();
    }

    public void openTamarStory()
    {
        storyOpenGame2.transform.gameObject.SetActive(true);
        storyOpenGame2.enableBtn();
    }
    public void openFeedback()
    {
        feedbackTxt.transform.gameObject.SetActive(true);
        cheakBtn.transform.gameObject.SetActive(true);
        //זמני צריך לעשות בדיקה האם נבחרו ערכים במשחק
        cheakBtn.enableBtn();
    }

    //בלחיצה על כפתור בדוק
    public void clickCheckBtn()
    {
        finishAnimation1.SetActive(false);
        finishAnimation2.SetActive(false);
        finishAnimation3.SetActive(false);
        finishAnimation4.SetActive(false);
        finishAnimation5.SetActive(false);
        finishAnimation6.SetActive(false);
        feedbackTxt.transform.gameObject.SetActive(true);
        string Active = PlayerPrefs.GetString("Active");
        string Numbers = PlayerPrefs.GetString("Numbers");
        if (Active == "false" && Numbers == "false")
        {
            feedbackTxt.text = "תשובה לא נכונה";
        }
        else if ((Active == "false" && Numbers == "true") || (Active == "true" && Numbers == "false"))
        {
            feedbackTxt.text = "תשובה נכונה חלקית";
        }
        else
        {
            truefeedback.transform.gameObject.SetActive(true);
            feedbackTxt.text = "";
            feedbackTxt.transform.gameObject.SetActive(false);
            cheakBtn.transform.gameObject.SetActive(false);
            nextQuestionBtn1.transform.gameObject.SetActive(true);
            nextQuestionBtn2.transform.gameObject.SetActive(true);
            nextQuestionBtn3.transform.gameObject.SetActive(true);
            nextQuestionBtn4.transform.gameObject.SetActive(true);
            nextQuestionBtn5.transform.gameObject.SetActive(true);
            finishgame.transform.gameObject.SetActive(true);

            finishAnimation1.SetActive(true);
            finishAnimation2.SetActive(true);
            finishAnimation3.SetActive(true);
            finishAnimation4.SetActive(true);
            finishAnimation5.SetActive(true);
            finishAnimation6.SetActive(true);

            truefeedback.text = "כל הכבוד! פיענחתם את החוקיות!"; 
        }
    }


    public void StopTamir()
    {
        StartCoroutine(stopTamirStartTalk());
    }

    IEnumerator stopTamirStartTalk()
    {
        yield return new WaitForSeconds(2);
        tamirAnimator.SetBool("isTalk", false);
    }
}
