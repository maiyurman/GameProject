using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Game1Logic : MonoBehaviour
{
    //������ ���� 1
    private Game1UIScript Game1UIScript;
    public Chat chatGame1;
    private int tryGame1;
    public GameObject finishGame1;
    public GameObject video1;
    public TextMeshProUGUI textVideo1;
    public GameObject trueAnimation1;
    public GameObject questions1;
    public GameObject finishgame1;
    public GameObject subtitleBK1;
    public GameObject lightBtn1;

    //������ ���� 2
    public Chat chatGame2;
    private int tryGame2;
    public GameObject finishGame2;
    public GameObject video2;
    public TextMeshProUGUI textVideo2;
    public GameObject trueAnimation2;
    public GameObject questions2;
    public GameObject finishgame2;
    public GameObject subtitleBK2;
    public GameObject lightBtn2;


    //������ ���� 3
    public Chat chatGame3;
    private int tryGame3;
    public GameObject finishGame3;
    public GameObject video3;
    public TextMeshProUGUI textVideo3;
    public GameObject trueAnimation3;
    public GameObject questions3;
    public GameObject finishgame3;
    public GameObject subtitleBK3;
    public GameObject lightBtn3;

    //�����
    private loadStoryBtn loadStoryBtn;
    bool isAnswerTrue = false;

    //��������
    public Animator orAnimator;
    public Animator tamarAnimator;
    public Animator emaAnimator;
    public Animator tamir;

    public Image sound1;
    public Image sound2;
    public Image sound3;

    public navigation continuebtn;


    void Start()
    {
        loadStoryBtn = transform.gameObject.GetComponent<loadStoryBtn>();
        Game1UIScript = transform.gameObject.GetComponent<Game1UIScript>();
        
        //���� 1
        chatGame1.initChat();
        chatGame1.setChatTitle("��� ���");
        chatGame1.setProfilePhoto("tamar");
        chatGame1.addVideo(Chat.Direction.RECEIVE, "tamarVideoPhotos", playVideo1);
        chatGame1.addTextMessage(Chat.Direction.RECEIVE, "���� ������ ���� ����� ����� ������ ������ ��� ��� ����� ��", 3);
        tryGame1 = 2;
        video1.SetActive(false);
        textVideo1.text = "";
        trueAnimation1.SetActive(false);
        questions1.SetActive(true);
        finishgame1.SetActive(false);
        subtitleBK1.SetActive(true);

    //���� 2
    chatGame2.initChat();
        chatGame2.setChatTitle("��� �� ���");
        chatGame2.setProfilePhoto("or");
        chatGame2.addVideo(Chat.Direction.RECEIVE, "orVideoPhotos", playVideo2);
        chatGame2.addTextMessage(Chat.Direction.RECEIVE, "���� ������ ���� ����� ����� ������ ������ ��� ��� ����� ��", 3);
        tryGame2 = 2;
        video2.SetActive(false);
        textVideo2.text = "";
        trueAnimation2.SetActive(false);
        questions2.SetActive(true);
        finishgame2.SetActive(false);
        subtitleBK2.SetActive(true);

        //���� 3
        chatGame3.initChat();
        chatGame3.setChatTitle("��� ��������'");
        chatGame3.setProfilePhoto("ema");
        chatGame3.addVideo(Chat.Direction.RECEIVE, "emaVideoPhotos", playVideo3);
        chatGame3.addTextMessage(Chat.Direction.RECEIVE, "���� ������ ���� ����� ����� ������ ������ ��� ��� ����� ��", 3);
        tryGame3 = 2;
        video3.SetActive(false);
        textVideo3.text = "";
        trueAnimation3.SetActive(false);
        questions3.SetActive(true);
        finishgame3.SetActive(false);
        subtitleBK3.SetActive(true);

        //����� �� ������
        loadStoryBtn.disableStoryBtnAll();

        //������ �� ������ ���������� ���� ��������
        if (PlayerPrefs.GetInt("GameMax") != 0)
        {
            int MaxStage = PlayerPrefs.GetInt("GameMax");
            Debug.Log(MaxStage);
            loadStoryBtn.EnableStoryBtnsForLevel(MaxStage);        
        }

        continuebtn.disableBtn();
        FindObjectOfType<audioManger>().Play("stage1Sentence1");
        StartCoroutine(stage1Sentence1());

    }

    IEnumerator stage1Sentence1()
    {
        yield return new WaitForSeconds(0.02f);
        tamir.SetBool("isTalk", false);
        continuebtn.enableBtn();
    }

    public void startstage1Sentence2()
    {
        tamir.SetBool("isTalk", true);
        FindObjectOfType<audioManger>().Play("stage1Sentence2");
        StartCoroutine(stage1Sentence2());

    }

    IEnumerator stage1Sentence2()
    {
        yield return new WaitForSeconds(1);
        tamir.SetBool("isTalk", false);
    }

    public void startstage1Sentence3()
    {
        tamir.SetBool("isTalk", true);
        FindObjectOfType<audioManger>().Play("stage1Sentence3");
        StartCoroutine(stage1Sentence3());
    }

    IEnumerator stage1Sentence3()
    {
        yield return new WaitForSeconds(1);
        tamir.SetBool("isTalk", false);
    }


    public void playVideo1()
    {
        StopAllCoroutines();
        video1.SetActive(false);
        video1.SetActive(true);
        StartCoroutine(sentenceVideo1());
    }

    public void playVideo2()
    {
        StopAllCoroutines();
        video2.SetActive(false);
        video2.SetActive(true);
        StartCoroutine(sentenceVideo2());

    }

    public void playVideo3()
    {
        StopAllCoroutines();
        video3.SetActive(false);
        video3.SetActive(true);
        StartCoroutine(sentenceVideo3());

    }


    //-----> ����� �������

    IEnumerator sentenceVideo1()
    {
        tamarAnimator.SetBool("isTalk", false);
        FindObjectOfType<audioManger>().Play("tamarRecord");
        yield return new WaitForSeconds(0.5f);
        subtitleBK1.SetActive(true);
        textVideo1.text = "��� ����, ���� ���� ������ ��� ������ ������� ���� ���� �� ����� ����� �� ��� ���.";
        tamarAnimator.SetBool("isTalk", true);
        yield return new WaitForSeconds(7.5f);
        textVideo1.text = "������ ���� ������ ���� �� ��� ���� ���.";
        yield return new WaitForSeconds(3.3f);
        textVideo1.text = "��� ���� ���� ��� �����, �����, ������� ����� ��� ����� �� ���� ������ ����. ���� ���� ������ ����.";
        yield return new WaitForSeconds(8f);
        textVideo1.text = "��� ��� �� ���� ��� ���� ����.";
        yield return new WaitForSeconds(2.5f);
        textVideo1.text = "����� ����, ���� ��� ���� ���� ����� �� ����� ���� ���� ���� ����� �� ����� �� ���� ����� ���� ������ ��� �� ������� �� ������ ��� ��������.";
        yield return new WaitForSeconds(9.5f);
        textVideo1.text = "��� �� ����� �� �����.. ���� ������ ���.";
        yield return new WaitForSeconds(3f);
        tamarAnimator.SetBool("isTalk", false);
        textVideo1.text = "";
        subtitleBK1.SetActive(false);
        stopMusic("tamarRecord");
        yield return new WaitForSeconds(1f);
        video1.SetActive(false);
    }

    IEnumerator sentenceVideo2()
    {
        subtitleBK2.SetActive(true);
        orAnimator.SetBool("isTalk", true);
        FindObjectOfType<audioManger>().Play("orRecord");
        textVideo2.text = "��� ���, ���� 03:11 ����� ����� ������ �� ���� ����� ��� ������.";
        yield return new WaitForSeconds(5f);
        textVideo2.text = "����� ���� ��� ������ ����� �� ����� �����! ��� �� ���� ���� �� �����! ";
        yield return new WaitForSeconds(6f);
        textVideo2.text = "����� ������ ��� ������ ��� ��� ��� ���� �� ���� ����� �� ���� ����.";
        yield return new WaitForSeconds(6f);
        textVideo2.text = "��� ���� ����� ���� ���� ����.";
        yield return new WaitForSeconds(2.5f);
        textVideo2.text = "��� �� ���� �� ��� ���� ����! �� ����� �� �� ������ ��� ��� �� ���� ���� ��� �� ����, ��� ����� ���� �� ����� ����� ����� �� ���� �� ����.";
        yield return new WaitForSeconds(9f);
        orAnimator.SetBool("isTalk", false);
        textVideo2.text = "��� �� ���� �� ����� ���.";
        yield return new WaitForSeconds(2f);
        textVideo2.text = "";
        subtitleBK2.SetActive(false);
        stopMusic("orRecord");
        yield return new WaitForSeconds(1f);
        video2.SetActive(false);
    }

    IEnumerator sentenceVideo3()
    {
        FindObjectOfType<audioManger>().Play("emaRecord");
        subtitleBK3.SetActive(true);
        emaAnimator.SetBool("isTalk", true);
        textVideo3.text = "��� ����, ��� �� ����� �� ��� ��?";
        yield return new WaitForSeconds(5.5f);
        textVideo3.text = "��� ���� ������� �� ���� ����� ������� ������ �� 0028 �� ��� �������� ���� ���� �����?";
        yield return new WaitForSeconds(7.5f);
        textVideo3.text = "���� ������ ����� ����� ����� �� �������� ������� ���� ������ ����� ����� �������.";
        yield return new WaitForSeconds(7f);
        textVideo3.text = "������ ���� ����� ��������, ��� �� ����� ��� �� ���.";
        yield return new WaitForSeconds(5f);
        emaAnimator.SetBool("isTalk", false);
        textVideo3.text = "";
        subtitleBK3.SetActive(false);
        stopMusic("emaRecord");
        yield return new WaitForSeconds(1f);
        video3.SetActive(false);
    }


    //����� ���� �� �������

    public void startOverVideo1()
    {
        StopAllCoroutines();
        video1.SetActive(false);
        video1.SetActive(true);
        StartCoroutine(sentenceVideo1());
    }

    public void startOverVideo2()
    {
        StopAllCoroutines();
        video2.SetActive(false);
        video2.SetActive(true);
        StartCoroutine(sentenceVideo2());
    }

    public void startOverVideo3()
    {
        StopAllCoroutines();
        video3.SetActive(false);
        video3.SetActive(true);
        StartCoroutine(sentenceVideo3());
    }
    public void ClickSoundBtn(string sound)
    {
        FindObjectOfType<audioManger>().click(sound);
    }

    public void stopMusic(string musicName)
    {
        StopAllCoroutines();
        FindObjectOfType<audioManger>().StopPlaying(musicName);
    }


    //------------------------------------------------���� 1 �������

    public void Game1TrueAnswer()
    {
        isAnswerTrue = true;
        chatGame1.addTextMessage(Chat.Direction.SEND,"�� �� ������ ���� �� ���� ��� ����", 3);
        StartCoroutine(Game1feedbackforanswers());
    }

    public void Game1FalseAnswer1()
    {
        chatGame1.addTextMessage(Chat.Direction.SEND, "������ ��� �� ������ ��������� ���", 3);
        StartCoroutine(Game1feedbackforanswers());
    }

    public void Game1FalseAnswer2()
    {
        chatGame1.addTextMessage(Chat.Direction.SEND, "���� ��� �� ����� ��", 3);
        StartCoroutine(Game1feedbackforanswers());
    }

    public void Game1FalseAnswer3()
    {
        chatGame1.addTextMessage(Chat.Direction.SEND, "�� ����� ���� ������", 3);
        StartCoroutine(Game1feedbackforanswers());
    }

    IEnumerator Game1feedbackforanswers()
    {
        yield return new WaitForSeconds(1);
        if (isAnswerTrue)
        {
            FindObjectOfType<audioManger>().Play("receiveMessage");
            chatGame1.addTextMessage(Chat.Direction.RECEIVE, "����� ��� ����� ���� ����� �� ������ ��� ����.", 3);
            finishGame1.SetActive(true);
            trueAnimation1.SetActive(true);
            isAnswerTrue = false;
            finishGame1Open();
        }
        else
        {
            if (tryGame1 == 2)
            {
                FindObjectOfType<audioManger>().Play("receiveMessage");
                chatGame1.addTextMessage(Chat.Direction.RECEIVE, "��� �� ����� ��� ���� �����, ���� ����� ������� ����.", 3);
            }
            else if (tryGame1 == 1)
            {
                FindObjectOfType<audioManger>().Play("receiveMessage");
                chatGame1.addTextMessage(Chat.Direction.RECEIVE, "����� ����� ������ ����� ����� ����� �� ���� �����.", 3);
            }
            else
            {
                FindObjectOfType<audioManger>().Play("receiveMessage");
                chatGame1.addTextMessage(Chat.Direction.RECEIVE, "���� ������ �� ��, ����� ������ ������ ��� ��� ���� ����� ��� �� ���� !����� ������ ��� ������ �� ����� ������ ��� ���� �� ����� �����.", 7);
                finishGame1.SetActive(true);
                isAnswerTrue = false;
                finishGame1Open();
            }
            tryGame1Down();
        }
    }

    //------------------------------------------------���� 2 �������

    public void Game2TrueAnswer()
    {
        isAnswerTrue = true;
        chatGame2.addTextMessage(Chat.Direction.SEND, "��� ����� ������� ��� ���� �����", 3);
        StartCoroutine(Game2feedbackforanswers());
    }

    public void Game2FalseAnswer1()
    {
        chatGame2.addTextMessage(Chat.Direction.SEND, "���� ����� ����� ���� ����", 3);
        StartCoroutine(Game2feedbackforanswers());
    }

    public void Game2FalseAnswer2()
    {
        chatGame2.addTextMessage(Chat.Direction.SEND, "������ ��� ������� ����� ������", 3);
        StartCoroutine(Game2feedbackforanswers());
    }

    public void Game2FalseAnswer3()
    {
        chatGame2.addTextMessage(Chat.Direction.SEND, "����� ������ �� ���� ����", 3);
        StartCoroutine(Game2feedbackforanswers());
    }

    IEnumerator Game2feedbackforanswers()
    {
        yield return new WaitForSeconds(1);
        if (isAnswerTrue)
        {
            FindObjectOfType<audioManger>().Play("receiveMessage");
            chatGame2.addTextMessage(Chat.Direction.RECEIVE, "����, ����� ���� ���� ���� ���� ����� ��, ���� �� �����!", 3);
            finishGame2.SetActive(true);
            trueAnimation2.SetActive(true);
            isAnswerTrue = false;
            finishGame2Open();
        }
        else
        {
            if (tryGame2 == 2)
            {
                FindObjectOfType<audioManger>().Play("receiveMessage");
                chatGame2.addTextMessage(Chat.Direction.RECEIVE, "��� �� ���� ��� ���� �����, ���� ����� ������� ����.", 3);
            }
            else if (tryGame2 == 1)
            {
                FindObjectOfType<audioManger>().Play("receiveMessage");
                chatGame2.addTextMessage(Chat.Direction.RECEIVE, "����� ����� ������ ����� ����� ����� �� ���� �����.", 3);
            }
            else
            {
                FindObjectOfType<audioManger>().Play("receiveMessage");
                chatGame2.addTextMessage(Chat.Direction.RECEIVE, "����� ������ ��� ������ �� ����� ������, ��� ���� ����� ���� ���� ����. ��� ���� �� ����� �����.", 5);
                finishGame2.SetActive(true);
                isAnswerTrue = false;
                finishGame2Open();
            }
            tryGame2Down();
        }
    }

    //------------------------------------------------���� 3 �������

    public void Game3TrueAnswer()
    {
        isAnswerTrue = true;
        chatGame3.addTextMessage(Chat.Direction.SEND, "�� ���� ������� ����� ����� ������", 3);
        StartCoroutine(Game3feedbackforanswers());
    }

    public void Game3FalseAnswer1()
    {
        chatGame3.addTextMessage(Chat.Direction.SEND, "�� �� ����� ������ �� ������", 3);
        StartCoroutine(Game3feedbackforanswers());
    }

    public void Game3FalseAnswer2()
    {
        chatGame3.addTextMessage(Chat.Direction.SEND, "������� ��� ���� ����", 3);
        StartCoroutine(Game3feedbackforanswers());
    }

    public void Game3FalseAnswer3()
    {
        chatGame3.addTextMessage(Chat.Direction.SEND, "���� ������� �������", 3);
       StartCoroutine(Game3feedbackforanswers());
    }

    IEnumerator Game3feedbackforanswers()
    {
        yield return new WaitForSeconds(1);
        if (isAnswerTrue)
        {
            FindObjectOfType<audioManger>().Play("receiveMessage");
            chatGame3.addTextMessage(Chat.Direction.RECEIVE, "����, �� �� ����� ��� ��� ����� ����� �� ��! ���� �� �����!", 3);
            finishGame3.SetActive(true);
            trueAnimation3.SetActive(true);
            isAnswerTrue = false;
            finishGame3Open();
        }
        else
        {
            if (tryGame3 == 2)
            {
                FindObjectOfType<audioManger>().Play("receiveMessage");
                chatGame3.addTextMessage(Chat.Direction.RECEIVE, "��� �� ����� ��� ���� �����, ���� ����� ������� ����.", 3);
            }
            else if (tryGame3 == 1)
            {
                FindObjectOfType<audioManger>().Play("receiveMessage");
                chatGame3.addTextMessage(Chat.Direction.RECEIVE, "����� ����� ������ ����� ����� ����� �� ���� �����.", 3);
            }
            else
            {
                FindObjectOfType<audioManger>().Play("receiveMessage");
                chatGame3.addTextMessage(Chat.Direction.RECEIVE, "���� ������ �� ��, ����� ������ ������ ��� ��� ������ ����� ���� ����� ����� ������. ����� ������ ��� ������ �� ����� ������ ��� ���� �� ����� �����.", 7);
                finishGame3.SetActive(true);
                isAnswerTrue = false;
                finishGame3Open();

            }
            tryGame3Down();
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
        if (PlayerPrefs.GetInt("GameMax") < 1)
        {
            PlayerPrefs.SetInt("GameMax", 1);
        }
        int myMaxLevel = PlayerPrefs.GetInt("GameMax");
        loadStoryBtn.enableStoryBtn(myMaxLevel);


    }

    public void finishGame1Open()
    {
        questions1.SetActive(false);
        finishgame1.SetActive(true);
    }

    public void finishGame2Open()
    {
        questions2.SetActive(false);
        finishgame2.SetActive(true);
    }

    public void finishGame3Open()
    {
        questions3.SetActive(false);
        finishgame3.SetActive(true);
    }


}