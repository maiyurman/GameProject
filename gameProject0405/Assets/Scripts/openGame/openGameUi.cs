using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;


public class openGameUi : MonoBehaviour
{
    public GameObject menu;
    public GameObject opening;
    public GameObject about;
    public TextMeshProUGUI startTxt;
    public Image storyPic;

    void Start()
    {
        menu.SetActive(true);
        opening.SetActive(false);
        about.SetActive(false);
    }

    public void openGameBtn()
    {
        StartCoroutine(sentenceVideo1());
    }

    public void pressOpenGameBtn()
    {
        PlayerPrefs.SetInt("gameNumIn", 0);
        PlayerPrefs.SetInt("GameMax", 0);
        SceneManager.LoadScene("Game1");
    }


    IEnumerator sentenceVideo1()
    {
        storyPic.GetComponent<Image>().sprite = Resources.Load<Sprite>("openGame/opening1");
        startTxt.text = "��� �����, ��� ������!";
        yield return new WaitForSeconds(4);
        storyPic.GetComponent<Image>().sprite = Resources.Load<Sprite>("openGame/opening2");
        startTxt.text = "��� ���� �� 17 ��� ����. ��� ���� ������ ������. �� �� 100,000 ������ ���������.";
        yield return new WaitForSeconds(4);
        storyPic.GetComponent<Image>().sprite = Resources.Load<Sprite>("openGame/opening3");
        startTxt.text = "��� ��� ������ ���??";
        yield return new WaitForSeconds(4);
        storyPic.GetComponent<Image>().sprite = Resources.Load<Sprite>("openGame/opening4");
        startTxt.text = "��� ��� ��� ����� ���� ����� ����� ����� ����� �� ������ ����, ���� ������ ���� ������ ����� �����.";
        yield return new WaitForSeconds(4);
        storyPic.GetComponent<Image>().sprite = Resources.Load<Sprite>("openGame/opening5");
        startTxt.text = "������ ����� �� ����� ��� ������� ���� ������ ����� �� ��� ����� ���� ������ �� ����� ���� ���� ���� ���� ��� �� ���� �����.";
        yield return new WaitForSeconds(4);
        storyPic.GetComponent<Image>().sprite = Resources.Load<Sprite>("openGame/opening6");
        startTxt.text = "������ ������ ������ �����, ������� �������� ������ ���� �� ����� ������ ������ �� ����� ��� ������ ������� ����.";
        yield return new WaitForSeconds(4);
        storyPic.GetComponent<Image>().sprite = Resources.Load<Sprite>("openGame/opening7");
        startTxt.text = "���� �� �� �� �������� ����� ��� ��� ����� ������ ������ ����� ������ ����� ����, ������� ������ ����� ����� ����� ���� ����.";
        yield return new WaitForSeconds(4);
        storyPic.GetComponent<Image>().sprite = Resources.Load<Sprite>("openGame/opening8");
        startTxt.text = "���� ��� ��?";
        yield return new WaitForSeconds(4);
        storyPic.GetComponent<Image>().sprite = Resources.Load<Sprite>("openGame/opening9");
        startTxt.text = "�������, ��� ���� ���� �������� ���� �� ��� ���� �� ������ ��� . ��� ���� �� ����� ���� ��� �� ���� �� ������� ������ ���.";
        yield return new WaitForSeconds(4);
        storyPic.GetComponent<Image>().sprite = Resources.Load<Sprite>("openGame/opening10");
        startTxt.text = "��� ���� ��� ���� ����� �����, ��� ���� ������ ������ ����� �� ���� ������ �������� ���� �� ����.";
        yield return new WaitForSeconds(4);
        storyPic.GetComponent<Image>().sprite = Resources.Load<Sprite>("openGame/opening11");
        startTxt.text = "�� �����, ��� �� ��� ��� ����� ����� �� ����.";
        yield return new WaitForSeconds(4);
        storyPic.GetComponent<Image>().sprite = Resources.Load<Sprite>("openGame/opening12");
        startTxt.text = "������?";
        yield return new WaitForSeconds(4);
        startTxt.text = "";
    }
}
