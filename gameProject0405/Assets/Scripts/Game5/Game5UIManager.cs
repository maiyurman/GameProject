using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Game5UIManager : MonoBehaviour
{
    public GameObject round1;
    public GameObject round2;
    public GameObject round3;
    public GameObject influenceFeedBack;
    public navigation checkBtn;
    private Game5DragLogic Game5DragLogic;
    private Dragable currentdragable;
    public GameObject feedbackwindow;
    public GameObject feedbackAnotherTry;
    public TextMeshProUGUI feedbackTxt;
    public TextMeshProUGUI feedbackBtnTxt;
    public int tryNum;
    public int numRound;
    private string message;
    public GameObject round1Animation;
    public GameObject round2Animation;
    public GameObject round3Animation;
    public navigation level5Btn;
    public GameObject goodFeedback;

    //���� ����
    public GameObject tamir;

    //------>������� ���� 
    public Animator tamirAnimator;
    private loadStoryBtn loadStoryBtn;


    void Start()
    {
        loadStoryBtn = transform.gameObject.GetComponent<loadStoryBtn>();
        //����� �� ������
        loadStoryBtn.disableStoryBtnAll();
        Debug.Log(PlayerPrefs.GetInt("GameMax"));
        //������ �� ������ ���������� ���� ��������
        int myMaxLevel = PlayerPrefs.GetInt("GameMax");
        initround();
        tryNum = 0;
        checkBtn.gameObject.transform.gameObject.SetActive(false);
        Game5DragLogic = transform.gameObject.GetComponent<Game5DragLogic>();
        feedbackwindow.SetActive(false);
        numRound = 1;
        round1Animation.SetActive(false);
        round2Animation.SetActive(false);
        round3Animation.SetActive(false);
        goodFeedback.SetActive(false);

        if (PlayerPrefs.GetInt("GameMax") != 0)
        {
            int MaxStage = PlayerPrefs.GetInt("GameMax");
            Debug.Log(MaxStage);
            loadStoryBtn.EnableStoryBtnsForLevel(MaxStage);
            Debug.Log(MaxStage);
        }

    }

    public void stopTamirTalk()
    {
        StartCoroutine(stopTamirStartTalk());

    }

    IEnumerator stopTamirStartTalk()
    {
        yield return new WaitForSeconds(2);
        tamirAnimator.SetBool("isTalk", false);
    }

    public void initround()
    {
        influenceFeedBack.SetActive(false);
        feedbackAnotherTry.SetActive(false);
        round1.SetActive(false);
        round2.SetActive(false);
        round3.SetActive(false);
    }

    public void movetoPlace(Dragable dragable, DropArea dropArea)
    {
        currentdragable = dragable;
        //����� �� ������
        Vector3 dragableplace = dragable.transform.position;
        dragableplace = dropArea.transform.position;
        //����� �� ����� ������
        checkBtn.enableBtn();
        Debug.Log("btnOn");

    }

    public void checkBtnClick()
    {
        if (Game5DragLogic.isTrueAnswer == true)
        {
            feedbackTrue();
        }
        else
        {
            feedbackfalse();

        }
    }

    public void feedbackTrue()
    {
        //������� �� ����� ������
        checkBtn.gameObject.transform.gameObject.SetActive(false);
        if (numRound == 1)
        {
            //�������� �����
            round1Animation.SetActive(true);
        }
        else if(numRound == 2)
        {
            round2Animation.SetActive(true);        }
        else
        {
            round3Animation.SetActive(true);
        }
        StartCoroutine(MySeconds());
    }

    public void feedbackfalse()
    {
        if (tryNum == 0)
        {
            feedbackfalseTry();
        }
        else
        {
            feedbackfalseFinish();
            feedbackFalseMessageRound();
            feedbackwindowopen(message);
        }

    }

    public void feedbackfalseTry()
    {
        currentdragable.returnToInitPosition();
        feedbackAnotherTry.SetActive(true);
        //������ ���� ��� ���� ���
        checkBtn.disableBtn();
        tryNum++;
    }

    public void feedbackfalseFinish()
    {
        //������� �� ����� ������
        checkBtn.gameObject.transform.gameObject.SetActive(false);

    }

    public void feedbackwindowopen(string message)
    {
        feedbackwindow.SetActive(true);
        feedbackTxt.text = message;

        if (numRound == 1 | numRound == 2)
        {
            feedbackBtnTxt.text = "����� ���";
        }
        else
        {
            feedbackBtnTxt.text = "����� �����";
        }
    }

    public void feedbackFalseMessageRound()
    {
        if (numRound == 1)
        {
            message = "������� ���� ����� ������ ����� ����� ��� �� ���� -�� ������ �� ����� ���� ��� ��� ��� ��� �� ��� ���� �� ������";
        }
        else if (numRound == 2)
        {
            message = "������� ���� ����� ������ ����� ����� ��� �� ���� -�� ������ �� ����� ���� ��� ��� ��� ��� �� ��� ���� �� ������";
        }
        else
        {
            message = "������� ���� ����� ������ ����� ����� ��� �� �� -�� ������ �� ����� ���� ��� ��� ��� ��� �� ��� ���� �� ������";
        }
    }

    public void finishRoundClick()
    {
        if (numRound == 1)
        {
            numRound++;
            round1.SetActive(false);
            round2.SetActive(true);
            round3.SetActive(false);
            feedbackwindow.SetActive(false);
            Game5DragLogic.isTrueAnswer = false;
            tryNum = 0;
            checkBtn.gameObject.transform.gameObject.SetActive(true);
        }
        else if (numRound == 2)
        {
            numRound++;
            round1.SetActive(false);
            round2.SetActive(false);
            round3.SetActive(true);
            feedbackwindow.SetActive(false);
            Game5DragLogic.isTrueAnswer = false;
            tryNum = 0;
            checkBtn.gameObject.transform.gameObject.SetActive(true);

        }
        else
        {
            stopTamirTalk();
            influenceFeedBack.SetActive(true);
            tamir.SetActive(true);
            feedbackwindow.SetActive(false);
            level5Btn.enableBtn();
            if (PlayerPrefs.GetInt("GameMax") < 5)
            {
                PlayerPrefs.SetInt("GameMax", 5);
            }

            int myMaxLevel = PlayerPrefs.GetInt("GameMax");
            Debug.Log("Max Level" + myMaxLevel);
            loadStoryBtn.enableStoryBtn(myMaxLevel);
        }

    }

    IEnumerator MySeconds()
    {
        if (numRound == 1)
        {
            yield return new WaitForSeconds(5f);
        }
        else
        {
            yield return new WaitForSeconds(9f);
        }
        message = "����� ����� ������! ����� �� �� ��������� ���������� ������ �� ������� ������ �����.";
        goodFeedback.SetActive(true);
        //������� ������� ����
        feedbackwindowopen(message);
    }

}



