using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Audio;
using UnityEngine.UI;

public class openGameUi : MonoBehaviour
{
    public TextMeshProUGUI startTxt;
    public Image storyPic;
    public navigation startGameBtn;
    public GameObject bubble;
    public GameObject tamir1;
    public GameObject tamir2;
    public Animator tamirAnimator;
    public navgationFor2 soundBtn;


    void Start()
    {
        bubble.SetActive(false);
        startGameBtn.gameObject.SetActive(false);
        PlayerPrefs.SetInt("gameNumIn", 0);
        PlayerPrefs.SetInt("GameMax", 0);
        sentenceVideo1();
        tamir1.SetActive(true);
        tamirAnimator.SetBool("isTalk", true);
        tamir2.SetActive(false);
        //Checkmusicbtns("tamirRecord");
    }

    public void Checkmusicbtns(string musicBtnName)
    {
        string musicOn = PlayerPrefs.GetString("isMusicOn");
        Debug.Log("����� ������" + musicOn);
        //�� ������� ������
        if(musicOn == "true")
        {
            Debug.Log("�� �������" + musicBtnName);
            FindObjectOfType<audioMangerOpen>().stayOn(musicBtnName);
        }
        else
        {
            FindObjectOfType<audioMangerOpen>().stayOff(musicBtnName);
        }
    }

    public void pressOpenGameBtn()
    {
        SceneManager.LoadScene("Game1");
    }


    public void sentenceVideo1()
    {
        FindObjectOfType<audioMangerOpen>().Play("openSentence1");
        FindObjectOfType<audioMangerOpen>().isPlaying("openSentence1");
        storyPic.GetComponent<Image>().sprite = Resources.Load<Sprite>("openGame/opening1");

    }

    public void ClickSoundBtn(string sound)
    {
        FindObjectOfType<audioMangerOpen>().click(sound);
    }

    public void stopMusic(string musicName)
    {
        StopAllCoroutines();
        FindObjectOfType<audioMangerOpen>().StopPlaying(musicName);
    }

    public void startOverVideotamir()
    {
        StopAllCoroutines();
        FindObjectOfType<audioMangerOpen>().StopPlaying("tamirRecord");
        sentenceVideo1();
    }

    public void sentence2tamir()
    {
        Debug.Log("����� ����� 2");
        FindObjectOfType<audioMangerOpen>().Play("openSentence2");
        FindObjectOfType<audioMangerOpen>().isPlaying("openSentence2");
        startTxt.text = "��� ���� �� 71 ��� ����.";
    }

    public void sentence3tamir()
    {
        FindObjectOfType<audioMangerOpen>().Play("openSentence3");
        FindObjectOfType<audioMangerOpen>().isPlaying("openSentence3");
        startTxt.text = "�� �� 001 ��� ������ ���������";
        storyPic.GetComponent<Image>().sprite = Resources.Load<Sprite>("openGame/opening2");

    }

    public void sentence4tamir()
    {
        FindObjectOfType<audioMangerOpen>().Play("openSentence4");
        FindObjectOfType<audioMangerOpen>().isPlaying("openSentence4");
        startTxt.text = "��� ��� ������ ���?";

    }

    public void sentence5tamir()
    {
        FindObjectOfType<audioMangerOpen>().Play("openSentence5");
        FindObjectOfType<audioMangerOpen>().isPlaying("openSentence5");
        startTxt.text = "��� ��� ��� ����� ���� ����� ����� ����� ����� �� ������ ����, ���� ������ ���� ������ ����� �����.";
        storyPic.GetComponent<Image>().sprite = Resources.Load<Sprite>("openGame/opening3");

    }

    public void sentence6tamir()
    {
        FindObjectOfType<audioMangerOpen>().Play("openSentence6");
        FindObjectOfType<audioMangerOpen>().isPlaying("openSentence6");
        startTxt.text = "������ ����� �� ����� ��� ������ ����� ����� ����� ������� ���� ������ �����.";

    }

