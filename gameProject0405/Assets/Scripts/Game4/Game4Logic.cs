using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Game4Logic : MonoBehaviour
{
    private Game4UiManager Game4UiManager;
    
    public navigation sendBtnGame2;

    public navigation placeBtn;
    public navigation userBtn;
    public navigation MessageBtn;


    //������ ���� 
    public Chat chatGame2;
    string MessageinputGame2;
    public GameObject finishgame2;
    public GameObject questionGame2;
    public TMP_InputField inputGame2;
    public GameObject lightBtn2;

    //�����
    private loadStoryBtn loadStoryBtn;

    //�������� �����
    public GameObject game4Animation2;


    //------>������� ���� 
    public Animator tamirAnimator;

    public Animator tamir;

    public GameObject emojiHappy;
    public GameObject emojiSad;
    public GameObject emojiLike;
    public GameObject emojiDislike;

    string musicOn;

    string currentMusic;

    int isAnswer;


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
        isAnswer = 0;

        Game4UiManager = transform.gameObject.GetComponent<Game4UiManager>();
        stage4Sentence1();
    }

    public void Checkmusicbtns(string musicBtnName)
    {
        musicOn = PlayerPrefs.GetString("isMusicOn");
        //�� ������� ������
        if (musicOn == "true")
        {
            FindObjectOfType<audioManger4>().stayOn(musicBtnName);
        }
        else
        {
            FindObjectOfType<audioManger4>().stayOff(musicBtnName);
        }
    }

    public void stage4Sentence1()
    {
        tamir.SetBool("isTalk", true);
        currentMusic = "stage4Sentence1";
        Checkmusicbtns(currentMusic);
        FindObjectOfType<audioManger4>().Play("stage4Sentence1");
        FindObjectOfType<audioManger4>().isPlaying("stage4Sentence1");
    }

    public void stage4Sentence2()
    {
        if (currentMusic == "stage4Sentence1")
        {
            stopMusic();
            tamir.SetBool("isTalk", true);
            currentMusic = "stage4Sentence2";
            Checkmusicbtns(currentMusic);
            FindObjectOfType<audioManger4>().Play("stage4Sentence2");
            FindObjectOfType<audioManger4>().isPlaying("stage4Sentence2");
        }
    }

    public void stage4Sentence3()
    {
        if (currentMusic == "stage4Sentence2")
        {
            stopMusic();
            tamir.SetBool("isTalk", true);
            currentMusic = "stage4Sentence3";
            Checkmusicbtns(currentMusic);
            FindObjectOfType<audioManger4>().Play("stage4Sentence3");
            FindObjectOfType<audioManger4>().isPlaying("stage4Sentence3");
        }
    }

    public void stage4Sentence4()
    {
        if (currentMusic == "stage4Sentence3")
        {
            stopMusic();
            tamir.SetBool("isTalk", true);
            currentMusic = "stage4Sentence4";
            Checkmusicbtns(currentMusic);
            FindObjectOfType<audioManger4>().Play("stage4Sentence4");
            FindObjectOfType<audioManger4>().isPlaying("stage4Sentence4");
        }
    }

    public void ClickSoundBtn(string sound)
        {
            FindObjectOfType<audioManger4>().click(sound);
        }

        public void stopMusic()
        {
            string musicName = currentMusic;
            FindObjectOfType<audioManger4>().StopPlaying(musicName);
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

    public void initGame2()
    {
        game4Animation2.SetActive(false);
        finishgame2.SetActive(false);
        MessageinputGame2 = "";
        chatGame2.setChatTitle("petSysaE");
        chatGame2.setProfilePhoto("EasyStep");
        chatGame2.initChat();
    }

   public void sendMessageTochat()
    {
        chatGame2.addTextMessage(Chat.Direction.RECEIVE, "����, ����� ��� ����� petSysaE, ���� ����� ��������� ������ ���� ���� ����. ��� ���� �� ������� ���� ����� ������ ����� �� �������� �����.", 8);
        StartCoroutine(sendMessageChat2());
        sendBtnGame2.disableBtn();
    }

    IEnumerator sendMessageChat2()
    {
        yield return new WaitForSeconds(6);
        playMessage();
        chatGame2.addTextMessage(Chat.Direction.RECEIVE, "���� ������ ���� ������ ������� ����� ���� ���� ������ ���� ��� ������ ����� ���.", 5);

        yield return new WaitForSeconds(4);
        playMessage();
        chatGame2.addTextMessage(Chat.Direction.RECEIVE, "�� �� ������ ���� �� ���� ���� ����� ������ 000,3 �����, ���� ���� ���� ������ ������ ������ ��� ��� �� ������ ���� �� ���� ���� ����. ", 8);


        yield return new WaitForSeconds(5);
        playMessage();
        chatGame2.addTextMessage(Chat.Direction.RECEIVE, "���� ����� ������� �������� ��� ������� ��� ��� ����� �� ������� ����, ����� ���� ����� ��� ��� ��� ���� ������ ���� �����?", 6);

        yield return new WaitForSeconds(4);
        playMessage();
        chatGame2.addTextMessage(Chat.Direction.RECEIVE, "�������� ����� ����� ��� �� ���� ����� ���: ����� ���� �������� ����, ������ ���� ����� ������. ���� ����� ������� ������ �� ���� ����� �����.", 8);
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
        if (isAnswer == 0)
        {
            playMessage();
            chatGame2.addTextMessage(Chat.Direction.RECEIVE, "���� �� ������! ��� ��� ������� ������, ���� ����� ��� ����� ��� ���� �� ��� ����� ������� ������.",5);
            isAnswer = 1;
        }
        else
        {
            playMessage();
            chatGame2.addTextMessage(Chat.Direction.RECEIVE, "�����! ���� ��� �� �������� �����. ����� ����� ����� �� �����.",4);
            //������� �� �����
            game4Animation2.SetActive(true);
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
            chatGame2.addObject(Chat.Direction.SEND, emojiHappy);
            yield return new WaitForSeconds(1);
            playMessage();
            chatGame2.addTextMessage(Chat.Direction.RECEIVE, "����� ����� ��� ������ ���� ����� ��� ��������!", 2);
    }



    public void tamirSadPhoto(int number)
    {
        StartCoroutine(tamirSadPhotowaitSeconds(number));
    }

    IEnumerator tamirSadPhotowaitSeconds(int number)
    {
            chatGame2.addObject(Chat.Direction.SEND, emojiSad);
            yield return new WaitForSeconds(1);
            playMessage();
            chatGame2.addTextMessage(Chat.Direction.RECEIVE, "������� ����� ���� ��� �������, ���� ����� ����� �� ������ �� ���� �� ��� ���� ����.", 4);
        
    }

    public void tamirDisgustPhoto(int number)
    {

        StartCoroutine(tamirDisgustPhotowaitSeconds(number));

    }

    IEnumerator tamirDisgustPhotowaitSeconds(int number)
    {      
            chatGame2.addObject(Chat.Direction.SEND, emojiLike);
            yield return new WaitForSeconds(1);
            playMessage();
            chatGame2.addTextMessage(Chat.Direction.RECEIVE, "����� ����� ��� ������ ����.", 2);
        
    }


    public void tamirAngryPhoto(int number)
    {
        StartCoroutine(tamirAngryPhotowaitSeconds(number));
    }

    IEnumerator tamirAngryPhotowaitSeconds(int number)
    {
            chatGame2.addObject(Chat.Direction.SEND, emojiDislike);
            yield return new WaitForSeconds(1);
            playMessage();
            chatGame2.addTextMessage(Chat.Direction.RECEIVE, "������� ����� ��� ������ ����. ����� ������ ����� �� ������ �� ���� �� ��� ���� ����.", 4);
        
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

    public void playMessage()
    {
        if (musicOn == "true")
        {
            FindObjectOfType<audioManger4>().Play("receiveMessage");
        }
    }

}