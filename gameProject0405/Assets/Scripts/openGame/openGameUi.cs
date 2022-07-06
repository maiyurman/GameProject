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
        StartCoroutine(sentenceVideo1());
        tamir1.SetActive(true);
        tamirAnimator.SetBool("isTalk", true);
        tamir2.SetActive(false);
        Checkmusicbtns("tamirRecord");
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


    IEnumerator sentenceVideo1()
    {
        FindObjectOfType<audioMangerOpen>().Play("tamirRecord");
        storyPic.GetComponent<Image>().sprite = Resources.Load<Sprite>("openGame/opening1");
        //���� ������
        startTxt.text = "��� ����� �� ������? ������ ����� ���� ������� revloS, ���� ����� ��� �� ��� ����� �� ��� ���� �� ����.";
        yield return new WaitForSeconds(2.5f);
        startTxt.text = "��� ���� �� 71 ��� ����.";
        yield return new WaitForSeconds(3f);
        storyPic.GetComponent<Image>().sprite = Resources.Load<Sprite>("openGame/opening2");
        //���� ����� ���
        startTxt.text = "��� �� 001 ��� ������ ���������";
        yield return new WaitForSeconds(2f);
        startTxt.text = "��� ��� ������ ���?";
        yield return new WaitForSeconds(2f);
        storyPic.GetComponent<Image>().sprite = Resources.Load<Sprite>("openGame/opening3");
        //��� �� ���� ���
        startTxt.text = "��� ��� ��� ����� ���� ����� ����� ����� ����� �� ������ ����, ���� ������ ���� ������ ����� �����.";
        yield return new WaitForSeconds(8f);
        startTxt.text = "������ ����� �� ����� ��� ������ ����� ����� ����� ������� ���� ������ �����.";
        yield return new WaitForSeconds(8f);
        storyPic.GetComponent<Image>().sprite = Resources.Load<Sprite>("openGame/opening4");
        //���� �����
        startTxt.text = "����� ������ ������ ������ ����� ��� ����� ����� ��� ����� �� ���� ������ ��� ���� �����.";
        yield return new WaitForSeconds(8.8f);
        startTxt.text = "����, ����� ������ ����� ����� ������� �������� ��� ����� ���� �� ����� ���� ����� ��������� ��� ������ ��� ���.";
        yield return new WaitForSeconds(8.8f);
        startTxt.text = "��� ����� ���� ������ �� ����� ���� ���� ���� ���� ��� �� ���� ������ �����.";
        yield return new WaitForSeconds(8.8f);
        storyPic.GetComponent<Image>().sprite = Resources.Load<Sprite>("openGame/opening5");
        //���� ����
        startTxt.text = "������ ����� ���, ������ ������ ������ ������� ����� ����� ����� ��������.";
        yield return new WaitForSeconds(7f);
        startTxt.text = "������� �������� ������ ���� �� ����� ������ ������ �� ����� ��� ������� ����� ��������� �� ����� ������� �����.";
        yield return new WaitForSeconds(7f);
        tamir1.SetActive(false);
        tamir2.SetActive(true);
        storyPic.GetComponent<Image>().sprite = Resources.Load<Sprite>("openGame/opening6");
        //��� ��� ����
        startTxt.text = "���� ��� ��?";
        yield return new WaitForSeconds(8.3f);
        startTxt.text = "�������, ��� ���� ���� �������� ���� �� ��� ���� �� ������� ���� �-Solver. ��� ���� �� ����� ���� ��� �� ���� �� ������� ���.";
        yield return new WaitForSeconds(8.3f);
        startTxt.text = "�� ��� ����� ��, ��� ����� 5 ����� ��� ��� ��� ���� ��� ��� ������ ����� ������ - ����� ��� ����� ���� ��� ����.";
        yield return new WaitForSeconds(8.3f);
        startTxt.text = "���� �� ���, ��� ���� ��� ������ ����� �� ������� ��� ������ ��� ������ ��� ���� ����� ��� ������ �����.";
        yield return new WaitForSeconds(8.3f);
        startTxt.text = "��� ���� ��� ���� ����� �����, ��� ���� ������ ������ ����� �� ���� ������ �������� ���� �� ����.";
        yield return new WaitForSeconds(7f);
        startTxt.text = "��� �� �����, ��� �� ��� ��� ����� ����� �� ����!";
        yield return new WaitForSeconds(5f);
        startTxt.text = "������?";
        tamirAnimator.SetBool("isTalk", false);
        yield return new WaitForSeconds(1f);
        bubble.SetActive(true);
        startGameBtn.gameObject.SetActive(true);
        FindObjectOfType<audioMangerOpen>().StopPlaying("tamirRecord");
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

    //public void ClickSoundBtn()
    //{
    //    var currentVolume = tamirSound.volume;

    //    if (currentVolume == 1)
    //    {
    //        tamirSound.volume = 0;
    //        soundBtn.notMusic();
    //    }
    //    else
    //    {
    //        tamirSound.volume = 1;
    //        soundBtn.enableBtn();

    //    }
    //}

    public void startOverVideotamir()
    {
        StopAllCoroutines();
        FindObjectOfType<audioMangerOpen>().StopPlaying("tamirRecord");
        StartCoroutine(sentenceVideo1());
    }

}
