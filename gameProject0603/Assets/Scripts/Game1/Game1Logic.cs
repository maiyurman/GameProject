using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game1Logic : MonoBehaviour
{
    //������ ���� 1
    private Game1UIScript Game1UIScript;
    public Chat chatGame1;
    private int tryGame1;
    public GameObject finishGame1;

    //������ ���� 2
    public Chat chatGame2;
    private int tryGame2;
    public GameObject finishGame2;

    //������ ���� 3
    public Chat chatGame3;
    private int tryGame3;
    public GameObject finishGame3;

    //�����
    private loadStoryBtn loadStoryBtn;
    bool isAnswerTrue = false;

    void Start()
    {
        loadStoryBtn = GameObject.Find("levels").GetComponent<loadStoryBtn>();
        Game1UIScript = transform.gameObject.GetComponent<Game1UIScript>();

        //���� 1
        chatGame1.setChatTitle("��� ���");
        chatGame1.addVideo(Chat.Direction.RECEIVE, "6");
        tryGame1 = 2;

        //���� 2
        chatGame2.setChatTitle("��� �� ���");
        chatGame2.addVideo(Chat.Direction.RECEIVE, "6");
        tryGame2 = 2;

        //���� 3
        chatGame3.setChatTitle("'��� ��������");
        chatGame3.addVideo(Chat.Direction.RECEIVE, "6");
        tryGame3 = 2;
    }


    //public void B1()
    //{
    //    chat.addVideo(Chat.Direction.RECEIVE, "6");
    //    chat.addPhoto(Chat.Direction.RECEIVE, "6");
    //    chat.addTextMessage(Chat.Direction.RECEIVE, "sdfsdfs\ndsfsfsfs");
    //    chat.addTextMessage(Chat.Direction.RECEIVE, "���� ��� ��� ��� �������� ������� ������ ��� ��� ��� '����������� �������9", 3);
    //}
    //public void B2()
    //{
    //    chat.addVideo(Chat.Direction.SEND, "2");
    //    chat.addPhoto(Chat.Direction.SEND, "2");
    //    chat.addTextMessage(Chat.Direction.SEND, "���� ��� ��� ��� �������� ������� ������ ��� ��� ��� '����������� �������9", 3);
    //}




    //------------------------------------------------���� 1 �������

    public void Game1TrueAnswer()
    {
        isAnswerTrue = true;
        chatGame1.addTextMessage(Chat.Direction.SEND,"�� �� ������ ���� �� ���� ��� ����", 3);
        Game1feedbackforanswers();
    }

    public void Game1FalseAnswer1()
    {
        chatGame1.addTextMessage(Chat.Direction.SEND, "������ ��� �� ������ ��������� ���", 3);
        Game1feedbackforanswers();
        tryGame1Down();
    }

    public void Game1FalseAnswer2()
    {
        chatGame1.addTextMessage(Chat.Direction.SEND, "���� ��� �� ����� ��", 3);
        Game1feedbackforanswers();
        tryGame1Down();
    }

    public void Game1FalseAnswer3()
    {
        chatGame1.addTextMessage(Chat.Direction.SEND, "�� ����� ���� ������", 3);
        Game1feedbackforanswers();
        tryGame1Down();
    }

    public void Game1feedbackforanswers()
    {
        if (isAnswerTrue)
        {
            chatGame1.addTextMessage(Chat.Direction.RECEIVE, "����� ��� ����� ���� ����� �� ������ ��� ����", 2);
            finishGame1.SetActive(true);
            isAnswerTrue = false;
        }
        else
        {
            if (tryGame1 == 2)
            {
                chatGame1.addTextMessage(Chat.Direction.RECEIVE, ",��� �� ����� ��� ���� �����, ��� ����� ������� ����", 2);
            }
            else if (tryGame1 == 1)
            {
                chatGame1.addTextMessage(Chat.Direction.RECEIVE, "����� ����� ������ ����� ����� ����� �� ���� �����", 2);
            }
            else
            {
                chatGame1.addTextMessage(Chat.Direction.RECEIVE, ".���� ������ �� ��, ����� ������ ������ ��� ��� ���� ����� ��� �� ���� !����� ������ ��� ������ �� ����� ������ ��� ���� �� ����� �����", 5);
                finishGame1.SetActive(true);
                isAnswerTrue = false;
            }
        }
    }

    //------------------------------------------------���� 2 �������

    public void Game2TrueAnswer()
    {
        isAnswerTrue = true;
        chatGame2.addTextMessage(Chat.Direction.SEND, "��� ����� ������� ��� ���� �����", 3);
        Game2feedbackforanswers();
    }

    public void Game2FalseAnswer1()
    {
        chatGame2.addTextMessage(Chat.Direction.SEND, "���� ����� ����� ���� ����", 3);
        Game2feedbackforanswers();
        tryGame2Down();
    }

    public void Game2FalseAnswer2()
    {
        chatGame2.addTextMessage(Chat.Direction.SEND, "������ ��� ������� ����� ������", 3);
        Game2feedbackforanswers();
        tryGame2Down();
    }

    public void Game2FalseAnswer3()
    {
        chatGame2.addTextMessage(Chat.Direction.SEND, "����� ������ �� ���� ����", 3);
        Game2feedbackforanswers();
        tryGame2Down();
    }

    public void Game2feedbackforanswers()
    {
        if (isAnswerTrue)
        {
            chatGame2.addTextMessage(Chat.Direction.RECEIVE, "!����, ����� ���� ���� ���� ���� ����� ��, ���� �� �����", 2);
            finishGame2.SetActive(true);
            isAnswerTrue = false;
        }
        else
        {
            if (tryGame2 == 2)
            {
                chatGame2.addTextMessage(Chat.Direction.RECEIVE, ".��� �� ���� ��� ���� �����, ��� ����� ������� ����", 2);
            }
            else if (tryGame2 == 1)
            {
                chatGame2.addTextMessage(Chat.Direction.RECEIVE, "����� ����� ������ ����� ����� ����� �� ���� �����", 2);
            }
            else
            {
                chatGame2.addTextMessage(Chat.Direction.RECEIVE, ".���� ������ �� ��, ����� ������ ������ ��� ��� ���� ���� ��� ���� ���� ���� ���� !����� ������ ��� ������ �� ����� ������ ��� ���� �� ����� �����", 5);
                finishGame2.SetActive(true);
                isAnswerTrue = false;
            }
        }
    }

    //------------------------------------------------���� 3 �������

    public void Game3TrueAnswer()
    {
        isAnswerTrue = true;
        chatGame3.addTextMessage(Chat.Direction.SEND, "�� ���� ������� ����� ����� ������", 3);
        Game3feedbackforanswers();
    }

    public void Game3FalseAnswer1()
    {
        chatGame3.addTextMessage(Chat.Direction.SEND, "�� �� ����� ������ �� ������", 3);
        Game3feedbackforanswers();
        tryGame3Down();
    }

    public void Game3FalseAnswer2()
    {
        chatGame3.addTextMessage(Chat.Direction.SEND, "������� ��� ���� ����", 3);
        Game3feedbackforanswers();
        tryGame3Down();
    }

    public void Game3FalseAnswer3()
    {
        chatGame3.addTextMessage(Chat.Direction.SEND, "���� ������� �������", 3);
        Game3feedbackforanswers();
        tryGame3Down();
    }

    public void Game3feedbackforanswers()
    {
        if (isAnswerTrue)
        {
            chatGame3.addTextMessage(Chat.Direction.RECEIVE, "����, �� �� ����� ��� ��� ����� ����� �� ��! ���� �� �����", 2);
            finishGame3.SetActive(true);
            isAnswerTrue = false;
        }
        else
        {
            if (tryGame3 == 2)
            {
                chatGame3.addTextMessage(Chat.Direction.RECEIVE, "��� �� ����� ��� ���� �����, ���� ����� ������� ����", 2);
            }
            else if (tryGame3 == 1)
            {
                chatGame3.addTextMessage(Chat.Direction.RECEIVE, "����� ����� ������ ����� ����� ����� �� ���� �����", 2);
            }
            else
            {
                chatGame3.addTextMessage(Chat.Direction.RECEIVE, ".���� ������ �� ��, ����� ������ ������ ��� ��� ������ ����� ���� ����� ����� ������. ����� ������ ��� ������ �� ����� ������ ��� ���� �� ����� �����", 5);
                finishGame3.SetActive(true);
                isAnswerTrue = false;
            }
        }
    }

    //����� ���� �������� ��� �������
    public void tryGame1Down()
    {
        if (tryGame1 != 0)
        {
            tryGame1--;
        }
    }

    public void tryGame2Down()
    {
        if (tryGame2 != 0)
        {
            tryGame2--;
        }
    }

    public void tryGame3Down()
    {
        if (tryGame3 != 0)
        {
            tryGame3--;
        }
    }

    public void finishGame()
    {
        //����� ����� �����
        PlayerPrefs.SetInt("openGameMax", 1);
        int myMaxLevel = PlayerPrefs.GetInt("openGameMax");
        loadStoryBtn.enableStoryBtn(myMaxLevel);

        //������ ����� �� ���� �� ����� ����� ������ ������ �� �������
    }
}