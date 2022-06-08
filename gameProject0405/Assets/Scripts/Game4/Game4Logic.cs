using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game4Logic : MonoBehaviour
{
    private Game4UiManager Game4UiManager;

    //������
    int Game1Try;
    int Game2Try;
    public navigation sendBtnGame1;
    public navigation sendBtnGame2;

    //������ ���� 1
    public Chat chatGame1;
    string MessageinputGame1;
    public GameObject finishgame1;
    public GameObject questionGame1;

    //������ ���� 2
    public Chat chatGame2;
    string MessageinputGame2;
    public GameObject finishgame2;
    public GameObject questionGame2;


    //�����
    private loadStoryBtn loadStoryBtn;

    //�������� �����
    public GameObject game4Animation;

    // Start is called before the first frame update
    void Start()
    {
        loadStoryBtn = transform.gameObject.GetComponent<loadStoryBtn>();
        //����� �� ������
        loadStoryBtn.disableStoryBtnAll();
        Debug.Log(PlayerPrefs.GetInt("GameMax"));
        //������ �� ������ ���������� ���� ��������
        int myMaxLevel = PlayerPrefs.GetInt("GameMax");
        Debug.Log("Max Level start" + myMaxLevel);
        questionGame1.SetActive(true);
        questionGame2.SetActive(true);

        if (PlayerPrefs.GetInt("GameMax") != 0)
        {
            int MaxStage = PlayerPrefs.GetInt("GameMax");
            Debug.Log(MaxStage);
            loadStoryBtn.EnableStoryBtnsForLevel(MaxStage);
            Debug.Log(MaxStage);
        }
        
        Game4UiManager = transform.gameObject.GetComponent<Game4UiManager>();
    }

    //------------------------------------------------���� 1 �������

    public void initGame1()
    {
        game4Animation.SetActive(false);
        finishgame1.SetActive(false);
        Game1Try = 0;
        MessageinputGame1 = "";
        chatGame1.setChatTitle("petSysaE");
        chatGame1.setProfilePhoto("EasyStep");
        chatGame1.initChat();
        chatGame1.addTextMessage(Chat.Direction.RECEIVE, " ����, ���� ��� ����� petSyzaE, ���� ������ ������ ����� ����������� ������ ���� ����� ������ ������ ������� ���� ����� ����� ���� ��� ����.����� ������ ����� �� ����� ������ �� ��� ��� �� ���� ������� ����� �� ���� ������� ������ ����� ���� ������ ��������� ��", 11);
    }

    public void updateGame1Message(string Message)
    {
        MessageinputGame1 = Message;
    }

    public void sendMessageToGame1Chat()
    {
        Debug.Log(MessageinputGame1);
        chatGame1.addTextMessage(Chat.Direction.SEND, MessageinputGame1, 3);
        StartCoroutine(handleGame1Answer(MessageinputGame1));
    }

    IEnumerator handleGame1Answer(string answer)
    {
        yield return new WaitForSeconds(1);

        bool isCorrectAnswer = answer.Contains("����") || answer.Contains("����� ������") || answer.Contains("����� ����� �����");
        if (isCorrectAnswer)
        {
            chatGame1.addTextMessage(Chat.Direction.RECEIVE, "���� ����� �����! ����� �� �� ������ �����: ���� ������ ��� �����, ����� ������ ���� ������ ����� �����", 8);
            //������� �� �����
            game4Animation.SetActive(true);
            yield return new WaitForSeconds(1);

            chatGame1.addTextMessage(Chat.Direction.RECEIVE, " ���� ������ ���� �����, ���� ��� �� ����� petSyzaE ������ ����", 5);
            displayFinishGame1Screen();
        } 
        else if (Game1Try == 0)
        {
            chatGame1.addTextMessage(Chat.Direction.RECEIVE, "���� �� ������, ���� ����� �� ������� ������", 5);
            Game1Try = 1;
        } 
        else
        {
            chatGame1.addTextMessage(Chat.Direction.RECEIVE, "���� �� ��������, ����� ����� �� ������ �����: ���� ������ ��� �����, ����� ������ ����, ����� ����� �����", 5);
            yield return new WaitForSeconds(1);
            chatGame1.addTextMessage(Chat.Direction.RECEIVE, "���� petSyzaE.����� ����� �� ������� ������ ���� ����� �����", 5);
            displayFinishGame1Screen();
        }
    }
    public void displayFinishGame1Screen()
    {
        questionGame1.SetActive(false);
        //����� ����� ���
        sendBtnGame1.disableBtn();
        //����� ���� ����

        //����� ����� ����� ��'����
        finishgame1.SetActive(true);
    }

    //------------------------------------------------���� 2 �������

    public void initGame2()
    {
        game4Animation.SetActive(false);
        finishgame2.SetActive(false);
        Game2Try = 0;
        MessageinputGame2 = "";
        chatGame2.setChatTitle("efiLretteB");
        chatGame2.setProfilePhoto("BetterLife");
        chatGame2.initChat();
        chatGame2.addTextMessage(Chat.Direction.RECEIVE, "����, ����� ��� ����� efiLretteB, ���� ����� ��������� ������ ���� ���� ����. ����� ����� ���� ���� ������ ����� ����. �����, ��� ��� ����� ���� �� ���� �-3,000 ����� �� �� ����� ���� �� ����� ����� ���� ������� ����� ���.���� ����� ������� �������� ��� ������� ��� ��� ����� �� ������� ����, ����� ���� ����� ��� ��� ��� ���� ������ ���� ����� ? ", 13);
    }

    public void updateGame2Message(string Message)
    {
        MessageinputGame2 = Message;
    }

    public void sendMessageToGame2Chat()
    {
        chatGame2.addTextMessage(Chat.Direction.SEND, MessageinputGame2, 3);
        StartCoroutine(handleGame2Answer(MessageinputGame2));
    }

    IEnumerator handleGame2Answer(string answer)
    {
        yield return new WaitForSeconds(1);

        bool isCorrectAnswer = answer.Contains("������") || answer.Contains("�����") || answer.Contains("�������") || answer.Contains("�������") || answer.Contains("�����") || answer.Contains("�����");
        if (isCorrectAnswer)
        {
            chatGame2.addTextMessage(Chat.Direction.RECEIVE, "���� ����� �����! ����� �� �� �������� �����: ���� ������ ����� ���� �����, ������� ������ �������, ����� ���� ���� ��������, ����� ������ ��� �� ����� ���� ���� ������ ���� �������� ����.", 9);
            //������� �� �����
            game4Animation.SetActive(true);
            yield return new WaitForSeconds(1);
            chatGame2.addTextMessage(Chat.Direction.RECEIVE, " ���� ������ ���� �����, ���� ��� �� ����� ������ ���� efiLretteB", 5);
            displayFinishGame2Screen();
        }
        else if (Game2Try == 0)
        {
            chatGame2.addTextMessage(Chat.Direction.RECEIVE, "���� �� ������, ���� ����� ������� ������ ��������", 5);
            Game2Try = 1;
        }
        else
        {
            chatGame2.addTextMessage(Chat.Direction.RECEIVE, "���� �� ��������, ����� �� �� �������� �����: ���� ������ ����� ���� �����, ������� ������ �������, ����� ���� ���� ��������, ����� ������ ��� �� ����� ���� ���� ������ ���� �������� ����. ", 8);
            yield return new WaitForSeconds(1);
            chatGame2.addTextMessage(Chat.Direction.RECEIVE, "efiLretteB ���� .����� ����� �� ������� ������ ���� ����� �����", 4);
            displayFinishGame2Screen();
        }
    }

    public void displayFinishGame2Screen()
    {
        questionGame2.SetActive(false);
        //����� ����� ���
        sendBtnGame2.disableBtn();
        //����� ���� ����

        //����� ����� ����� ��'����
        finishgame2.SetActive(true);
    }

    /// <summary>
    /// ����� �� ������ ������� ��'�� ������ �� ����� �� ��'��
    /// </summary>

    public void tamirHappyPhoto(int mumber)
    {
        if (mumber == 1)
        {
            chatGame1.addPhoto(Chat.Direction.SEND, "tamirHappy");

        }
        else
        {
            chatGame2.addPhoto(Chat.Direction.SEND, "tamirHappy");
        }
    }

    public void tamirSadPhoto(int mumber)
    {
        if (mumber == 1)
        {
            chatGame1.addPhoto(Chat.Direction.SEND, "tamirSad");

        }
        else
        {
            chatGame2.addPhoto(Chat.Direction.SEND, "tamirSad");
        }
    }

    public void tamirDisgustPhoto(int mumber)
    {
        if (mumber == 1)
        {
            chatGame1.addPhoto(Chat.Direction.SEND, "tamirDisgust");

        }
        else
        {
            chatGame2.addPhoto(Chat.Direction.SEND, "tamirDisgust");
        }
    }

    public void tamirAngryPhoto(int mumber)
    {
        if (mumber == 1)
        {
            chatGame1.addPhoto(Chat.Direction.SEND, "tamirAngry");

        }
        else
        {
            chatGame2.addPhoto(Chat.Direction.SEND, "tamirAngry");
        }
    }

    public void tamirAmazedPhoto(int mumber)
    {
        if (mumber == 1)
        {
            chatGame1.addPhoto(Chat.Direction.SEND, "tamirAmazed");

        }
        else
        {
            chatGame2.addPhoto(Chat.Direction.SEND, "tamirAmazed");
        }
    }


    //������ �� ����� ���� ����
    public void finishAllGamestory()
    {
        //����� ����� �����
        if (PlayerPrefs.GetInt("GameMax") < 4)
        {
            PlayerPrefs.SetInt("GameMax", 4);
        }

        int myMaxLevel = PlayerPrefs.GetInt("GameMax");
        Debug.Log("Max Level" + myMaxLevel);
        loadStoryBtn.enableStoryBtn(myMaxLevel);
    }

}