using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class UIMangerstory : MonoBehaviour
{
    private storiesData storiesData;

    //������ ������ ������� �� ��������
    //public navigation prevPageBtn;
    //public navigation nextPageBtn;

    //����� ������ ����� �����
    public TextMeshProUGUI storytitleText;
    //����� ������ �����
    public TextMeshProUGUI storyText;
    //����� ������ ����� �� ����� ���� ���
    public TextMeshProUGUI NextLevelTXTbtn;
    //����� ������ �����
    public TextMeshProUGUI learningText;

    int MaxNumber;

    public navigation userBtn;
    public navigation placeBtn;
    public navigation chatBtn;

    void Start()
    {
        storiesData = transform.gameObject.GetComponent<storiesData>();
        MaxNumber = PlayerPrefs.GetInt("GameMax");
        Debug.Log("UIM MaxNumber - " + MaxNumber);
        Debug.Log("UIM gameNumIn - " + PlayerPrefs.GetInt("gameNumIn"));
        userBtn.disableBtn();
        placeBtn.disableBtn();
        chatBtn.disableBtn();
    }

    //����� �����
    //public void updateArrows()
    //{
    //    //���� ������ ������ ����� ����� �������� �����
    //    if (MaxNumber == storiesData.pageNumber)
    //    {
    //        prevPageBtn.enableBtn();
    //        nextPageBtn.disableBtn();
    //    }
    //    else
    //    {
    //        prevPageBtn.enableBtn();
    //        nextPageBtn.enableBtn();
    //    }

    //    //���� ������ ����� ����� ����� �� ���� ������

    //    if (storiesData.pageNumber == 1)
    //    {
    //        prevPageBtn.transform.gameObject.SetActive(false);
    //        nextPageBtn.transform.gameObject.SetActive(true);
    //    }
    //    else if (storiesData.pageNumber == 5)
    //    {
    //        prevPageBtn.transform.gameObject.SetActive(true);
    //        nextPageBtn.transform.gameObject.SetActive(false);

    //    }
    //    else
    //    {
    //        prevPageBtn.transform.gameObject.SetActive(true);
    //        nextPageBtn.transform.gameObject.SetActive(true);
    //    }
    //}

    public void NextPage()
    {
        //�� ���� ����� ��� ����� ����� ��� ���� ����� ���� ����� �0
        if (storiesData.pageNumber < 5 && storiesData.pageNumber >= 0)
        {
            //����� �� ���� ����� �-1
            storiesData.pageNumber++;

            //���� �� �������
            //updateArrows();
            updateUi();

        }
    }

    public void PrevPage()
    {
        //�� ���� ����� ���� ����� ����� ��� ���� ����� ���� ����� �0
        if (storiesData.pageNumber <= 5 && storiesData.pageNumber > 1)
        {
            //����� �� ���� ����� �-1
            storiesData.pageNumber--;

            //���� �� �������
            //updateArrows();
            updateUi();

        }
    }

    public void updateUi()
    {
        int numbertext = storiesData.pageNumber - 1;
        storyText.text = storiesData.Storytext[numbertext];
        storytitleText.text = storiesData.Storytitletext[numbertext];
        learningText.text = storiesData.learningText[numbertext];
        if (storiesData.pageNumber == 5)
        {
            NextLevelTXTbtn.text = "���� �����";
        }
        else
        {
            NextLevelTXTbtn.text = "���� ���";
        }
    }

    public void nextLevel()
    {
        if (storiesData.pageNumber != 5)
        {
            int numberofnextlevel = storiesData.pageNumber + 1;
            SceneManager.LoadScene("Game" + numberofnextlevel);
        }
        else
        {
            SceneManager.LoadScene("closeGame");
        }
    }

    public void stayInCurrentLevel()
    {
        int numberofcurrentlevel = storiesData.pageNumber;
        SceneManager.LoadScene("Game" + numberofcurrentlevel);
    }

}