    public void sentence7tamir()
    {
        FindObjectOfType<audioMangerOpen>().Play("openSentence7");
        FindObjectOfType<audioMangerOpen>().isPlaying("openSentence7");
        startTxt.text = "����� ������ ������ ������ ����� ��� ����� ����� ��� ����� �� ���� ������ ��� ���� �����.";
        storyPic.GetComponent<Image>().sprite = Resources.Load<Sprite>("openGame/opening4");

    }
    public void sentence8tamir()
    {
        FindObjectOfType<audioMangerOpen>().Play("openSentence8");
        FindObjectOfType<audioMangerOpen>().isPlaying("openSentence8");
        startTxt.text = "����, ����� ������ ����� ����� ������� �������� ��� ����� ���� �� ����� ���� ����� ��������� ��� ������� ��� ���.";

    }

    public void sentence9tamir()
    {
        FindObjectOfType<audioMangerOpen>().Play("openSentence9");
        FindObjectOfType<audioMangerOpen>().isPlaying("openSentence9");
        startTxt.text = "��� ����� ���� ������ �� ����� ���� ���� ���� ���� ��� �� ���� ������ �����.";

    }


    public void sentence10tamir()
    {
        FindObjectOfType<audioMangerOpen>().Play("openSentence10");
        FindObjectOfType<audioMangerOpen>().isPlaying("openSentence10");
        startTxt.text = "������ ����� ���, ������ ������ ������ ������� ����� ����� ����� ��������.";
        storyPic.GetComponent<Image>().sprite = Resources.Load<Sprite>("openGame/opening5");

    }


    public void sentence11tamir()
    {
        FindObjectOfType<audioMangerOpen>().Play("openSentence11");
        FindObjectOfType<audioMangerOpen>().isPlaying("openSentence11");
        startTxt.text = "������� �������� ������ ���� �� ����� ������ ������ �� ����� ��� ������� ����� ��������� �� ����� ������� �����.";

    }


    public void sentence12tamir()
    {
        tamir1.SetActive(false);
        tamir2.SetActive(true);
        FindObjectOfType<audioMangerOpen>().Play("openSentence12");
        FindObjectOfType<audioMangerOpen>().isPlaying("openSentence12");
        startTxt.text = "���� ��� ��?";
        storyPic.GetComponent<Image>().sprite = Resources.Load<Sprite>("openGame/opening6");

    }


    public void sentence13tamir()
    {
        FindObjectOfType<audioMangerOpen>().Play("openSentence13");
        FindObjectOfType<audioMangerOpen>().isPlaying("openSentence13");
        startTxt.text = "�������, ��� ���� ���� �������� ���� �� ��� ���� �� ������� ���� �-Solver. ��� ���� �� ����� ���� ��� �� ���� �� ������� ���.";

    }


    public void sentence14tamir()
    {
        FindObjectOfType<audioMangerOpen>().Play("openSentence14");
        FindObjectOfType<audioMangerOpen>().isPlaying("openSentence14");
        startTxt.text = "�� ��� ����� ��, ��� ����� 5 ����� ��� ��� ��� ���� ��� ��� ������ ����� ������ - ����� ��� ����� ���� ��� ����.";

    }


    public void sentence15tamir()
    {
        FindObjectOfType<audioMangerOpen>().Play("openSentence15");
        FindObjectOfType<audioMangerOpen>().isPlaying("openSentence15");
        startTxt.text = "���� �� ���, ��� ���� ��� ������ ����� �� ������� ��� ������ ��� ������ ��� ���� ����� ��� ������ �����.";
 
    }


    public void sentence16tamir()
    {
        FindObjectOfType<audioMangerOpen>().Play("openSentence16");
        FindObjectOfType<audioMangerOpen>().isPlaying("openSentence16");
        startTxt.text = "��� ���� ��� ���� ����� �����, ��� ���� ������ ������ ����� �� ���� ������ �������� ���� �� ����.";
  
    }


    public void sentence17tamir()
    {
        FindObjectOfType<audioMangerOpen>().Play("openSentence17");
        FindObjectOfType<audioMangerOpen>().isPlaying("openSentence17");
        startTxt.text = "��� �� �����, ��� �� ��� ��� ����� ����� �� ����!";
 
    }


    public void sentence18tamir()
    {
        FindObjectOfType<audioMangerOpen>().Play("openSentence18");
        FindObjectOfType<audioMangerOpen>().isPlaying("openSentence18");
        startTxt.text = "������?";
    }

    public void finishTalk()
    {
        tamirAnimator.SetBool("isTalk", false);
        bubble.SetActive(true);
        startGameBtn.gameObject.SetActive(true);
    }

}
