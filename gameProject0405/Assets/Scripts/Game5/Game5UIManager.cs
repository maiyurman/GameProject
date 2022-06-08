using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Game5UIManager : MonoBehaviour
{
    public GameObject round1;
    public GameObject round2;
    public GameObject round3;
    public GameObject influenceFeedBack;
    public navigation checkBtn;
    private Game5DragLogic Game5DragLogic;
    private Dragable currentdragable;
    public GameObject feedbackwindow;
    public GameObject feedbackAnotherTry;
    public TextMeshProUGUI feedbackTxt;
    public TextMeshProUGUI feedbackBtnTxt;
    public int tryNum;
    public int numRound;
    private string message;
    public GameObject round1Animation;
    public GameObject round2Animation;
    public GameObject round3Animation;


    void Start()
    {
        initround();
        tryNum = 0;
        checkBtn.gameObject.transform.gameObject.SetActive(false);
        Game5DragLogic = transform.gameObject.GetComponent<Game5DragLogic>();
        feedbackwindow.SetActive(false);
        numRound = 1;
        round1Animation.SetActive(false);
        round2Animation.SetActive(false);
        round3Animation.SetActive(false);

    }

    public void initround()
    {
        influenceFeedBack.SetActive(false);
        feedbackAnotherTry.SetActive(false);
        round1.SetActive(false);
        round2.SetActive(false);
        round3.SetActive(false);
    }

    public void movetoPlace(Dragable dragable, DropArea dropArea)
    {
        currentdragable = dragable;
        //הגדרה של הכפתור
        Vector3 dragableplace = dragable.transform.position;
        dragableplace = dropArea.transform.position;
        //הדלקה של כפתור הבדיקה
        checkBtn.enableBtn();
        Debug.Log("btnOn");

    }

    public void checkBtnClick()
    {
        if (Game5DragLogic.isTrueAnswer == true)
        {
            feedbackTrue();
        }
        else
        {
            feedbackfalse();

        }
    }

    public void feedbackTrue()
    {
        //מעלימים את כפתור הבדיקה
        checkBtn.gameObject.transform.gameObject.SetActive(false);
        if (numRound == 1)
        {
            //אנימציית נסיעה
            round1Animation.SetActive(true);
        }
        else if(numRound == 2)
        {
            round2Animation.SetActive(true);        }
        else
        {
            round3Animation.SetActive(true);
        }
        StartCoroutine(MySeconds());
    }

    public void feedbackfalse()
    {
        if (tryNum == 0)
        {
            feedbackfalseTry();
        }
        else
        {
            feedbackfalseFinish();
            feedbackFalseMessageRound();
            feedbackwindowopen(message);
        }

    }

    public void feedbackfalseTry()
    {
        currentdragable.returnToInitPosition();
        feedbackAnotherTry.SetActive(true);
        //הכפתור הופך ללא פעיל שוב
        checkBtn.disableBtn();
        tryNum++;
    }

    public void feedbackfalseFinish()
    {
        Debug.Log("תשובה לא נכונה - מתן הפידבק להמשך משחק");
        //מעלימים את כפתור הבדיקה
        checkBtn.gameObject.transform.gameObject.SetActive(false);

    }

    public void feedbackwindowopen(string message)
    {
        feedbackwindow.SetActive(true);
        feedbackTxt.text = message;

        if (numRound == 1 | numRound == 2)
        {
            feedbackBtnTxt.text = "למשחק הבא";
        }
        else
        {
            feedbackBtnTxt.text = "לסיום המשחק";
        }
    }

    public void feedbackFalseMessageRound()
    {
        if (numRound == 1)
        {
            message = "תשובתכם אינה נכונה המסלול המהיר ביותר הוא של הילה -רק במסלול זה השליח עובר פעם אחת בכל בית על מנת לחלק את המתנות";
        }
        else if (numRound == 2)
        {
            message = "תשובתכם אינה נכונה המסלול המהיר ביותר הוא של רותם -רק במסלול זה השליח עובר פעם אחת בכל בית על מנת לחלק את המתנות";
        }
        else
        {
            message = "תשובתכם אינה נכונה המסלול המהיר ביותר הוא של בן -רק במסלול זה השליח עובר פעם אחת בכל בית על מנת לחלק את המתנות";
        }
    }

    public void finishRoundClick()
    {
        if (numRound == 1)
        {
            numRound++;
            round1.SetActive(false);
            round2.SetActive(true);
            round3.SetActive(false);
            feedbackwindow.SetActive(false);
            Game5DragLogic.isTrueAnswer = false;
            tryNum = 0;
            checkBtn.gameObject.transform.gameObject.SetActive(true);
        }
        else if (numRound == 2)
        {
            numRound++;
            round1.SetActive(false);
            round2.SetActive(false);
            round3.SetActive(true);
            feedbackwindow.SetActive(false);
            Game5DragLogic.isTrueAnswer = false;
            tryNum = 0;
            checkBtn.gameObject.transform.gameObject.SetActive(true);

        }
        else
        {
            influenceFeedBack.SetActive(true);
            feedbackwindow.SetActive(false);
        }

    }

    IEnumerator MySeconds()
    {
        Debug.Log("start time" + Time.time);
        yield return new WaitForSeconds(3f);
        Debug.Log("after time" + Time.time);
        message = "תשובה נכונה כל הכבוד!";
        //פונקציה שמקפיצה חלון
        feedbackwindowopen(message);
    }

}



