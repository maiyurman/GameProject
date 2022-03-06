using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using TMPro;

public class Game2UiManager : MonoBehaviour
{
    private Game3Data gameData;

    //������ ������ ������� �� ��������
    public GameObject prevPageBtn;
    public GameObject nextPageBtn;

    //------------------------> ����� ���� �������

    public navigation InfluencerBtn;
    public GameObject windowInfo;

    public navigation intoBtn;
    public navigation helpBtn;

    public TextMeshProUGUI infoTXt;
    public TextMeshProUGUI helpTxt;

    public int helpPress;

    //------> ����� �����
    public navigation messageBtn;
    public navigation musicBtn;
    public navigation userBtn;
    public navigation placeBtn;

    //------> ����� �����
    public navigation[] storyBtns;

    //------>���� �����
    public GameObject feedbackWindow;
    public TextMeshProUGUI feedbackTxt;

    //------>���� ������ �� ������
    public GameObject influenceInstractionWindow;
    public TextMeshProUGUI influenceInstractionTxt;

    public void Start()
    {
        gameData = transform.gameObject.GetComponent<Game3Data>();

        //����� ������ ����������� - ������ �� ����� ���� �����
        windowInfo.SetActive(false);
        //����� ���� ������� �� ����� ����
        helpPress = 0;
        //���� �� ����� ���� ����
        userBtn.enableBtn();
        //���� �� ����� ������� ����
        InfluencerBtn.enableBtn();
        intoBtn.enableBtn();
        helpBtn.enableBtn();
        //���� �����
        feedbackWindow.SetActive(false);

    }

    public void UpdateUi(int NumOfPage)
    {
        updateArrows(NumOfPage);
        updateInfluencerFeed(NumOfPage);
        presentInfoWindow();

        if (NumOfPage != 0)
        {

        }
        else
        {
        }
        
    }

    public void NextPage()
    {
        //�� ���� ����� ��� ����� ����� ��� ���� ����� ���� ����� �0
        if (gameData.pageNumber < gameData.influencers.Length && gameData.pageNumber >= 0)
        {
            //����� �� ���� ����� �-1
            gameData.pageNumber++;
            //���� �� �������
            UpdateUi(gameData.pageNumber);
        }
    }
    public void PrevPage()
    {
        //�� ���� ����� ���� ����� ����� ��� ���� ����� ���� ����� �0
        if (gameData.pageNumber < gameData.influencers.Length && gameData.pageNumber > 0)
        {
            //����� �� ���� ����� �-1
            gameData.pageNumber--;
            //���� �� �������
            UpdateUi(gameData.pageNumber);
        }
    }


    //����� �����
    private void updateArrows(int NumOfPage)
    {
        if (gameData.influencers.Length <= 1)
        {
            prevPageBtn.SetActive(false);
            nextPageBtn.SetActive(false);
        }
        else if (NumOfPage == 0)
        {
            prevPageBtn.SetActive(false);
            nextPageBtn.SetActive(true);
        }
        else if (NumOfPage == gameData.influencers.Length - 1)
        {
            prevPageBtn.SetActive(true);
            nextPageBtn.SetActive(false);
        }
        else
        {
            prevPageBtn.SetActive(true);
            nextPageBtn.SetActive(true);
        }
    }

    //����� �� ��������
    private void updateInfluencerFeed(int NumOfPage)
    {
        Influencer currentInfluencer = gameData.getCurrentInfluencer() ;

        //����� ������� �� ����
       
        
    }

    //����� ������ ��������
    public void updateDropAreasImages()
    {
        for (int i = 0; i < gameData.dropAreas.Count; i++)
        {
            Influencer currentInfluencer = gameData.getCurrentInfluencer();
            gameData.dropAreas[i].setImage(currentInfluencer.photos[i]);
            gameData.influenceDate[i].text = currentInfluencer.dates[i];
        }
    }

    //���� ���� ����������  
    public void infoWindow()
    {
        windowInfo.SetActive(true);
        intoBtn.transform.gameObject.SetActive(true);
        //�� ���� ������ ���� �� ���� ����� ���� �0 �� ����� �� ����� ����
        presentInfoWindow();
        InfluencerBtn.disableBtn();

    }

    //����� ���� ����������
    public void closeinfoWindow()
    {
        helpTxt.text = "";
        infoTXt.text = "";
        windowInfo.SetActive(false);
        InfluencerBtn.enableBtn();

    }

    //����� ���� ����������
    public void infoText()
    {
        infoTXt.text = "!����� ������ ��������� �� �������� ������ �� ����� ������ ��������� ����� ���� ����� ��� ����";
        helpTxt.text = "";
        intoBtn.transform.gameObject.SetActive(false);
        helpBtn.transform.gameObject.SetActive(false);

    }

    //������ �� ����� ����
    public void helpText()
    {
        infoTXt.text = "";
        intoBtn.transform.gameObject.SetActive(false);
        helpBtn.transform.gameObject.SetActive(false);
        //����� ��� ������ �� ����� ������� ����
        if (helpPress == 0)
        {
            helpTxt.text = "��� ����� ���, ������ ����� ����� �������� ��� ����� ��������.";
            helpPress++;
        }
        else
        {
            helpTxt.text = "������ ����� ����� ������. ������ �� ���� ����� ���������.";
            helpPress++;
        }
    }

    //���� ���������� ���� �������
    public void presentInfoWindow() { 
        if (gameData.pageNumber > 0)
        {
            helpBtn.transform.gameObject.SetActive(false);
        }
        else
        {
            helpBtn.transform.gameObject.SetActive(true);
        }

        if (helpPress == 2)
        {
            //����� ���� �� ����
            helpBtn.disableBtn();
        }
    }

    //����� ������ �����
    public void EnableStoryBtnsForLevel(int numOfLevel)
    {
        for(int i=1;i < numOfLevel; i++)
        {
            enableStoryBtn(i);
        }
    }

    //����� ����� �����
    public void enableStoryBtn(int buttonNum)
    {
        storyBtns[buttonNum - 1].enableBtn();        
    }


    //����� ������
    public string Reverse(int number)
    {
        string text = number.ToString();
        char[] cArray = text.ToCharArray();
        string reverse = String.Empty;
        for (int i = cArray.Length - 1; i > -1; i--)
        {
            reverse += cArray[i];
        }
        return reverse;
    }


    public void showFeedback(string message)
    {
        feedbackTxt.text = message;
        feedbackWindow.SetActive(true);
    }

    public void influenceInstraction(string message)
    {
        influenceInstractionTxt.text = message;
        influenceInstractionWindow.SetActive(true);
    }

    //5 ����� ���� ����� �����
    public IEnumerator displayFinishGame(int secs, int numbersec)
    {   
        yield return new WaitForSeconds(secs);
        feedbackWindow.SetActive(false);

        //��� ������ ������
        int numbergro = 700;
        int finalenumber = 800;
        for (int i =numbergro; i<= finalenumber; i++)
        {
            yield return new WaitForSeconds(numbersec / 100);
        }

        yield return new WaitForSeconds(secs/2);
        //����� ����� �����
        enableStoryBtn(3);
        influenceInstraction("������ ����� ���� ������ ����� �������� ���� �� ���� �������! ���� �� ������ ��� ����� ��� ���� ������");
    }


}
