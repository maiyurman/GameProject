using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;


public class openGameUi : MonoBehaviour
{
    public TextMeshProUGUI startTxt;
    public Image storyPic;
    public navigation startGameBtn;
    public Animation tamir;

    void Start()
    {
        startGameBtn.gameObject.SetActive(false);
        PlayerPrefs.SetInt("gameNumIn", 0);
        PlayerPrefs.SetInt("GameMax", 0);
        StartCoroutine(sentenceVideo1());
    }

    public void pressOpenGameBtn()
    {
        SceneManager.LoadScene("Game1");
    }


    IEnumerator sentenceVideo1()
    {
        storyPic.GetComponent<Image>().sprite = Resources.Load<Sprite>("openGame/opening1");
        startTxt.text = "היי חברים, שמח שהגעתם!";
        yield return new WaitForSeconds(4);
        storyPic.GetComponent<Image>().sprite = Resources.Load<Sprite>("openGame/opening2");
        startTxt.text = "אני תמיר בן 17 מתל אביב. אני לומד בתיכון אליאנס. יש לי 100,000 עוקבים באינסטגרם.";
        yield return new WaitForSeconds(4);
        storyPic.GetComponent<Image>().sprite = Resources.Load<Sprite>("openGame/opening3");
        startTxt.text = "אתם בטח שואלים למה??";
        yield return new WaitForSeconds(4);
        storyPic.GetComponent<Image>().sprite = Resources.Load<Sprite>("openGame/opening4");
        startTxt.text = "אבא שלי הוא מנטור מוכר שעוזר לבעלי עסקים לפתור את הבעיות שלהם, תמיד הערצתי אותו ורציתי להיות כמוהו.";
        yield return new WaitForSeconds(4);
        storyPic.GetComponent<Image>().sprite = Resources.Load<Sprite>("openGame/opening5");
        startTxt.text = "החלטתי ללמוד את השיטה שלו ולהעביר אותה לאנשים בגילי כי אני מאמין שככל שנרכוש את הכלים האלה בגיל צעיר יהיה לנו קל יותר בעתיד.";
        yield return new WaitForSeconds(4);
        storyPic.GetComponent<Image>().sprite = Resources.Load<Sprite>("openGame/opening6");
        startTxt.text = "התחלתי להעלות פוסטים בנושא, התגובות והלייקים שהגיעו גרמו לי להבין שאנשים אוהבים את התוכן שלי ורוצים להתייעץ איתי.";
        yield return new WaitForSeconds(4);
        storyPic.GetComponent<Image>().sprite = Resources.Load<Sprite>("openGame/opening7");
        startTxt.text = "היום יש לי דף אינסטגרם מצליח שבו אני מפרסם פוסטים וטיפים שונים שלמדתי לאורך הדרך, סיפורים מעוררי השראה ספורט ואורח חיים בריא.";
        yield return new WaitForSeconds(4);
        storyPic.GetComponent<Image>().sprite = Resources.Load<Sprite>("openGame/opening8");
        startTxt.text = "ולמה אתם פה?";
        yield return new WaitForSeconds(4);
        storyPic.GetComponent<Image>().sprite = Resources.Load<Sprite>("openGame/opening9");
        startTxt.text = "לאחרונה, אני נורא עמוס בלימודים ואין לי זמן לנהל את פרופיל שלי . אני חייב את העזרה שלכם כדי לא לאבד את העוקבים היקרים שלי.";
        yield return new WaitForSeconds(4);
        storyPic.GetComponent<Image>().sprite = Resources.Load<Sprite>("openGame/opening10");
        startTxt.text = "אני יודע שזה יכול להיות מאתגר, אבל חשוב שנזכור שפתרון בעיות זה משהו שאנחנו מתמודדים איתו כל הזמן.";
        yield return new WaitForSeconds(4);
        storyPic.GetComponent<Image>().sprite = Resources.Load<Sprite>("openGame/opening11");
        startTxt.text = "אל תדאגו, אתם לא לבד אני איתכם לאורך כל הדרך.";
        yield return new WaitForSeconds(4);
        storyPic.GetComponent<Image>().sprite = Resources.Load<Sprite>("openGame/opening12");
        startTxt.text = "שנתחיל?";
        yield return new WaitForSeconds(4);
        startTxt.text = "";
        startGameBtn.gameObject.SetActive(true);
    }
}
