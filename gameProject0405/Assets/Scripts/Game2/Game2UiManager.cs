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

    //------> ����� �����
    public navigation messageBtn;
    public navigation userBtn;
    public navigation placeBtn;

    //------> ����� �����
    public navigation[] storyBtns;

    //------>���� �����
    public GameObject feedbackWindow;
    public TextMeshProUGUI feedbackTxt;
    public navigation cheakBtn;
    public TextMeshProUGUI truefeedback;
    public navigation nextQuestionBtn2;
    public navigation nextQuestionBtn3;
    public navigation nextQuestionBtn4;
    public navigation finishgame;

    //------>����� ����� �����
    public navigation storyOpenGame2;

    //------>������� ����   
    public GameObject finishAnimation2;
    public GameObject finishAnimation3;
    public GameObject finishAnimation4;

    //------>������� ����
    public Animator tamirAnimator;

    public void Start()
    {
        PlayerPrefs.SetString("Active", "false");
        PlayerPrefs.SetString("Numbers", "false");
        storyOpenGame2.transform.gameObject.SetActive(false);

        //�����
        feedbackWindow.SetActive(false);
        feedbackTxt.transform.gameObject.SetActive(false);
        truefeedback.transform.gameObject.SetActive(false);
        cheakBtn.transform.gameObject.SetActive(false);

        nextQuestionBtn2.transform.gameObject.SetActive(false);
        nextQuestionBtn3.transform.gameObject.SetActive(false);
        nextQuestionBtn4.transform.gameObject.SetActive(false);
        finishAnimation2.SetActive(false);
        finishAnimation3.SetActive(false);
        finishAnimation4.SetActive(false);


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
        //���� ���� ����� ����� ��� ����� ����� �����
        cheakBtn.enableBtn();
    }

    //������ �� ����� ����
    public void clickCheckBtn()
    {
        finishAnimation2.SetActive(false);
        finishAnimation3.SetActive(false);
        finishAnimation4.SetActive(false);
        feedbackTxt.transform.gameObject.SetActive(true);
        string Active = PlayerPrefs.GetString("Active");
        string Numbers = PlayerPrefs.GetString("Numbers");
        if (Active == "false" && Numbers == "false")
        {
            feedbackTxt.text = "����� �� �����";
        }
        else if ((Active == "false" && Numbers == "true") || (Active == "true" && Numbers == "false"))
        {
            feedbackTxt.text = "����� ����� �����";
        }
        else
        {
            truefeedback.transform.gameObject.SetActive(true);
            feedbackTxt.text = "";
            feedbackTxt.transform.gameObject.SetActive(false);
            cheakBtn.transform.gameObject.SetActive(false);
            nextQuestionBtn2.transform.gameObject.SetActive(true);
            nextQuestionBtn3.transform.gameObject.SetActive(true);
            nextQuestionBtn4.transform.gameObject.SetActive(true);

            finishAnimation2.SetActive(true);
            finishAnimation3.SetActive(true);
            finishAnimation4.SetActive(true);

            truefeedback.text = "�� �����! ������� �� �������!"; 
        }
    }

    public void checkDropDownChanges()
    {
            string Active = PlayerPrefs.GetString("Active");
            string Numbers = PlayerPrefs.GetString("Numbers");

        if (Numbers == "notValue" || Active == "notValue")
            {
                cheakBtn.disableBtn();
            }
            else
            {
                cheakBtn.enableBtn();

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
