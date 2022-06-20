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
    public AudioSource tamirSound;
    public navigation soundBtn;

    void Start()
    {
        bubble.SetActive(false);
        startGameBtn.gameObject.SetActive(false);
        PlayerPrefs.SetInt("gameNumIn", 0);
        PlayerPrefs.SetInt("GameMax", 0);
        StartCoroutine(sentenceVideo1());
        tamir1.SetActive(true);
        tamir2.SetActive(true);
        tamirAnimator.SetBool("isTalk", true);
        tamir2.SetActive(false);
    }

    public void pressOpenGameBtn()
    {
        SceneManager.LoadScene("Game1");
    }


    IEnumerator sentenceVideo1()
    {
        storyPic.GetComponent<Image>().sprite = Resources.Load<Sprite>("openGame/opening1");
        //תמיר אליאנס
        Debug.Log("soundMangarOpen");
        startTxt.text = "היי חברים, שמח שהגעתם!";
        yield return new WaitForSeconds(2.5f);
        startTxt.text = "אני תמיר בן 71 מתל אביב. אני לומד בתיכון אליאנס.";
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
        storyPic.GetComponent<Image>().sprite = Resources.Load<Sprite>("openGame/opening4");
        //תמיר ספרים
        startTxt.text = "החלטתי ללמוד את השיטה שלו ולהעביר אותה לאנשים בגילי כי אני מאמין שככל שנרכוש את הכלים האלה בגיל צעיר יהיה לנו קל יותר בעתיד.";
        yield return new WaitForSeconds(8.8f);
        storyPic.GetComponent<Image>().sprite = Resources.Load<Sprite>("openGame/opening5");
        //פוסט תמיר
        startTxt.text = "התחלתי להעלות פוסטים בנושא, התגובות והלייקים שהגיעו גרמו לי להבין שאנשים אוהבים את התוכן שלי ורוצים להתייעץ איתי.";
        yield return new WaitForSeconds(7f);
        startTxt.text = "היום יש לי דף אינסטגרם מצליח שבו אני מפרסם פוסטים וטיפים שונים שלמדתי לאורך הדרך, סיפורים מעוררי השראה ספורט ואורח חיים בריא.";
        yield return new WaitForSeconds(9.4f);
        tamir1.SetActive(false);
        tamir2.SetActive(true);
        storyPic.GetComponent<Image>().sprite = Resources.Load<Sprite>("openGame/opening6");
        //רקע חלק תמיר
        startTxt.text = "לאחרונה, אני נורא עמוס בלימודים ואין לי זמן לנהל את פרופיל שלי . אני חייב את העזרה שלכם כדי לא לאבד את העוקבים היקרים שלי.";
        yield return new WaitForSeconds(8.3f);
        startTxt.text = "אני יודע שזה יכול להיות מאתגר, אבל חשוב שנזכור שפתרון בעיות זה משהו שאנחנו מתמודדים איתו כל הזמן.";
        yield return new WaitForSeconds(7f);
        startTxt.text = "אל תדאגו, אתם לא לבד אני איתכם לאורך כל הדרך.";
        yield return new WaitForSeconds(5f);
        startTxt.text = "שנתחיל?";
        tamirAnimator.SetBool("isTalk", false);
        yield return new WaitForSeconds(1f);
        bubble.SetActive(true);
        startGameBtn.gameObject.SetActive(true);
        tamirSound.Stop();
    }

    public void stopMusic(string musicName)
    {
        tamirSound.Stop();
    }

    public void ClickSoundBtn()
    {
        var currentVolume = tamirSound.volume;
        Debug.Log("currentVolume" + currentVolume);
        if (currentVolume == 1)
        {
            tamirSound.volume = 0;
            soundBtn.notMusic();
        }
        else
        {
            tamirSound.volume = 1;
            soundBtn.enableBtn();
        }
    }

    public void startOverVideotamir()
    {
        StopAllCoroutines();
        StartCoroutine(sentenceVideo1());
    }

}
