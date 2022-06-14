using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
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


    void Start()
    {
        bubble.SetActive(false);
        startGameBtn.gameObject.SetActive(false);
        PlayerPrefs.SetInt("gameNumIn", 0);
        PlayerPrefs.SetInt("GameMax", 0);
        StartCoroutine(sentenceVideo1());
        tamir1.SetActive(true);
        tamir2.SetActive(true);
        tamirAnimator.SetBool("isTalk", true);
        tamir2.SetActive(false);
    }

    public void pressOpenGameBtn()
    {
        SceneManager.LoadScene("Game1");
    }


    IEnumerator sentenceVideo1()
    {
        Debug.Log("������ ��������");
        storyPic.GetComponent<Image>().sprite = Resources.Load<Sprite>("openGame/opening1");
        //���� ������
        startTxt.text = "��� �����, ��� ������!";
        yield return new WaitForSeconds(4);
        startTxt.text = "��� ���� �� 17 ��� ����. ��� ���� ������ ������.";
        yield return new WaitForSeconds(4);
        storyPic.GetComponent<Image>().sprite = Resources.Load<Sprite>("openGame/opening2");
        //���� ����� ���
        startTxt.text = "�� �� 001 ��� ������ ���������";
        yield return new WaitForSeconds(4);
        startTxt.text = "��� ��� ������ ���?";
        yield return new WaitForSeconds(4);
        storyPic.GetComponent<Image>().sprite = Resources.Load<Sprite>("openGame/opening3");
        //��� �� ���� ���
        startTxt.text = "��� ��� ��� ����� ���� ����� ����� ����� ����� �� ������ ����, ���� ������ ���� ������ ����� �����.";
        yield return new WaitForSeconds(4);
        storyPic.GetComponent<Image>().sprite = Resources.Load<Sprite>("openGame/opening4");
        //���� �����
        startTxt.text = "������ ����� �� ����� ��� ������� ���� ������ ����� �� ��� ����� ���� ������ �� ����� ���� ���� ���� ���� ��� �� ���� �����.";
        yield return new WaitForSeconds(4);
        storyPic.GetComponent<Image>().sprite = Resources.Load<Sprite>("openGame/opening5");
        //���� ����
        startTxt.text = "������ ������ ������ �����, ������� �������� ������ ���� �� ����� ������ ������ �� ����� ��� ������ ������� ����.";
        yield return new WaitForSeconds(4);
        startTxt.text = "���� �� �� �� �������� ����� ��� ��� ����� ������ ������ ����� ������ ����� ����, ������� ������ ����� ����� ����� ���� ����.";
        yield return new WaitForSeconds(4);
        tamir1.SetActive(false);
        tamir2.SetActive(true);
        storyPic.GetComponent<Image>().sprite = Resources.Load<Sprite>("openGame/opening6");
        //��� ��� ����
        startTxt.text = "���� ��� ��?";
        yield return new WaitForSeconds(4);
        startTxt.text = "�������, ��� ���� ���� �������� ���� �� ��� ���� �� ������ ��� . ��� ���� �� ����� ���� ��� �� ���� �� ������� ������ ���.";
        yield return new WaitForSeconds(4);
        startTxt.text = "��� ���� ��� ���� ����� �����, ��� ���� ������ ������ ����� �� ���� ������ �������� ���� �� ����.";
        yield return new WaitForSeconds(4);
        startTxt.text = "�� �����, ��� �� ��� ��� ����� ����� �� ����.";
        yield return new WaitForSeconds(4);
        startTxt.text = "������?";
        bubble.SetActive(true);
        startGameBtn.gameObject.SetActive(true);
        tamirAnimator.SetBool("isTalk", false);
    }
}
