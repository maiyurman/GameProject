using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Audio;
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
    public navgationFor2 soundBtn;


    void Start()
    {
        bubble.SetActive(false);
        startGameBtn.gameObject.SetActive(false);
        PlayerPrefs.SetInt("gameNumIn", 0);
        PlayerPrefs.SetInt("GameMax", 0);
        sentenceVideo1();
        tamir1.SetActive(true);
        tamirAnimator.SetBool("isTalk", true);
        tamir2.SetActive(false);
        //Checkmusicbtns("tamirRecord");
    }

    public void Checkmusicbtns(string musicBtnName)
    {
        string musicOn = PlayerPrefs.GetString("isMusicOn");
        Debug.Log("סטטוס מוזיקה" + musicOn);
        //אם המוזיקה מופעלת
        if(musicOn == "true")
        {
            Debug.Log("שם המוזיקה" + musicBtnName);
            FindObjectOfType<audioMangerOpen>().stayOn(musicBtnName);
        }
        else
        {
            FindObjectOfType<audioMangerOpen>().stayOff(musicBtnName);
        }
    }

    public void pressOpenGameBtn()
    {
        SceneManager.LoadScene("Game1");
    }


    public void sentenceVideo1()
    {
        FindObjectOfType<audioMangerOpen>().Play("openSentence1");
        FindObjectOfType<audioMangerOpen>().isPlaying("openSentence1");
        storyPic.GetComponent<Image>().sprite = Resources.Load<Sprite>("openGame/opening1");

    }

    public void ClickSoundBtn(string sound)
    {
        FindObjectOfType<audioMangerOpen>().click(sound);
    }

    public void stopMusic(string musicName)
    {
        StopAllCoroutines();
        FindObjectOfType<audioMangerOpen>().StopPlaying(musicName);
    }

    public void startOverVideotamir()
    {
        StopAllCoroutines();
        FindObjectOfType<audioMangerOpen>().StopPlaying("tamirRecord");
        sentenceVideo1();
    }

    public void sentence2tamir()
    {
        Debug.Log("הגעתי למשפט 2");
        FindObjectOfType<audioMangerOpen>().Play("openSentence2");
        FindObjectOfType<audioMangerOpen>().isPlaying("openSentence2");
        startTxt.text = "אני תמיר בן 71 מתל אביב.";
    }

    public void sentence3tamir()
    {
        FindObjectOfType<audioMangerOpen>().Play("openSentence3");
        FindObjectOfType<audioMangerOpen>().isPlaying("openSentence3");
        startTxt.text = "יש לי 001 אלף עוקבים באינסטגרם";
        storyPic.GetComponent<Image>().sprite = Resources.Load<Sprite>("openGame/opening2");

    }

    public void sentence4tamir()
    {
        FindObjectOfType<audioMangerOpen>().Play("openSentence4");
        FindObjectOfType<audioMangerOpen>().isPlaying("openSentence4");
        startTxt.text = "אתם בטח שואלים למה?";

    }

    public void sentence5tamir()
    {
        FindObjectOfType<audioMangerOpen>().Play("openSentence5");
        FindObjectOfType<audioMangerOpen>().isPlaying("openSentence5");
        startTxt.text = "אבא שלי הוא מנטור מוכר שעוזר לבעלי עסקים לפתור את הבעיות שלהם, תמיד הערצתי אותו ורציתי להיות כמוהו.";
        storyPic.GetComponent<Image>().sprite = Resources.Load<Sprite>("openGame/opening3");

    }

    public void sentence6tamir()
    {
        FindObjectOfType<audioMangerOpen>().Play("openSentence6");
        FindObjectOfType<audioMangerOpen>().isPlaying("openSentence6");
        startTxt.text = "החלטתי ללמוד את השיטה שלו לפתירת בעיות בצורה נכונה ולהעביר אותה לאנשים בגילי.";

    }

    public void sentence7tamir()
    {
        FindObjectOfType<audioMangerOpen>().Play("openSentence7");
        FindObjectOfType<audioMangerOpen>().isPlaying("openSentence7");
        startTxt.text = "כולנו נתקלים בבעיות מסוגים שונים בכל תחומי החיים אבל אנחנו לא תמיד יודעים איך לגשת אליהן.";
        storyPic.GetComponent<Image>().sprite = Resources.Load<Sprite>("openGame/opening4");

    }
    public void sentence8tamir()
    {
        FindObjectOfType<audioMangerOpen>().Play("openSentence8");
        FindObjectOfType<audioMangerOpen>().isPlaying("openSentence8");
        startTxt.text = "היום, אנחנו נדרשים לפתור בעיות במהירות וביעילות כדי לעמוד בקצב של העולם החדש שדורש מיומנויות שלא השתמשנו בהן פעם.";

    }

    public void sentence9tamir()
    {
        FindObjectOfType<audioMangerOpen>().Play("openSentence9");
        FindObjectOfType<audioMangerOpen>().isPlaying("openSentence9");
        startTxt.text = "אני מאמין שככל שנרכוש את הכלים האלה בגיל צעיר יהיה לנו קל יותר להסתדר בעתיד.";

    }


    public void sentence10tamir()
    {
        FindObjectOfType<audioMangerOpen>().Play("openSentence10");
        FindObjectOfType<audioMangerOpen>().isPlaying("openSentence10");
        startTxt.text = "בעקבות הצורך הזה, התחלתי להעלות פוסטים שעוזרים לפתור בעיות בקלות ובמהירות.";
        storyPic.GetComponent<Image>().sprite = Resources.Load<Sprite>("openGame/opening5");

    }


    public void sentence11tamir()
    {
        FindObjectOfType<audioMangerOpen>().Play("openSentence11");
        FindObjectOfType<audioMangerOpen>().isPlaying("openSentence11");
        startTxt.text = "התגובות והלייקים שהגיעו גרמו לי להבין שאנשים אוהבים את התוכן שלי וזקוקים לכלים להתמודדות עם בעיות בתחומים שונים.";

    }


    public void sentence12tamir()
    {
        tamir1.SetActive(false);
        tamir2.SetActive(true);
        FindObjectOfType<audioMangerOpen>().Play("openSentence12");
        FindObjectOfType<audioMangerOpen>().isPlaying("openSentence12");
        startTxt.text = "ולמה אתם פה?";
        storyPic.GetComponent<Image>().sprite = Resources.Load<Sprite>("openGame/opening6");

    }


    public void sentence13tamir()
    {
        FindObjectOfType<audioMangerOpen>().Play("openSentence13");
        FindObjectOfType<audioMangerOpen>().isPlaying("openSentence13");
        startTxt.text = "לאחרונה, אני נורא עמוס בלימודים ואין לי זמן לנהל את הפרופיל ברשת ה-Solver. אני חייב את העזרה שלכם כדי לא לאבד את העוקבים שלי.";

    }


    public void sentence14tamir()
    {
        FindObjectOfType<audioMangerOpen>().Play("openSentence14");
        FindObjectOfType<audioMangerOpen>().isPlaying("openSentence14");
        startTxt.text = "אז כדי לעזור לי, אתם תעברו 5 שלבים שכל אחד מהם מתאר שלב אחר בתהליך פתרון הבעיות - בדיוק כמו השיטה שאבא שלי מלמד.";

    }


    public void sentence15tamir()
    {
        FindObjectOfType<audioMangerOpen>().Play("openSentence15");
        FindObjectOfType<audioMangerOpen>().isPlaying("openSentence15");
        startTxt.text = "בסוף כל שלב, אתם תגלו איך הצלחתם לשמור על הפרופיל שלי ותלמדו איך התהליך הזה יכול לעזור לכם בפתרון בעיות.";
 
    }


    public void sentence16tamir()
    {
        FindObjectOfType<audioMangerOpen>().Play("openSentence16");
        FindObjectOfType<audioMangerOpen>().isPlaying("openSentence16");
        startTxt.text = "אני יודע שזה יכול להיות מאתגר, אבל חשוב שנזכור שפתרון בעיות זה משהו שאנחנו מתמודדים איתו כל הזמן.";
  
    }


    public void sentence17tamir()
    {
        FindObjectOfType<audioMangerOpen>().Play("openSentence17");
        FindObjectOfType<audioMangerOpen>().isPlaying("openSentence17");
        startTxt.text = "אין מה לדאוג, אתם לא לבד אני איתכם לאורך כל הדרך!";
 
    }


    public void sentence18tamir()
    {
        FindObjectOfType<audioMangerOpen>().Play("openSentence18");
        FindObjectOfType<audioMangerOpen>().isPlaying("openSentence18");
        startTxt.text = "שנתחיל?";
    }

    public void finishTalk()
    {
        tamirAnimator.SetBool("isTalk", false);
        bubble.SetActive(true);
        startGameBtn.gameObject.SetActive(true);
    }

}
