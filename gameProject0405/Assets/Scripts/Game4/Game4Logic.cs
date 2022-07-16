using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Game4Logic : MonoBehaviour
{
    private Game4UiManager Game4UiManager;

    //מספרים
    int Game1Try;
    int Game2Try;
    public navigation sendBtnGame1;
    public navigation sendBtnGame2;

    public navigation placeBtn;
    public navigation userBtn;
    public navigation MessageBtn;

    //משתנים משחק 1
    public Chat chatGame1;
    string MessageinputGame1;
    public GameObject finishgame1;
    public GameObject questionGame1;
    public TMP_InputField inputGame1;
    public GameObject lightBtn1;

    //משתנים משחק 2
    public Chat chatGame2;
    string MessageinputGame2;
    public GameObject finishgame2;
    public GameObject questionGame2;
    public TMP_InputField inputGame2;
    public GameObject lightBtn2;

    //סטורי
    private loadStoryBtn loadStoryBtn;

    //אנימציית הצלחה
    public GameObject game4Animation1;
    public GameObject game4Animation2;


    //------>אנימציה תמיר 
    public Animator tamirAnimator;

    public Animator tamir;

    public GameObject emojiHappy;
    public GameObject emojiSad;
    public GameObject emojiLike;
    public GameObject emojiDislike;

    string musicOn;

    string currentMusic;


    // Start is called before the first frame update
    void Start()
    {
        loadStoryBtn = transform.gameObject.GetComponent<loadStoryBtn>();
        //כיבוי כל הסטורי
        loadStoryBtn.disableStoryBtnAll();
        Debug.Log(PlayerPrefs.GetInt("GameMax"));
        //להדליק את הסטורי שרלוונטיים לשלב המקסימלי
        int myMaxLevel = PlayerPrefs.GetInt("GameMax");
        Debug.Log("Max Level start" + myMaxLevel);
        questionGame1.SetActive(true);
        questionGame2.SetActive(true);

        if (PlayerPrefs.GetInt("GameMax") != 0)
        {
            int MaxStage = PlayerPrefs.GetInt("GameMax");
            Debug.Log(MaxStage);
            loadStoryBtn.EnableStoryBtnsForLevel(MaxStage);
            Debug.Log(MaxStage);
        }
        placeBtn.disableBtn();
        userBtn.disableBtn();
        MessageBtn.disableBtn();

        Game4UiManager = transform.gameObject.GetComponent<Game4UiManager>();
        stage4Sentence1();
    }

    public void Checkmusicbtns(string musicBtnName)
    {
        musicOn = PlayerPrefs.GetString("isMusicOn");
        //אם המוזיקה מופעלת
        if (musicOn == "true")
        {
            FindObjectOfType<audioManger4>().stayOn(musicBtnName);
        }
        else
        {
            FindObjectOfType<audioManger4>().stayOff(musicBtnName);
        }
    }

    public void stage4Sentence1()
    {
        tamir.SetBool("isTalk", true);
        currentMusic = "stage4Sentence1";
        Checkmusicbtns(currentMusic);
        FindObjectOfType<audioManger4>().Play("stage4Sentence1");
        FindObjectOfType<audioManger4>().isPlaying("stage4Sentence1");
    }

    public void stage4Sentence2()
    {
        if (currentMusic == "stage4Sentence1")
        {
            stopMusic();
            tamir.SetBool("isTalk", true);
            currentMusic = "stage4Sentence2";
            Checkmusicbtns(currentMusic);
            FindObjectOfType<audioManger4>().Play("stage4Sentence2");
            FindObjectOfType<audioManger4>().isPlaying("stage4Sentence2");
        }
    }

    public void stage4Sentence3()
    {
        if (currentMusic == "stage4Sentence2")
        {
            stopMusic();
            tamir.SetBool("isTalk", true);
            currentMusic = "stage4Sentence3";
            Checkmusicbtns(currentMusic);
            FindObjectOfType<audioManger4>().Play("stage4Sentence3");
            FindObjectOfType<audioManger4>().isPlaying("stage4Sentence3");
        }
    }

    public void stage4Sentence4()
    {
        if (currentMusic == "stage4Sentence3")
        {
            stopMusic();
            tamir.SetBool("isTalk", true);
            currentMusic = "stage4Sentence4";
            Checkmusicbtns(currentMusic);
            FindObjectOfType<audioManger4>().Play("stage4Sentence4");
            FindObjectOfType<audioManger4>().isPlaying("stage4Sentence4");
        }
    }

    public void ClickSoundBtn(string sound)
        {
            FindObjectOfType<audioManger4>().click(sound);
        }

        public void stopMusic()
        {
            string musicName = currentMusic;
            FindObjectOfType<audioManger4>().StopPlaying(musicName);
        }

    public void stopTamirTalk()
    {
        StartCoroutine(stopTamirStartTalk());

    }

    IEnumerator stopTamirStartTalk()
    {
        yield return new WaitForSeconds(2);
        tamirAnimator.SetBool("isTalk", false);
    }

    public void opengame1ChatBox()
    {
    
        StartCoroutine(lightBtn1Box());
    }

    IEnumerator lightBtn1Box()
    {
        lightBtn1.SetActive(false);
        yield return new WaitForSeconds(3f);
        lightBtn1.SetActive(true);

    }

    public void opengame2ChatBox()
    {

        StartCoroutine(lightBtn2Box());
    }

    IEnumerator lightBtn2Box()
    {
        lightBtn2.SetActive(false);
        yield return new WaitForSeconds(3f);
        lightBtn2.SetActive(true);

    }


    //------------------------------------------------משחק 1 פידבקים

    public void initGame1()
    {
        game4Animation1.SetActive(false);
        finishgame1.SetActive(false);
        Game1Try = 0;
        MessageinputGame1 = "";
        chatGame1.setChatTitle("petSysaE");
        chatGame1.setProfilePhoto("EasyStep");
        chatGame1.initChat();
        chatGame1.addTextMessage(Chat.Direction.RECEIVE, " שלום, מדבר מתן מחברת petSyzaE, חברה העוסקת במכירת מוצרי ספורט.", 3);
    }

    public void sendMessageStart()
    {
        StartCoroutine(sendMessageChat1());
    }

    IEnumerator sendMessageChat1()
    {
        yield return new WaitForSeconds(4);
        playMessage();
        chatGame1.addTextMessage(Chat.Direction.RECEIVE, "בהמשך לשיחתנו, כחלק מהצטרפותך לחברה סוכם כי תפרסם סטורי אחד לשבוע בו תצלם/תספר על  נעלי הספורט החדשות שלנו.", 6);
        yield return new WaitForSeconds(4);
        playMessage();
        chatGame1.addTextMessage(Chat.Direction.RECEIVE, "אנחנו יודעים מהשיחה הקודמת שנערכה איתך שתתקשה להתחייב לשתף איתנו פעולה במשך שנה שלמה.", 4);
        yield return new WaitForSeconds(4);
        playMessage();
        chatGame1.addTextMessage(Chat.Direction.RECEIVE, "אנחנו מוכנים לשנות את החוזה לתקופה של חצי שנה אך, נשמח שבתמורה תחשוב על מספר שירותים נוספים שתוכל לספק עבורינו.", 7);
    }

    public void updateGame1Message(string Message)
    {
        MessageinputGame1 = Message;
    }

    public void onvaluechaneGame1Message()
    {
        if (inputGame1.text == "")
        {
            sendBtnGame1.disableBtn();
        }
        else
        {
            sendBtnGame1.enableBtn();
        }
    }

    public void sendMessageToGame1Chat()
    {
        inputGame1.text = "";
        Debug.Log(MessageinputGame1);
        chatGame1.addTextMessage(Chat.Direction.SEND, MessageinputGame1, 3);
        StartCoroutine(handleGame1Answer(MessageinputGame1));
    }

    IEnumerator handleGame1Answer(string answer)
    {
        yield return new WaitForSeconds(1);

        bool isCorrectAnswer = answer.Contains("תיוג") || answer.Contains("פרסום מוצרים") || answer.Contains("פרסום סרטון המלצה");
        if (isCorrectAnswer)
        {
            playMessage();
            chatGame1.addTextMessage(Chat.Direction.RECEIVE, "נשמע פתרון מעולה! חשבנו גם על ההצעות הבאות: תיוג בסטורי פעם בשבוע, פרסום מוצרים בפיד ופרסום סרטון המלצה.", 7);
            yield return new WaitForSeconds(2);
            playMessage();
            chatGame1.addTextMessage(Chat.Direction.RECEIVE, "חוזה מעודכן ישלח בהמשך, תודה רבה על שיתוף הפעולה!", 4);
            yield return new WaitForSeconds(1);
            //אנימציה כל הכבוד
            game4Animation1.SetActive(true);

            displayFinishGame1Screen();
        } 
        else if (Game1Try == 0)
        {
            playMessage();
            chatGame1.addTextMessage(Chat.Direction.RECEIVE, "תודה על תשובתך, נשמח לשמוע על פתרונות נוספים.", 5);
            Game1Try = 1;
        } 
        else
        {
            playMessage();
            chatGame1.addTextMessage(Chat.Direction.RECEIVE, "תודה על השתתפותך, אנחנו חשבנו על ההצעות הבאות: תיוג בסטורי פעם בשבוע, פרסום מוצרים בפיד, פרסום סרטון המלצה.", 5);
            yield return new WaitForSeconds(3);
            playMessage();
            chatGame1.addTextMessage(Chat.Direction.RECEIVE, "במידה ויהיו לך פתרונות נוספים נדון עליהם בהמשך.", 5);
            displayFinishGame1Screen();
        }
    }
    public void displayFinishGame1Screen()
    {
        sendBtnGame1.gameObject.SetActive(false);
        questionGame1.SetActive(false);
        //הפעלת כפתור לסיום הצ'אטים
        finishgame1.SetActive(true);
    }

    //------------------------------------------------משחק 2 פידבקים

    public void initGame2()
    {
        game4Animation2.SetActive(false);
        finishgame2.SetActive(false);
        Game2Try = 0;
        MessageinputGame2 = "";
        chatGame2.setChatTitle("efiLretteB");
        chatGame2.setProfilePhoto("BetterLife");
        chatGame2.initChat();
        chatGame2.addTextMessage(Chat.Direction.RECEIVE, "שלום, מדברת ענת מחברת efiLretteB, חברת מוצרי טכנולוגיה לשיפור אורח חיים בריא. רציתי לעדכן אותך לגבי שינויי החוזה שלנו.", 6);
        StartCoroutine(sendMessageChat2());
    }

    IEnumerator sendMessageChat2()
    {
        yield return new WaitForSeconds(5);
        playMessage();
        chatGame2.addTextMessage(Chat.Direction.RECEIVE, "לצערי, אין לנו יכולת לשלם לך יותר מ-000,3 שקלים על כל העלאת פוסט של מוצרי החברה שלנו בפרופיל האישי שלך.", 6);
        yield return new WaitForSeconds(5);
        playMessage();
        chatGame2.addTextMessage(Chat.Direction.RECEIVE, "מאחר ומאוד התרשמנו מהפרופיל שלך ומהאופן שבו אתה משווק את המוצרים שלנו, אנחנו נשמח לשמוע ממך איך אתה רוצה שנתגמל אותך במקום?", 6);
    }

    public void updateGame2Message(string Message)
    {
        MessageinputGame2 = Message;

    }

    public void onvaluechaneGame2Message()
    {
        if (inputGame2.text == "")
        {
            sendBtnGame2.disableBtn();
        }
        else
        {
            sendBtnGame2.enableBtn();
        }
    }

    public void sendMessageToGame2Chat()
    {
        inputGame2.text = "";
        chatGame2.addTextMessage(Chat.Direction.SEND, MessageinputGame2, 3);
        StartCoroutine(handleGame2Answer(MessageinputGame2));
    }

    IEnumerator handleGame2Answer(string answer)
    {
        yield return new WaitForSeconds(1);

        bool isCorrectAnswer = answer.Contains("מוצרים") || answer.Contains("הנחות") || answer.Contains("קופונים") || answer.Contains("פרזנטור") || answer.Contains("פרסום") || answer.Contains("אירוע");
        if (isCorrectAnswer)
        {
            playMessage();
            chatGame2.addTextMessage(Chat.Direction.RECEIVE, "נשמע פתרון מעולה! חשבנו גם על התגמולים הבאים: יותר מוצרים מחברה שלנו בחינם, קופונים והנחות לעוקבים, הארכת חוזה לשנה כפרזנטור, פרסום התמונה שלך עם המוצר באתר שלנו וכניסה חינם לאירועים שלנו.", 9);
            yield return new WaitForSeconds(2);
            playMessage();
            chatGame2.addTextMessage(Chat.Direction.RECEIVE, "חוזה מעודכן ישלח בהמשך, תודה רבה על שיתוף הפעולה!", 5);
            yield return new WaitForSeconds(1);
            //אנימציה כל הכבוד
            game4Animation2.SetActive(true);
            displayFinishGame2Screen();
        }
        else if (Game2Try == 0)
        {
            playMessage();
            chatGame2.addTextMessage(Chat.Direction.RECEIVE, "תודה על תשובתך, נשמח לשמוע רעיונות נוספים לתגמולים.", 5);
            Game2Try = 1;
        }
        else
        {
            playMessage();
            chatGame2.addTextMessage(Chat.Direction.RECEIVE, "תודה על השתתפותך, חשבנו גם על התגמולים הבאים: יותר מוצרים מחברה שלנו בחינם, קופונים והנחות לעוקבים, הארכת חוזה לשנה כפרזנטור, פרסום התמונה שלך עם המוצר באתר שלנו וכניסה חינם לאירועים שלנו. ", 8);
            yield return new WaitForSeconds(3);
            playMessage();
            chatGame2.addTextMessage(Chat.Direction.RECEIVE, "במידה ויהיו לך רעיונות נוספים נדון עליהם בהמשך.", 4);
            displayFinishGame2Screen();
        }
    }

    public void displayFinishGame2Screen()
    {
        sendBtnGame2.gameObject.SetActive(false);
        questionGame2.SetActive(false);
        //ביטול כפתור שלח
        //הפעלת כפתור לסיום הצ'אטים
        finishgame2.SetActive(true);
    }

    /// <summary>
    /// לחיצה על כפתורי התמונות בצ'אט ושליחה של תמונה אל הצ'אט
    /// </summary>

    public void tamirHappyPhoto(int mumber)
    {
        StartCoroutine(tamirHappyPhotowaitSeconds(mumber));
    }

    IEnumerator tamirHappyPhotowaitSeconds(int mumber)
    {
        if (mumber == 1)
        {
            chatGame1.addObject(Chat.Direction.SEND, emojiHappy);
            yield return new WaitForSeconds(1);
            playMessage();
            chatGame1.addTextMessage(Chat.Direction.RECEIVE, "אנחנו שמחים שזו התחושה שלכם ושאתם חלק ממשפחתנו!", 2);
        }
        else
        {
            chatGame2.addObject(Chat.Direction.SEND, emojiHappy);
            yield return new WaitForSeconds(1);
            playMessage();
            chatGame2.addTextMessage(Chat.Direction.RECEIVE, "אנחנו שמחים שזו התחושה שלכם ושאתם חלק ממשפחתנו!", 2);
        }

    }



    public void tamirSadPhoto(int number)
    {
        StartCoroutine(tamirSadPhotowaitSeconds(number));
    }

    IEnumerator tamirSadPhotowaitSeconds(int number)
    {
        if (number == 1)
        {
            chatGame1.addObject(Chat.Direction.SEND, emojiSad);
            yield return new WaitForSeconds(1);
            playMessage();
            chatGame1.addTextMessage(Chat.Direction.RECEIVE, "מצטערים לשמוע שככה אתם מרגישים, תמיד תוכלו ללחוץ על הכפתור של תמיר על מנת לבקש עזרה.", 4);
        }
        else
        {
            chatGame2.addObject(Chat.Direction.SEND, emojiSad);
            yield return new WaitForSeconds(1);
            playMessage();
            chatGame2.addTextMessage(Chat.Direction.RECEIVE, "מצטערים לשמוע שככה אתם מרגישים, תמיד תוכלו ללחוץ על הכפתור של תמיר על מנת לבקש עזרה.", 4);
        }
    }

    public void tamirDisgustPhoto(int number)
    {

        StartCoroutine(tamirDisgustPhotowaitSeconds(number));

    }

    IEnumerator tamirDisgustPhotowaitSeconds(int number)
    {
        if (number == 1)
        {
            chatGame1.addObject(Chat.Direction.SEND, emojiLike);
            yield return new WaitForSeconds(1);
            playMessage();
            chatGame1.addTextMessage(Chat.Direction.RECEIVE, "אנחנו שמחים שזו התחושה שלכם.", 2);
        }
        else
        {
            chatGame2.addObject(Chat.Direction.SEND, emojiLike);
            yield return new WaitForSeconds(1);
            playMessage();
            chatGame2.addTextMessage(Chat.Direction.RECEIVE, "אנחנו שמחים שזו התחושה שלכם.", 2);
        }
    }


    public void tamirAngryPhoto(int number)
    {
        StartCoroutine(tamirAngryPhotowaitSeconds(number));
    }

    IEnumerator tamirAngryPhotowaitSeconds(int number)
    {
        if (number == 1)
        {
            chatGame1.addObject(Chat.Direction.SEND, emojiDislike);
            yield return new WaitForSeconds(1);
            playMessage();
            chatGame1.addTextMessage(Chat.Direction.RECEIVE, "מצטערים לשמוע שזו התחושה שלכם. תוכלו להיכנס ללחוץ על הכפתור של תמיר על מנת לבקש עזרה.", 4);
        }
        else
        {
            chatGame2.addObject(Chat.Direction.SEND, emojiDislike);
            yield return new WaitForSeconds(1);
            playMessage();
            chatGame2.addTextMessage(Chat.Direction.RECEIVE, "מצטערים לשמוע שזו התחושה שלכם. תוכלו להיכנס ללחוץ על הכפתור של תמיר על מנת לבקש עזרה.", 4);
        }
    }

    //בלחיצה על כפתור סיום משחק
    public void finishAllGamestory()
    {
        //הפעלת כפתור סטורי
        if (PlayerPrefs.GetInt("GameMax") < 4)
        {
            PlayerPrefs.SetInt("GameMax", 4);
        }

        int myMaxLevel = PlayerPrefs.GetInt("GameMax");
        Debug.Log("Max Level" + myMaxLevel);
        loadStoryBtn.enableStoryBtn(myMaxLevel);
    }

    public void playMessage()
    {
        if (musicOn == "true")
        {
            FindObjectOfType<audioManger4>().Play("receiveMessage");
        }
    }

}