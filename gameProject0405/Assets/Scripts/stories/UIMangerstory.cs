using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class UIMangerstory : MonoBehaviour
{
    private storiesData storiesData;

    //משתנים לייצוג המשתנים של הכפתורים
    //public navigation prevPageBtn;
    //public navigation nextPageBtn;

    //משתנה לייצוג כותרת הטקסט
    public TextMeshProUGUI storytitleText;
    //משתנה לייצוג הטקסט
    public TextMeshProUGUI storyText;
    //משתנה לייצוג הטקסט של כפתור השלב הבא
    public TextMeshProUGUI NextLevelTXTbtn;
    //משתנה לייצוג הטקסט
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

    //איפוס חיצים
    //public void updateArrows()
    //{
    //    //הצגת פעילות החיצים בהתאם למספר המקסימלי שפועל
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

    //    //הצגת החיצים בהתאם למספר העמוד בו נמצא המשתמש

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
        //אם מספר העמוד קטן מאורך המערך וגם מספר העמוד גדול ושווה מ0
        if (storiesData.pageNumber < 5 && storiesData.pageNumber >= 0)
        {
            //תגדיל את מספר העמוד ב-1
            storiesData.pageNumber++;

            //תשנה את הנתונים
            //updateArrows();
            updateUi();

        }
    }

    public void PrevPage()
    {
        //אם מספר העמוד שווה לאורך המערך וגם מספר העמוד גדול ושווה מ0
        if (storiesData.pageNumber <= 5 && storiesData.pageNumber > 1)
        {
            //תקטין את מספר העמוד ב-1
            storiesData.pageNumber--;

            //תשנה את הנתונים
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
            NextLevelTXTbtn.text = "למסך הסיום";
        }
        else
        {
            NextLevelTXTbtn.text = "לשלב הבא";
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
