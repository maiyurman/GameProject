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

    //משתנים לייצוג הערכים של המשפיען
    public TextMeshProUGUI influencerName;
    public TextMeshProUGUI postNumber;
    public TextMeshProUGUI followNumber;
    public TextMeshProUGUI followingNumber;
    public Image inflencePic;

    //משתנים לייצוג המשתנים של הכפתורים
    public GameObject prevPageBtn;
    public GameObject nextPageBtn;


    //-----------------------> מאגר תמונות

    //כפתור + מאגר התמונות
    public GameObject imagesLibrary;
    public navigation StockImagesBtn;

    //מאגר התמונות
    public GameObject imagesLibraryview;

    //בודק מצב תצוגה של מאגר התמונות
    bool ShowstockImages;

    public GameObject deletePic1;
    public GameObject deletePic2;


    //------------------------> כפתור עזרה והוראות

    public navigation InfluencerBtn;

    public GameObject windowInfo;

    public navigation intoBtn;
    public navigation helpBtn;

    public TextMeshProUGUI infoTXt;
    public TextMeshProUGUI helpTxt;

    public int helpPress;

    //------> תפריט עליון
    public navigation messageBtn;
    public navigation userBtn;
    public navigation placeBtn;

    //------>חלון פידבק
    public GameObject feedbackWindow;
    public TextMeshProUGUI feedbackTxt;

    //------>חלון סיום משחק
    public GameObject finishGameBk;

    //------>אנימציה תמיר 
    public Animator tamirAnimator;

    public GameObject animationFinish;

    public void Start()
    {
        gameData = transform.gameObject.GetComponent<Game3Data>();
        Game3Logic = transform.gameObject.GetComponent<Game3Logic>();

        //כיבוי חלון סיום משחק
        finishGameBk.SetActive(false);
        //העלמת מאגר התמונות - בלחיצה על כפתור ניתן לראות
        imagesLibraryview.SetActive(false);
        //העלמת חלונית האינפורמציה - בלחיצה על כפתור ניתן לראות
        windowInfo.SetActive(false);
        //איפוס מספר הלחיצות על כפתור עזרה
        helpPress = 0;
        //הצגה של כפתור הפיד פעיל
        userBtn.enableBtn();
        //הצגה של כפתור המשפיען פעיל
        InfluencerBtn.enableBtn();
        intoBtn.enableBtn();
        helpBtn.enableBtn();
        //כיבוי הכפתורים הלא רלוונטיים
        messageBtn.disableBtn();
        placeBtn.disableBtn();
        //חלון פידבק
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
        //אם מספר העמוד קטן מאורך המערך וגם מספר העמוד גדול ושווה מ0
        if (gameData.pageNumber < gameData.influencers.Length && gameData.pageNumber >= 0)
        {
            //תגדיל את מספר העמוד ב-1
            gameData.pageNumber++;
            //תשנה את הנתונים
            UpdateUi(gameData.pageNumber);
        }
    }
    public void PrevPage()
    {
        //אם מספר העמוד שווה לאורך המערך וגם מספר העמוד גדול ושווה מ0
        if (gameData.pageNumber < gameData.influencers.Length && gameData.pageNumber > 0)
        {
            //תקטין את מספר העמוד ב-1
            gameData.pageNumber--;
            //תשנה את הנתונים
            UpdateUi(gameData.pageNumber);
        }
    }

    //לחיצה על כפתור ספריית תמונות
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

    //איפוס חיצים
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

    //עדכון דף משפיענים
    private void updateInfluencerFeed(int NumOfPage)
    {
        Influencer currentInfluencer = gameData.getCurrentInfluencer() ;

        //הכנסה למשתנים על הבמה
        influencerName.text = currentInfluencer.InfluencerName;
        postNumber.text = Reverse(currentInfluencer.NumofPosts).ToString() + " פוסטים";
        followNumber.text = Reverse(currentInfluencer.NumOfFollowers).ToString()+ " עוקבים";
        followingNumber.text = Reverse(currentInfluencer.NumOfFollowing).ToString() + " עוקב אחרי";
        inflencePic.GetComponent<Image>().sprite = Resources.Load<Sprite>("influencersProfile/" + NumOfPage.ToString());
        updateDropAreasImages();
        
    }

    //עדכון תמונות משפיענים
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

    //הצגת חלון אינפורמציה  
    public void infoWindow()
    {
        windowInfo.SetActive(true);
        intoBtn.transform.gameObject.SetActive(true);
        //אם נלחץ פעמיים עזרה או מספר העמוד גדול מ0 אז תעלים את כפתור עזרה
        presentInfoWindow();
        InfluencerBtn.disableBtn();

    }

    //סגירת חלון אינפורמציה
    public void closeinfoWindow()
    {
        helpTxt.text = "";
        infoTXt.text = "";
        windowInfo.SetActive(false);
        InfluencerBtn.enableBtn();

    }

    //פתיחת הוראות
    public void infoText()
    {
        infoTXt.text = "עליכם להסתכל בפרופילים של משפיענים ולגלות את ארבעת החוקים שבאמצעותם תעזרו לאור לייצר פיד מנצח!";
        helpTxt.text = "";
        intoBtn.transform.gameObject.SetActive(false);
        helpBtn.transform.gameObject.SetActive(false);

    }

    //בלחיצה על כפתור עזרה
    public void helpText()
    {
        infoTXt.text = "";
        intoBtn.transform.gameObject.SetActive(false);
        helpBtn.transform.gameObject.SetActive(false);
        //מצבים בהם נותנים את העזרה ומציגים טקסט
        if (helpPress == 0)
        {
            helpTxt.text = "כדי לעזור לכם, הורדתי תמונה שאינה רלוונטית כדי לצמצם אפשרויות.";
            DeletePhoto(helpPress);
            helpPress++;
        }
        else
        {
            helpTxt.text = "הורדתי תמונה נוספת מהמאגר. ניצלתם את כמות העזרה המקסימלית.";
            DeletePhoto(helpPress);
            helpPress++;
        }
    }

    //חלון אינפורמציה הצגת כפתורים
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
            //כפתור עזרה לא פעיל
            helpBtn.disableBtn();
        }
    }


    //היפוך מספרים
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


    //5 שניות אחרי שנגמר המשחק
    public IEnumerator displayFinishGame(int secs, int numbersec)
    {   
        yield return new WaitForSeconds(secs);

        //קוד להעלאת מספרים
        int numbergro = 700;
        int finalenumber = 800;
        for (int i =numbergro; i<= finalenumber; i++)
        {
            yield return new WaitForSeconds(numbersec / 100);
            followNumber.text = Reverse(i) + " עוקבים";
        }
        animationFinish.SetActive(true);
        yield return new WaitForSeconds(4);

        //הפעלת סטורי
        Game3Logic.finishGame();
        //הדלקת מסך סיום המשחק
        finishGameBk.SetActive(true);
        Game3Logic.stage3Sentence4();
        feedbackWindow.SetActive(false);
    }


}
