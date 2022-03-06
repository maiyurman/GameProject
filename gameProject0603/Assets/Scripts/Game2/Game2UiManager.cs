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

    //משתנים לייצוג המשתנים של הכפתורים
    public GameObject prevPageBtn;
    public GameObject nextPageBtn;

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
    public navigation musicBtn;
    public navigation userBtn;
    public navigation placeBtn;

    //------> תפריט סטורי
    public navigation[] storyBtns;

    //------>חלון פידבק
    public GameObject feedbackWindow;
    public TextMeshProUGUI feedbackTxt;

    //------>חלון משפיען עם הוראות
    public GameObject influenceInstractionWindow;
    public TextMeshProUGUI influenceInstractionTxt;

    public void Start()
    {
        gameData = transform.gameObject.GetComponent<Game3Data>();

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
        //חלון פידבק
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
       
        
    }

    //עדכון תמונות משפיענים
    public void updateDropAreasImages()
    {
        for (int i = 0; i < gameData.dropAreas.Count; i++)
        {
            Influencer currentInfluencer = gameData.getCurrentInfluencer();
            gameData.dropAreas[i].setImage(currentInfluencer.photos[i]);
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

    //פתיחת חלון אינפורמציה
    public void infoText()
    {
        infoTXt.text = "!עליכם להסתכל בפרופילים של משפיענים ולגלות את ארבעת החוקים שבאמצעותם תעזרו לאור לייצר פיד מנצח";
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
            helpPress++;
        }
        else
        {
            helpTxt.text = "הורדתי תמונה נוספת מהמאגר. ניצלתם את כמות העזרה המקסימלית.";
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

    //הפעלת כפתורי סטורי
    public void EnableStoryBtnsForLevel(int numOfLevel)
    {
        for(int i=1;i < numOfLevel; i++)
        {
            enableStoryBtn(i);
        }
    }

    //הפעלת כפתור סטורי
    public void enableStoryBtn(int buttonNum)
    {
        storyBtns[buttonNum - 1].enableBtn();        
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

    //5 שניות אחרי שנגמר המשחק
    public IEnumerator displayFinishGame(int secs, int numbersec)
    {   
        yield return new WaitForSeconds(secs);
        feedbackWindow.SetActive(false);

        //קוד להעלאת מספרים
        int numbergro = 700;
        int finalenumber = 800;
        for (int i =numbergro; i<= finalenumber; i++)
        {
            yield return new WaitForSeconds(numbersec / 100);
        }

        yield return new WaitForSeconds(secs/2);
        //הפעלת כפתור סטורי
        enableStoryBtn(3);
        influenceInstraction("הצלחתם לבנות לאור פרופיל מושלם ובזכותכם גדלו לו מספר העוקבים! לחצו על הסטורי כדי לגלות מהו השלב שעברתם");
    }


}
