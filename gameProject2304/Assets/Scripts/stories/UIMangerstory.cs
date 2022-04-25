using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class UIMangerstory : MonoBehaviour
{
    private storiesData storiesData;

    //������ ������ ������� �� ��������
    public navigation prevPageBtn;
    public navigation nextPageBtn;

    //����� ������ �����
    public TextMeshProUGUI storyText;
    //����� ������ ����� �� ����� ���� ���
    public TextMeshProUGUI NextLevelTXTbtn;

    int MaxNumber;


    void Start()
    {
        storiesData = transform.gameObject.GetComponent<storiesData>();
        MaxNumber = PlayerPrefs.GetInt("openGameMax");
    }

    //����� �����
    public void updateArrows()
    {
        //���� ������ ������ ����� ����� �������� �����
        if (MaxNumber == storiesData.pageNumber)
        {
            prevPageBtn.enableBtn();
            nextPageBtn.disableBtn();
        }
        else
        {
            prevPageBtn.enableBtn();
            nextPageBtn.enableBtn();
        }

        //���� ������ ����� ����� ����� �� ���� ������

        if (storiesData.pageNumber == 1)
        {
            prevPageBtn.transform.gameObject.SetActive(false);
            nextPageBtn.transform.gameObject.SetActive(true);
        }
        else if (storiesData.pageNumber == 5)
        {
            prevPageBtn.transform.gameObject.SetActive(true);
            nextPageBtn.transform.gameObject.SetActive(false);

        }
        else
        {
            prevPageBtn.transform.gameObject.SetActive(true);
            nextPageBtn.transform.gameObject.SetActive(true);
        }
    }

    public void NextPage()
    {
        //�� ���� ����� ��� ����� ����� ��� ���� ����� ���� ����� �0
        if (storiesData.pageNumber < 5 && storiesData.pageNumber >= 0)
        {
            //����� �� ���� ����� �-1
            storiesData.pageNumber++;

            //���� �� �������
            updateArrows();
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
            updateArrows();
            updateUi();

        }
    }

    public void updateUi()
    {
        int numbertext = storiesData.pageNumber - 1;
        storyText.text = storiesData.Storytext[numbertext];
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
