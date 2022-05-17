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
    private int tryGame1;
    string MessageinputGame1;
    public GameObject finishgame1;

    //������ ���� 2
    public Chat chatGame2;
    private int tryGame2;
    string MessageinputGame2;
    public GameObject finishgame2;

    //�����
    private loadStoryBtn loadStoryBtn;

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

        if (PlayerPrefs.GetInt("GameMax") != 0)
        {
            int MaxStage = PlayerPrefs.GetInt("GameMax");
            Debug.Log(MaxStage);
            loadStoryBtn.EnableStoryBtnsForLevel(MaxStage);
            Debug.Log(MaxStage);
        }



        finishgame1.SetActive(false);
        Game1Try = 0;
        Game2Try = 0;
        Game4UiManager = transform.gameObject.GetComponent<Game4UiManager>();

        //���� 1
        chatGame1.setChatTitle("EasyStep");
        //chatGame1.addTextMessage(Chat.Direction.RECEIVE, " ����, ���� ��� ����� petSyzaE, ���� ������ ������ ����� ����������� ������ ���� ����� ������ ������ ������� ���� ����� ����� ���� ��� ����.����� ������ ����� �� ����� ������ �� ��� ��� �� ���� ������� ����� �� ���� ������� ������ ����� ���� ������ ��������� ��", 11);

        //chatGame1.addTextMessage(Chat.Direction.SEND, "sdfsdf", 3);

        //chatGame1.addTextMessage(Chat.Direction.RECEIVE, "���� �� ������, ���� ����� �� ������� ������", 5);

        //chatGame1.addTextMessage(Chat.Direction.SEND, "jytkjtku", 3);

        //chatGame1.addTextMessage(Chat.Direction.RECEIVE, "���� �� ��������, ����� ����� �� ������ �����: ���� ������ ��� �����, ����� ������ ����, ����� ����� �����", 5);
        //chatGame1.addTextMessage(Chat.Direction.RECEIVE, "petSyzaE ���� .����� ����� �� ������� ������ ���� ����� �����", 5);


        //���� 2
        chatGame2.setChatTitle("BetterLife");
        chatGame2.addTextMessage(Chat.Direction.RECEIVE, "����, ����� ��� ����� efiLretteB, ���� ����� ��������� ������ ���� ���� ����. ����� ����� ���� ���� ������ ����� ����. �����, ��� ��� ����� ���� �� ���� �-3,000 ����� �� �� ����� ���� �� ����� ����� ���� ������� ����� ���.���� ����� ������� �������� ��� ������� ��� ��� ����� �� ������� ����, ����� ���� ����� ��� ��� ��� ���� ������ ���� ����� ? ", 12);

    }

    //------------------------------------------------���� 1 �������


    public void Game1Input(string Message)
    {
        MessageinputGame1 = Message;
    }

    public void Game1SendMessage()
    {
        chatGame1.addTextMessage(Chat.Direction.SEND, MessageinputGame1, 3);
        findWordGame1();
    }

    public void findWordGame1()
    {
        string s = MessageinputGame1;
        if (s.Contains("����") == true || s.Contains("����� ������") || s.Contains("����� ����� �����"))
        {
            chatGame1.addTextMessage(Chat.Direction.RECEIVE, "���� ����� �����! ����� �� �� ������ �����: ���� ������ ��� �����, ����� ������ ���� ������ ����� �����", 8);
        //������� �� �����

        //����� ����� ���� 2 �����
        //yield return new WaitForSeconds(2);
        seconds();
        chatGame1.addTextMessage(Chat.Direction.RECEIVE, " ���� ������ ���� �����, ���� ��� �� ����� petSyzaE ������ ����", 5);
        //���� ���� 1
        Finishgame1();
        }
        else if(Game1Try == 0)
        {
            chatGame1.addTextMessage(Chat.Direction.RECEIVE, "���� �� ������, ���� ����� �� ������� ������", 5);
            Game1Try = 1;
        }
        else
        {
        chatGame1.addTextMessage(Chat.Direction.RECEIVE, "���� �� ��������, ����� ����� �� ������ �����: ���� ������ ��� �����, ����� ������ ����, ����� ����� �����", 5);
        //����� ����� ���� 2 �����
        //yield return new WaitForSeconds(2);
        seconds();
        chatGame1.addTextMessage(Chat.Direction.RECEIVE, "petSyzaE ���� .����� ����� �� ������� ������ ���� ����� �����", 5);
        Finishgame1();

        }

        //chatGame1.addTextMessage(Chat.Direction.RECEIVE, " ����, ���� ��� ����� petSyzaE, ���� ������ ������ ����� ����������� ������ ���� ����� ������ ������ ������� ���� ����� ����� ���� ��� ����.����� ������ ����� �� ����� ������ �� ��� ��� �� ���� ������� ����� �� ���� ������� ������ ����� ���� ������ ��������� ��", 11);

        //chatGame1.addTextMessage(Chat.Direction.SEND, MessageinputGame1, 3);

        //chatGame1.addTextMessage(Chat.Direction.RECEIVE, "���� �� ������, ���� ����� �� ������� ������", 5);

        //chatGame1.addTextMessage(Chat.Direction.SEND, MessageinputGame1, 3);

        //chatGame1.addTextMessage(Chat.Direction.RECEIVE, "���� �� ��������, ����� ����� �� ������ �����: ���� ������ ��� �����, ����� ������ ����, ����� ����� �����", 5);
        //chatGame1.addTextMessage(Chat.Direction.RECEIVE, "petSyzaE ���� .����� ����� �� ������� ������ ���� ����� �����", 5);
    }

    public void Finishgame1()
    {
        //����� ����� ���
        sendBtnGame1.disableBtn();
        //����� ���� ����

        //����� ����� ����� ��'����
        finishgame1.SetActive(true);
    }






    //------------------------------------------------���� 2 �������


    public void Game2Input(string Message)
    {
        MessageinputGame2 = Message;
    }

    public void Game2SendMessage()
    {
        chatGame2.addTextMessage(Chat.Direction.SEND, MessageinputGame2, 3);
        findWordGame2();
    }

    public void findWordGame2()
    {
        string s = MessageinputGame2;
        if (s.Contains("������") == true || s.Contains("�����") || s.Contains("�������") || s.Contains("�������") || s.Contains("�����") || s.Contains("�����"))
        {
            chatGame2.addTextMessage(Chat.Direction.RECEIVE, "���� ����� �����! ����� �� �� �������� �����: ���� ������ ����� ���� �����, ������� ������ �������, ����� ���� ���� ��������, ����� ������ ��� �� ����� ���� ���� ������ ���� �������� ����.", 8);
            //������� �� �����

            //����� ����� ���� 2 �����
            //yield return new WaitForSeconds(2);
            seconds();
            chatGame2.addTextMessage(Chat.Direction.RECEIVE, " ���� ������ ���� �����, ���� ��� �� ����� efiLretteB ������ ����", 5);
            //���� ���� 2
            Finishgame2();
        }
        else if (Game2Try == 0)
        {
            chatGame2.addTextMessage(Chat.Direction.RECEIVE, "���� �� ������, ���� ����� ������� ������ ��������", 5);
            Game2Try = 1;
        }
        else
        {
            chatGame2.addTextMessage(Chat.Direction.RECEIVE, "���� �� ��������, ����� �� �� �������� �����: ���� ������ ����� ���� �����, ������� ������ �������, ����� ���� ���� ��������, ����� ������ ��� �� ����� ���� ���� ������ ���� �������� ����. ", 5);
            //����� ����� ���� 2 �����
            //yield return new WaitForSeconds(2);
            seconds();
            chatGame2.addTextMessage(Chat.Direction.RECEIVE, "efiLretteB ���� .����� ����� �� ������� ������ ���� ����� �����", 5);
            Finishgame2();
        }
    }

    public void Finishgame2()
    {
        //����� ����� ���
        sendBtnGame2.disableBtn();
        //����� ���� ����

        //����� ����� ����� ��'����
        finishgame2.SetActive(true);
    }

    //������ ���� 2 �����
    public IEnumerator seconds()
    {
        yield return new WaitForSeconds(2);
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
