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
        StartCoroutine(sentenceVideo1());
        tamir1.SetActive(true);
        tamirAnimator.SetBool("isTalk", true);
        tamir2.SetActive(false);
        Checkmusicbtns("tamirRecord");
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


    IEnumerator sentenceVideo1()
    {
        FindObjectOfType<audioMangerOpen>().Play("tamirRecord");
        storyPic.GetComponent<Image>().sprite = Resources.Load<Sprite>("openGame/opening1");
        //תמיר אליאנס
        startTxt.text = "היי חברים מה שלומכם? ברוכים הבאים לרשת החברתית revloS, לפני שאספר לכם מה אתם עושים פה אני אציג את עצמי.";
        yield return new WaitForSeconds(2.5f);
        startTxt.text = "אני תמיר בן 71 מתל אביב.";
        yield return new WaitForSeconds(3f);
        storyPic.GetComponent<Image>().sprite = Resources.Load<Sprite>("openGame/opening2");
        //תמיר תקציב פיד
        startTxt.text = "ויש לי 001 אלף עוקבים באינסטגרם";
        yield return new WaitForSeconds(2f);
        startTxt.text = "אתם בטח שואלים למה?";
        yield return new WaitForSeconds(2f);
        storyPic.GetComponent<Image>().sprite = Resources.Load<Sprite>("openGame/opening3");
        //אבא של תמיר במה
        startTxt.text = "אבא שלי הוא מנטור מוכר שעוזר לבעלי עסקים לפתור את הבעיות שלהם, תמיד הערצתי אותו ורציתי להיות כמוהו.";
        yield return new WaitForSeconds(8f);
        startTxt.text = "החלטתי ללמוד את השיטה שלו לפתירת בעיות בצורה נכונה ולהעביר אותה לאנשים בגילי.";
        yield return new WaitForSeconds(8f);
        storyPic.GetComponent<Image>().sprite = Resources.Load<Sprite>("openGame/opening4");
        //תמיר ספרים
        startTxt.text = "כולנו נתקלים בבעיות מסוגים שונים בכל תחומי החיים אבל אנחנו לא תמיד יודעים איך לגשת אליהן.";
        yield return new WaitForSeconds(8.8f);
        startTxt.text = "היום, אנחנו נדרשים לפתור בעיות במהירות וביעילות כדי לעמוד בקצב של העולם החדש שדורש מיומנויות שלא השתמשו בהן פעם.";
        yield return new WaitForSeconds(8.8f);
        startTxt.text = "אני מאמין שככל שנרכוש את הכלים האלה בגיל צעיר יהיה לנו קל יותר להסתדר בעתיד.";
        yield return new WaitForSeconds(8.8f);
        storyPic.GetComponent<Image>().sprite = Resources.Load<Sprite>("openGame/opening5");
        //פוסט תמיר
        startTxt.text = "בעקבות הצורך הזה, התחלתי להעלות פוסטים שעוזרים לפתור בעיות בקלות ובמהירות.";
        yield return new WaitForSeconds(7f);
        startTxt.text = "התגובות והלייקים שהגיעו גרמו לי להבין שאנשים אוהבים את התוכן שלי וזקוקים לכלים להתמודדות עם בעיות בתחומים שונים.";
        yield return new WaitForSeconds(7f);
        tamir1.SetActive(false);
        tamir2.SetActive(true);
        storyPic.GetComponent<Image>().sprite = Resources.Load<Sprite>("openGame/opening6");
        //רקע חלק תמיר
        startTxt.text = "ולמה אתם פה?";
        yield return new WaitForSeconds(8.3f);
        startTxt.text = "לאחרונה, אני נורא עמוס בלימודים ואין לי זמן לנהל את הפרופיל ברשת ה-Solver. אני חייב את העזרה שלכם כדי לא לאבד את העוקבים שלי.";
        yield return new WaitForSeconds(8.3f);
        startTxt.text = "אז כדי לעזור לי, אתם תעברו 5 שלבים שכל אחד מהם מתאר שלב אחר בתהליך פתרון הבעיות - בדיוק כמו השיטה שאבא שלי מלמד.";
        yield return new WaitForSeconds(8.3f);
        startTxt.text = "בסוף כל שלב, אתם תגלו איך הצלחתם לשמור על הפרופיל שלי ותלמדו איך התהליך הזה יכול לעזור לכם בפתרון בעיות.";
        yield return new WaitForSeconds(8.3f);
        startTxt.text = "אני יודע שזה יכול להיות מאתגר, אבל חשוב שנזכור שפתרון בעיות זה משהו שאנחנו מתמודדים איתו כל הזמן.";
        yield return new WaitForSeconds(7f);
        startTxt.text = "אין מה לדאוג, אתם לא לבד אני איתכם לאורך כל הדרך!";
        yield return new WaitForSeconds(5f);
        startTxt.text = "שנתחיל?";
        tamirAnimator.SetBool("isTalk", false);
        yield return new WaitForSeconds(1f);
        bubble.SetActive(true);
        startGameBtn.gameObject.SetActive(true);
        FindObjectOfType<audioMangerOpen>().StopPlaying("tamirRecord");
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

    //public void ClickSoundBtn()
    //{
    //    var currentVolume = tamirSound.volume;

    //    if (currentVolume == 1)
    //    {
    //        tamirSound.volume = 0;
    //        soundBtn.notMusic();
    //    }
    //    else
    //    {
    //        tamirSound.volume = 1;
    //        soundBtn.enableBtn();

    //    }
    //}

    public void startOverVideotamir()
    {
        StopAllCoroutines();
        FindObjectOfType<audioMangerOpen>().StopPlaying("tamirRecord");
        StartCoroutine(sentenceVideo1());
    }

}
