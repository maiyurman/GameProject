using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using TMPro;

public class Game2UiManager : MonoBehaviour
{

    //------> ����� �����
    public navigation messageBtn;
    public navigation musicBtn;
    public navigation userBtn;
    public navigation placeBtn;

    //------> ����� �����
    public navigation[] storyBtns;

    //------>���� �����
    public GameObject feedbackWindow;
    public TextMeshProUGUI feedbackTxt;

    //------>���� ������ �� ������
    public GameObject influenceInstractionWindow;
    public TextMeshProUGUI influenceInstractionTxt;

    //------>����� ����� �����
    public navigation storyOpenGame2;

    //------>����� �������
  

    public void Start()
    {
        storyOpenGame2.transform.gameObject.SetActive(false);
        //���� �����
        feedbackWindow.SetActive(false);

    }

    public void openTamarStory()
    {
        storyOpenGame2.transform.gameObject.SetActive(true);
        storyOpenGame2.enableBtn();
    }

}
