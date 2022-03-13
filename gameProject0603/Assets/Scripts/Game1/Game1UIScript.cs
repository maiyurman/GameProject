using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Game1UIScript : MonoBehaviour
{
    public navigation messageBtn;
    public GameObject openScreen;
    public GameObject Screen1;
    public GameObject Screen2;

    //----->����� �� �������
    public GameObject try1Answer;
    public GameObject try2Answer;
    public GameObject try3Answer;

    //-----> ������ �� �������
    public TextMeshProUGUI chatAnswer1;
    public TextMeshProUGUI chatAnswer2;
    public TextMeshProUGUI chatAnswer3;

    public TextMeshProUGUI userchoose1;
    public TextMeshProUGUI userchoose2;
    public TextMeshProUGUI userchoose3;

    //----> ����� ������
    public GameObject scroolBar;

    ///---> ����� ���� ��'���� 
    public GameObject questionView;
    public GameObject finishChat;

    void Start()
    {
        try1Answer.SetActive(false);
        try2Answer.SetActive(false);
        try3Answer.SetActive(false);
        scroolBar.SetActive(false);
        finishChat.SetActive(false);
        questionView.SetActive(true);
    }

    public void btnMessageBtn()
    {
        messageBtn.enableBtn();
    }

    public void openScreen1()
    {
        openScreen.SetActive(false);
        Screen1.SetActive(true);
    }

    public void openScreen2()
    {
        Screen1.SetActive(false);
        Screen2.SetActive(true);
    }

    public void AnswerFeedback(int numOfTrying, bool isAnswerTrue, string writeOnBtn)
    {
            if (numOfTrying == 0)
            {
            try1Answer.SetActive(true);
            userchoose1.text = writeOnBtn;
                if (isAnswerTrue == true)
                {
                chatAnswer1.text = "�� ����� ����� ����� ���� ���� �������!";
                finishChat.SetActive(true);
                questionView.SetActive(false);
                }
                else
                {
                chatAnswer1.text = "��� �� ����� ��� ���� �����, ��� ����� ������� ����";
                }
            }
            else if (numOfTrying == 1)
            {
            scroolBar.SetActive(true);
            try2Answer.SetActive(true);
            userchoose2.text = writeOnBtn;
                if (isAnswerTrue == true)
                {
                    chatAnswer2.text = "�� ����� ����� ����� ���� ���� �����!";
                    finishChat.SetActive(true);
                    questionView.SetActive(false);
                }
                else
                {
                    chatAnswer2.text = "����� ����� ������ ����� ����� ����� �� ���� �����";
                }
            }
            else
            {
            try3Answer.SetActive(true);
            userchoose3.text = writeOnBtn;
            questionView.SetActive(false);
            finishChat.SetActive(true);
                if (isAnswerTrue == true)
                {
                    chatAnswer3.text = "�� ����� ����� ����� ���� ���� �������!";
                }
                else
                {
                    chatAnswer3.text = ".���� ������ �� ��, ����� ������ ������ ��� ��� ���� ����� ��� �� ����! ����� ������ ��� ������ �� ����� ������ ��� ���� �� ����� �����";
                }
            }
        }
}

