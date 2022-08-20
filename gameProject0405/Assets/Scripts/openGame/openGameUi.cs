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
    public string currentMusic;
    public navgationFor2 pauseBtn;
    public navigation startOverBtn;

    public static bool GameIsPaused;

    private audioMangerOpen audioMangerOpen;

   
    void Start()
    {
        audioMangerOpen = GameObject.Find("audioMangerOpen").GetComponent<audioMangerOpen>();

        bubble.SetActive(false);
        startGameBtn.gameObject.SetActive(false);
        PlayerPrefs.SetInt("gameNumIn", 0);
        PlayerPrefs.SetInt("GameMax", 0);
        sentenceVideo1();
        tamir1.SetActive(true);
        tamirAnimator.SetBool("isTalk", true);
        tamir2.SetActive(false);
        Checkmusicbtns("openSentence1");
        startOverBtn.gameObject.SetActive(false);
    }

    public void clickPauseBtn()
    {
        if (GameIsPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    void Resume()
    {
        Debug.Log("resume");
        pauseBtn.enableBtn();
        Time.timeScale = 1f;
        GameIsPaused = false;
        Debug.Log("Resume " + currentMusic);
        audioMangerOpen.NotPause(currentMusic);
    }

    void Pause()
    {
        Debug.Log("pasue");
        pauseBtn.notMusic();
        Time.timeScale = 0f;
        GameIsPaused = true;
        Debug.Log("Pause " + currentMusic);
        audioMangerOpen.Pause(currentMusic);
    }


    public void Checkmusicbtns(string musicName)
    {
        string musicOn = PlayerPrefs.GetString("isMusicOn");
        //�� ������� ������
        if(musicOn == "true")
        {
            FindObjectOfType<audioMangerOpen>().stayOn();
        }
        else
        {
            FindObjectOfType<audioMangerOpen>().stayOff();
        }
    }

    public void pressOpenGameBtn()
    {
        SceneManager.LoadScene("Game1");
    }


    public void sentenceVideo1()
    {
        startOverBtn.gameObject.SetActive(false);
        currentMusic = "openSentence1";
        FindObjectOfType<audioMangerOpen>().Play("openSentence1");
        FindObjectOfType<audioMangerOpen>().isPlaying("openSentence1");
        storyPic.GetComponent<Image>().sprite = Resources.Load<Sprite>("openGame/opening1");
        startTxt.text = "��� ����� �� ������? ������ ����� ���� ������� revloS," + "\n" + "���� ����� ��� �� ��� ����� �� ��� ���� �� ����.";
    }

    public void ClickSoundBtn(string sound)
    {
        FindObjectOfType<audioMangerOpen>().click(sound);
    }

    public void stopMusic(string musicName)
    {
        StopAllCoroutines();
        FindObjectOfType<audioMangerOpen>().StopPlaying(currentMusic);
    }

    public void startOverVideotamir()
    {
        if (currentMusic != "openSentence1")
        {
            StopAllCoroutines();
            FindObjectOfType<audioMangerOpen>().StopPlaying(currentMusic);
            currentMusic = "openSentence1";
            sentenceVideo1();
        }
    }

    public void sentence2tamir()
    {
        if (currentMusic == "openSentence1")
        {
            currentMusic = "openSentence2";
            startOverBtn.gameObject.SetActive(true);
            Checkmusicbtns(currentMusic);
            FindObjectOfType<audioMangerOpen>().Play("openSentence2");
            FindObjectOfType<audioMangerOpen>().isPlaying("openSentence2");
            startTxt.text = "��� ���� �� 71 ��� ����.";
        }
    }

    public void sentence3tamir()
    {
        if (currentMusic == "openSentence2")
        {
            currentMusic = "openSentence3";
            Checkmusicbtns(currentMusic);
            FindObjectOfType<audioMangerOpen>().Play("openSentence3");
            FindObjectOfType<audioMangerOpen>().isPlaying("openSentence3");
            startTxt.text = "�� �� 001 ��� ������ ���������";
            storyPic.GetComponent<Image>().sprite = Resources.Load<Sprite>("openGame/opening2");
        }
    }

    public void sentence4tamir()
    {
        if (currentMusic == "openSentence3")
        {
            currentMusic = "openSentence4";
            Checkmusicbtns(currentMusic);
            FindObjectOfType<audioMangerOpen>().Play("openSentence4");
            FindObjectOfType<audioMangerOpen>().isPlaying("openSentence4");
            startTxt.text = "��� ��� ������ ���?";
        }
    }

    public void sentence5tamir()
    {
        if (currentMusic == "openSentence4")
        {
            currentMusic = "openSentence5";
            Checkmusicbtns(currentMusic);
            FindObjectOfType<audioMangerOpen>().Play("openSentence5");
            FindObjectOfType<audioMangerOpen>().isPlaying("openSentence5");
            startTxt.text = "��� ��� ��� ����� ���� ����� ����� ����� ����� �� ������ ����," + "\n" + " ���� ������ ���� ������ ����� �����.";
            storyPic.GetComponent<Image>().sprite = Resources.Load<Sprite>("openGame/opening3");
        }
    }

    public void sentence6tamir()
    {
        if (currentMusic == "openSentence5")
        {
            currentMusic = "openSentence6";
            Checkmusicbtns(currentMusic);
            FindObjectOfType<audioMangerOpen>().Play("openSentence6");
            FindObjectOfType<audioMangerOpen>().isPlaying("openSentence6");
            startTxt.text = "������ ����� �� ����� ��� ������ ����� ����� ����� ������� ���� ������ �����.";
        }
    }

    public void sentence7tamir()
    {
        if (currentMusic == "openSentence6")
        {
            currentMusic = "openSentence7";
            Checkmusicbtns(currentMusic);
            FindObjectOfType<audioMangerOpen>().Play("openSentence7");
            FindObjectOfType<audioMangerOpen>().isPlaying("openSentence7");
            startTxt.text = "����� ������ ������ ������ ����� ��� ����� �����" + "\n" + "��� ����� �� ���� ������ ��� ���� �����.";
            storyPic.GetComponent<Image>().sprite = Resources.Load<Sprite>("openGame/opening4");
        }
    }
    public void sentence8tamir()
    {
        if (currentMusic == "openSentence7")
        {
            currentMusic = "openSentence8";
            Checkmusicbtns(currentMusic);
            FindObjectOfType<audioMangerOpen>().Play("openSentence8");
            FindObjectOfType<audioMangerOpen>().isPlaying("openSentence8");
            startTxt.text = "����, ����� ������ ����� ����� ������� ��������" + "\n" + "��� ����� ���� �� ����� ���� ����� ��������� ��� ������� ��� ���.";
        }
    }

    public void sentence9tamir()
    {
        if (currentMusic == "openSentence8")
        {
            currentMusic = "openSentence9";
            Checkmusicbtns(currentMusic);
            FindObjectOfType<audioMangerOpen>().Play("openSentence9");
            FindObjectOfType<audioMangerOpen>().isPlaying("openSentence9");
            startTxt.text = "��� ����� ���� ������ �� ����� ���� ���� ���� ���� ��� �� ���� ������ �����.";
        }
    }


    public void sentence10tamir()
    {
        if (currentMusic == "openSentence9")
        {
            currentMusic = "openSentence10";
            Checkmusicbtns(currentMusic);
            FindObjectOfType<audioMangerOpen>().Play("openSentence10");
            FindObjectOfType<audioMangerOpen>().isPlaying("openSentence10");
            startTxt.text = "������ ����� ���, ������ ������ ������ ������� ����� ����� ����� ��������.";
            storyPic.GetComponent<Image>().sprite = Resources.Load<Sprite>("openGame/opening5");
        }
    }


    public void sentence11tamir()
    {
        if (currentMusic == "openSentence10")
        {
            currentMusic = "openSentence11";
            Checkmusicbtns(currentMusic);
            FindObjectOfType<audioMangerOpen>().Play("openSentence11");
            FindObjectOfType<audioMangerOpen>().isPlaying("openSentence11");
            startTxt.text = "������� �������� ������ ���� �� ����� ������ ������ �� ����� ���" + "\n" + "������� ����� ��������� �� ����� ������� �����.";
        }
    }


    public void sentence12tamir()
    {
        if (currentMusic == "openSentence11")
        {
            currentMusic = "openSentence12";
            Checkmusicbtns(currentMusic);
            tamir1.SetActive(false);
            tamir2.SetActive(true);
            FindObjectOfType<audioMangerOpen>().Play("openSentence12");
            FindObjectOfType<audioMangerOpen>().isPlaying("openSentence12");
            startTxt.text = "���� ��� ��?";
            storyPic.GetComponent<Image>().sprite = Resources.Load<Sprite>("openGame/opening6");
        }
    }


    public void sentence13tamir()
    {
        if (currentMusic == "openSentence12")
        {
            currentMusic = "openSentence13";
            Checkmusicbtns(currentMusic);
            FindObjectOfType<audioMangerOpen>().Play("openSentence13");
            FindObjectOfType<audioMangerOpen>().isPlaying("openSentence13");
            startTxt.text = "�������, ��� ���� ���� �������� ���� �� ��� ���� �� ������� ���� �-revloS." + "\n" + "��� ���� �� ����� ���� ��� �� ���� �� ������� ���.";
        }
    }


    public void sentence14tamir()
    {
        if (currentMusic == "openSentence13")
        {
            currentMusic = "openSentence14";
            Checkmusicbtns(currentMusic);
            FindObjectOfType<audioMangerOpen>().Play("openSentence14");
            FindObjectOfType<audioMangerOpen>().isPlaying("openSentence14");
            startTxt.text = "�� ��� ����� ��, ��� ����� 5 ����� ��� ��� ��� ���� ��� ���" + "\n" + "������ ����� ������ - ����� ��� ����� ���� ��� ����.";
        }
    }


    public void sentence15tamir()
    {
        if (currentMusic == "openSentence14")
        {
            currentMusic = "openSentence15";
            Checkmusicbtns(currentMusic);
            FindObjectOfType<audioMangerOpen>().Play("openSentence15");
            FindObjectOfType<audioMangerOpen>().isPlaying("openSentence15");
            startTxt.text = "���� �� ���, ��� ���� ��� ������ ����� �� ������� ��� " + "\n" + " ������ ��� ������ ��� ���� ����� ��� ������ �����.";
        }
    }


    public void sentence16tamir()
    {
        if (currentMusic == "openSentence15")
        {
            currentMusic = "openSentence16";
            Checkmusicbtns(currentMusic);
            FindObjectOfType<audioMangerOpen>().Play("openSentence16");
            FindObjectOfType<audioMangerOpen>().isPlaying("openSentence16");
            startTxt.text = "��� ���� ��� ���� ����� �����, ��� ���� ������" + "\n" + "������ ����� �� ���� ������ �������� ���� �� ����.";
        }
    }


    public void sentence17tamir()
    {
        if (currentMusic == "openSentence16")
        {
            currentMusic = "openSentence17";
            Checkmusicbtns(currentMusic);
            FindObjectOfType<audioMangerOpen>().Play("openSentence17");
            FindObjectOfType<audioMangerOpen>().isPlaying("openSentence17");
            startTxt.text = "��� �� �����, ��� �� ��� ��� ����� ����� �� ����!";
        }
    }


    public void sentence18tamir()
    {
        if (currentMusic == "openSentence17")
        {
            currentMusic = "openSentence18";
            Checkmusicbtns(currentMusic);
            FindObjectOfType<audioMangerOpen>().Play("openSentence18");
            FindObjectOfType<audioMangerOpen>().isPlaying("openSentence18");
            startTxt.text = "������?";
        }
    }

    public void finishTalk()
    {
        if (currentMusic == "openSentence18")
        {
            tamirAnimator.SetBool("isTalk", false);
            bubble.SetActive(true);
            startGameBtn.gameObject.SetActive(true);
        }
    }


}
