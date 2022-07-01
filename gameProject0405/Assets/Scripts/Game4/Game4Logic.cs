using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Game4Logic : MonoBehaviour
{
    private Game4UiManager Game4UiManager;

    //������
    int Game1Try;
    int Game2Try;
    public navigation sendBtnGame1;
    public navigation sendBtnGame2;

    public navigation placeBtn;
    public navigation userBtn;
    public navigation MessageBtn;

    //������ ���� 1
    public Chat chatGame1;
    string MessageinputGame1;
    public GameObject finishgame1;
    public GameObject questionGame1;
    public TMP_InputField inputGame1;
    public GameObject lightBtn1;

    //������ ���� 2
    public Chat chatGame2;
    string MessageinputGame2;
    public GameObject finishgame2;
    public GameObject questionGame2;
    public TMP_InputField inputGame2;
    public GameObject lightBtn2;

    //�����
    private loadStoryBtn loadStoryBtn;

    //�������� �����
    public GameObject game4Animation1;
    public GameObject game4Animation2;


    //------>������� ���� 
    public Animator tamirAnimator;

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
        placeBtn.disableBtn();
        userBtn.disableBtn();
        MessageBtn.disableBtn();

        Game4UiManager = transform.gameObject.GetComponent<Game4UiManager>();
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

    public void opengame1ChatBox()
    {
    
        StartCoroutine(lightBtn1Box());
    }

    IEnumerator lightBtn1Box()
    {
        lightBtn1.SetActive(false);
        yield return new WaitForSeconds(3f);
        lightBtn1.SetActive(true);

    }

    public void opengame2ChatBox()
    {

        StartCoroutine(lightBtn2Box());
    }

    IEnumerator lightBtn2Box()
    {
        lightBtn2.SetActive(false);
        yield return new WaitForSeconds(3f);
        lightBtn2.SetActive(true);

    }


    //------------------------------------------------���� 1 �������

    public void initGame1()
    {
        game4Animation1.SetActive(false);
        finishgame1.SetActive(false);
        Game1Try = 0;
        MessageinputGame1 = "";
        chatGame1.setChatTitle("petSysaE");
        chatGame1.setProfilePhoto("EasyStep");
        chatGame1.initChat();
        chatGame1.addTextMessage(Chat.Direction.RECEIVE, " ����, ���� ��� ����� petSyzaE, ���� ������ ������ ����� �����.", 3);
        StartCoroutine(sendMessageChat1());
    }

    IEnumerator sendMessageChat1()
    {
        yield return new WaitForSeconds(3);
        chatGame1.addTextMessage(Chat.Direction.RECEIVE, "����� �������, ����� ������ ������ ������� ���� ����� ����� ���� ��� ���� ���� ����� ������ ����� �� ����� ������ �� ��� ���.", 5);
        yield return new WaitForSeconds(5);
        chatGame1.addTextMessage(Chat.Direction.RECEIVE, "��� ���� ������� ����� �� ���� ������� ������ ����� ���� ������ ��������� ��.", 4);
    }

    public void updateGame1Message(string Message)
    {
        MessageinputGame1 = Message;
    }

    public void onvaluechaneGame1Message()
    {
        if (inputGame1.text == "")
        {
            sendBtnGame1.disableBtn();
        }
        else
        {
            sendBtnGame1.enableBtn();
        }
    }

    public void sendMessageToGame1Chat()
    {
        inputGame1.text = "";
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
            chatGame1.addTextMessage(Chat.Direction.RECEIVE, "���� ����� �����! ����� �� �� ������ �����: ���� ������ ��� �����, ����� ������ ���� ������ ����� �����.", 7);
            yield return new WaitForSeconds(2);
            chatGame1.addTextMessage(Chat.Direction.RECEIVE, "���� ������ ���� �����, ���� ��� �� ����� ������!", 4);
            yield return new WaitForSeconds(1);
            //������� �� �����
            game4Animation1.SetActive(true);

            displayFinishGame1Screen();
        } 
        else if (Game1Try == 0)
        {
            chatGame1.addTextMessage(Chat.Direction.RECEIVE, "���� �� ������, ���� ����� �� ������� ������.", 5);
            Game1Try = 1;
        } 
        else
        {
            chatGame1.addTextMessage(Chat.Direction.RECEIVE, "���� �� ��������, ����� ����� �� ������ �����: ���� ������ ��� �����, ����� ������ ����, ����� ����� �����.", 5);
            yield return new WaitForSeconds(3);
            chatGame1.addTextMessage(Chat.Direction.RECEIVE, "����� ����� �� ������� ������ ���� ����� �����.", 5);
            displayFinishGame1Screen();
        }
    }
    public void displayFinishGame1Screen()
    {
        sendBtnGame1.gameObject.SetActive(false);
        questionGame1.SetActive(false);
        //����� ����� ����� ��'����
        finishgame1.SetActive(true);
    }

    //------------------------------------------------���� 2 �������

    public void initGame2()
    {
        game4Animation2.SetActive(false);
        finishgame2.SetActive(false);
        Game2Try = 0;
        MessageinputGame2 = "";
        chatGame2.setChatTitle("efiLretteB");
        chatGame2.setProfilePhoto("BetterLife");
        chatGame2.initChat();
        chatGame2.addTextMessage(Chat.Direction.RECEIVE, "����, ����� ��� ����� efiLretteB, ���� ����� ��������� ������ ���� ���� ����. ����� ����� ���� ���� ������ ����� ����.", 6);
        StartCoroutine(sendMessageChat2());
    }

    IEnumerator sendMessageChat2()
    {
        yield return new WaitForSeconds(3);
        chatGame2.addTextMessage(Chat.Direction.RECEIVE, "�����, ��� ��� ����� ���� �� ���� �-000,3 ����� �� �� ����� ���� �� ����� ����� ���� ������� ����� ���.", 6);
        yield return new WaitForSeconds(5);
        chatGame2.addTextMessage(Chat.Direction.RECEIVE, "���� ����� ������� �������� ��� ������� ��� ��� ����� �� ������� ����, ����� ���� ����� ��� ��� ��� ���� ������ ���� �����?", 6);
    }

    public void updateGame2Message(string Message)
    {
        MessageinputGame2 = Message;

    }

    public void onvaluechaneGame2Message()
    {
        if (inputGame2.text == "")
        {
            sendBtnGame2.disableBtn();
        }
        else
        {
            sendBtnGame2.enableBtn();
        }
    }

    public void sendMessageToGame2Chat()
    {
        inputGame2.text = "";
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
            yield return new WaitForSeconds(2);
            chatGame2.addTextMessage(Chat.Direction.RECEIVE, "���� ������ ���� �����, ���� ��� �� ����� ������!", 5);
            yield return new WaitForSeconds(1);
            //������� �� �����
            game4Animation2.SetActive(true);
            displayFinishGame2Screen();
        }
        else if (Game2Try == 0)
        {
            chatGame2.addTextMessage(Chat.Direction.RECEIVE, "���� �� ������, ���� ����� ������� ������ ��������.", 5);
            Game2Try = 1;
        }
        else
        {
            chatGame2.addTextMessage(Chat.Direction.RECEIVE, "���� �� ��������, ����� �� �� �������� �����: ���� ������ ����� ���� �����, ������� ������ �������, ����� ���� ���� ��������, ����� ������ ��� �� ����� ���� ���� ������ ���� �������� ����. ", 8);
            yield return new WaitForSeconds(3);
            chatGame2.addTextMessage(Chat.Direction.RECEIVE, "����� ����� �� ������� ������ ���� ����� �����.", 4);
            displayFinishGame2Screen();
        }
    }

    public void displayFinishGame2Screen()
    {
        sendBtnGame2.gameObject.SetActive(false);
        questionGame2.SetActive(false);
        //����� ����� ���
        //����� ����� ����� ��'����
        finishgame2.SetActive(true);
    }

    /// <summary>
    /// ����� �� ������ ������� ��'�� ������ �� ����� �� ��'��
    /// </summary>

    public void tamirHappyPhoto(int mumber)
    {
        StartCoroutine(tamirHappyPhotowaitSeconds(mumber));
    }

    IEnumerator tamirHappyPhotowaitSeconds(int mumber)
    {
        if (mumber == 1)
        {
            chatGame1.addPhoto(Chat.Direction.SEND, "Emoji happy 1");
            yield return new WaitForSeconds(1);
            chatGame1.addTextMessage(Chat.Direction.RECEIVE, "����� ����� ��� ������ ���� ����� ��� ��������!", 2);
        }
        else
        {
            chatGame2.addPhoto(Chat.Direction.SEND, "Emoji happy 1");
            yield return new WaitForSeconds(1);
            chatGame2.addTextMessage(Chat.Direction.RECEIVE, "����� ����� ��� ������ ���� ����� ��� ��������!", 2);
        }

    }



    public void tamirSadPhoto(int number)
    {
        StartCoroutine(tamirSadPhotowaitSeconds(number));
    }

    IEnumerator tamirSadPhotowaitSeconds(int number)
    {
        if (number == 1)
        {
            chatGame1.addPhoto(Chat.Direction.SEND, "Emoji cry 1");
            yield return new WaitForSeconds(1);
            chatGame1.addTextMessage(Chat.Direction.RECEIVE, "������� ����� ���� ��� �������, ���� ����� ����� �� ������ �� ���� �� ��� ���� ����.", 4);
        }
        else
        {
            chatGame2.addPhoto(Chat.Direction.SEND, "Emoji cry 1");
            yield return new WaitForSeconds(1);
            chatGame2.addTextMessage(Chat.Direction.RECEIVE, "������� ����� ���� ��� �������, ���� ����� ����� �� ������ �� ���� �� ��� ���� ����.", 4);
        }
    }

    public void tamirDisgustPhoto(int number)
    {

        StartCoroutine(tamirDisgustPhotowaitSeconds(number));

    }

    IEnumerator tamirDisgustPhotowaitSeconds(int number)
    {
        if (number == 1)
        {
            chatGame1.addPhoto(Chat.Direction.SEND, "Emoji like");
            yield return new WaitForSeconds(1);
            chatGame1.addTextMessage(Chat.Direction.RECEIVE, "����� ����� ��� ������ ����.", 2);
        }
        else
        {
            chatGame2.addPhoto(Chat.Direction.SEND, "Emoji like");
            yield return new WaitForSeconds(1);
            chatGame2.addTextMessage(Chat.Direction.RECEIVE, "����� ����� ��� ������ ����.", 2);
        }
    }


    public void tamirAngryPhoto(int number)
    {
        StartCoroutine(tamirAngryPhotowaitSeconds(number));
    }

    IEnumerator tamirAngryPhotowaitSeconds(int number)
    {
        if (number == 1)
        {
            chatGame1.addPhoto(Chat.Direction.SEND, "Emoji dislike");
            yield return new WaitForSeconds(1);
            chatGame1.addTextMessage(Chat.Direction.RECEIVE, "������� ����� ��� ������ ����. ����� ������ ����� �� ������ �� ���� �� ��� ���� ����.", 4);
        }
        else
        {
            chatGame2.addPhoto(Chat.Direction.SEND, "Emoji dislike");
            yield return new WaitForSeconds(1);
            chatGame2.addTextMessage(Chat.Direction.RECEIVE, "������� ����� ��� ������ ����. ����� ������ ����� �� ������ �� ���� �� ��� ���� ����.", 4);
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