using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using TMPro;

public class Game3UiManager : MonoBehaviour
{
    private Game3Data gameData;
    private Game3Logic Game3Logic;

    //������ ������ ������ �� �������
    public TextMeshProUGUI influencerName;
    public TextMeshProUGUI postNumber;
    public TextMeshProUGUI followNumber;
    public TextMeshProUGUI followingNumber;
    public Image inflencePic;

    //������ ������ ������� �� ��������
    public GameObject prevPageBtn;
    public GameObject nextPageBtn;


    //-----------------------> ���� ������

    //����� + ���� �������
    public GameObject imagesLibrary;
    public navigation StockImagesBtn;

    //���� �������
    public GameObject imagesLibraryview;

    //���� ��� ����� �� ���� �������
    bool ShowstockImages;

    public GameObject deletePic1;
    public GameObject deletePic2;


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
    public navigation userBtn;
    public navigation placeBtn;

    //------>���� �����
    public GameObject feedbackWindow;
    public TextMeshProUGUI feedbackTxt;

    //------>���� ���� ����
    public GameObject finishGameBk;

    //------>������� ���� 
    public Animator tamirAnimator;

    public GameObject animationFinish;

    public void Start()
    {
        gameData = transform.gameObject.GetComponent<Game3Data>();
        Game3Logic = transform.gameObject.GetComponent<Game3Logic>();

        //����� ���� ���� ����
        finishGameBk.SetActive(false);
        //����� ���� ������� - ������ �� ����� ���� �����
        imagesLibraryview.SetActive(false);
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
        //����� �������� ��� ���������
        messageBtn.disableBtn();
        placeBtn.disableBtn();
        //���� �����
        feedbackWindow.SetActive(false);
        StockImages();

        animationFinish.SetActive(false);
    }

    public void stopTamirTalk(){
    StartCoroutine(stopTamirStartTalk());

    }

    IEnumerator stopTamirStartTalk()
    {
    yield return new WaitForSeconds(3);
    tamirAnimator.SetBool("isTalk", false);
    }


public void UpdateUi(int NumOfPage)
    {
        updateArrows(NumOfPage);
        updateInfluencerFeed(NumOfPage);
        presentInfoWindow();

        if (NumOfPage != 0)
        {
            imagesLibrary.SetActive(false);
        }
        else
        {
            imagesLibrary.SetActive(true);
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

    //����� �� ����� ������ ������
    public void StockImages()
    {
        if (ShowstockImages==true)
        {
            imagesLibraryview.SetActive(false);
            ShowstockImages = false;
            StockImagesBtn.disableBtn();
        }
        else
        {
            imagesLibraryview.SetActive(true);
            ShowstockImages = true;
            StockImagesBtn.enableBtn();
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
        influencerName.text = currentInfluencer.InfluencerName;
        postNumber.text = Reverse(currentInfluencer.NumofPosts).ToString() + " ������";
        followNumber.text = Reverse(currentInfluencer.NumOfFollowers).ToString()+ " ������";
        followingNumber.text = Reverse(currentInfluencer.NumOfFollowing).ToString() + " ���� ����";
        inflencePic.GetComponent<Image>().sprite = Resources.Load<Sprite>("influencersProfile/" + NumOfPage.ToString());
        updateDropAreasImages();
        
    }

    //����� ������ ��������
    public void updateDropAreasImages()
    {
        for (int i = 0; i < gameData.dropAreas.Count; i++)
        {
            Influencer currentInfluencer = gameData.getCurrentInfluencer();
            //gameData.dropAreas[i].setImage(currentInfluencer.photos[i]);
            gameData.dropAreas[i].GetComponentInChildren<Image>().sprite = currentInfluencer.photos[i];
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

    //����� ������
    public void infoText()
    {
        infoTXt.text = "����� ������ ��������� �� �������� ������ �� ����� ������ ��������� ����� ���� ����� ��� ����!";
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
            DeletePhoto(helpPress);
            helpPress++;
        }
        else
        {
            helpTxt.text = "������ ����� ����� ������. ������ �� ���� ����� ���������.";
            DeletePhoto(helpPress);
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


    public void DeletePhoto(int numberPress)
    {
        if (numberPress == 0)
        {
            deletePic1.SetActive(false);
        }
        else
        {
            deletePic2.SetActive(false);

        }
    }

    public void showFeedback(string message)
    {
        feedbackTxt.text = message;
        feedbackWindow.SetActive(true);
    }


    //5 ����� ���� ����� �����
    public IEnumerator displayFinishGame(int secs, int numbersec)
    {   
        yield return new WaitForSeconds(secs);

        //��� ������ ������
        int numbergro = 700;
        int finalenumber = 800;
        for (int i =numbergro; i<= finalenumber; i++)
        {
            yield return new WaitForSeconds(numbersec / 100);
            followNumber.text = Reverse(i) + " ������";
        }
        animationFinish.SetActive(true);
        yield return new WaitForSeconds(4);

        //����� �����
        Game3Logic.finishGame();
        //����� ��� ���� �����
        finishGameBk.SetActive(true);
        Game3Logic.stage3Sentence4();
        feedbackWindow.SetActive(false);
    }


}
