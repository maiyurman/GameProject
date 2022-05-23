using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game4Logic : MonoBehaviour
{
    private Game4UiManager Game4UiManager;

    //מספרים
    int Game1Try;
    int Game2Try;
    public navigation sendBtnGame1;
    public navigation sendBtnGame2;

    //משתנים משחק 1
    public Chat chatGame1;
    string MessageinputGame1;
    public GameObject finishgame1;

    //משתנים משחק 2
    public Chat chatGame2;
    string MessageinputGame2;
    public GameObject finishgame2;

    //סטורי
    private loadStoryBtn loadStoryBtn;

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

        if (PlayerPrefs.GetInt("GameMax") != 0)
        {
            int MaxStage = PlayerPrefs.GetInt("GameMax");
            Debug.Log(MaxStage);
            loadStoryBtn.EnableStoryBtnsForLevel(MaxStage);
            Debug.Log(MaxStage);
        }
        
        Game4UiManager = transform.gameObject.GetComponent<Game4UiManager>();
    }

    //------------------------------------------------משחק 1 פידבקים

    public void initGame1()
    {
        finishgame1.SetActive(false);
        Game1Try = 0;
        MessageinputGame1 = "";
        chatGame1.setChatTitle("EasyStep");
        chatGame1.setProfilePhoto("EasyStep");
        chatGame1.initChat();
        chatGame1.addTextMessage(Chat.Direction.RECEIVE, " שלום, מדבר מתן מחברת petSyzaE, חברה העוסקת במכירת מוצרי ספורטמהשיחה הקודמת איתך אנחנו יודעים שתתקשה להתחייב לשתף איתנו פעולה במשך שנה שלמה.אנחנו מוכנים לשנות את החוזה לתקופה של חצי שנה אך נשמח שבתמורה תחשוב על מספר שירותים נוספים שתוכל לספק עבורנו בפלטפורמה זו", 11);
    }

    public void updateGame1Message(string Message)
    {
        MessageinputGame1 = Message;
    }

    public void sendMessageToGame1Chat()
    {
        Debug.Log(MessageinputGame1);
        chatGame1.addTextMessage(Chat.Direction.SEND, MessageinputGame1, 3);
        handleGame1Answer(MessageinputGame1);
    }

    public void handleGame1Answer(string answer)
    {
        bool isCorrectAnswer = answer.Contains("תיוג") || answer.Contains("פרסום מוצרים") || answer.Contains("פרסום סרטון המלצה");
        if (isCorrectAnswer)
        {
            chatGame1.addTextMessage(Chat.Direction.RECEIVE, "נשמע פתרון מעולה! חשבנו גם על ההצעות הבאות: תיוג בסטורי פעם בשבוע, פרסום מוצרים בפיד ופרסום סרטון המלצה", 8);
            //אנימציה כל הכבוד
            chatGame1.addTextMessage(Chat.Direction.RECEIVE, " חוזה מעודכן ישלח בהמשך, תודה רבה על שיתוף petSyzaE הפעולה חברת", 5);
            displayFinishGame1Screen();
        } 
        else if (Game1Try == 0)
        {
            chatGame1.addTextMessage(Chat.Direction.RECEIVE, "תודה על תשובתך, נשמח לשמוע על פתרונות נוספים", 5);
            Game1Try = 1;
        } 
        else
        {
            chatGame1.addTextMessage(Chat.Direction.RECEIVE, "תודה על השתתפותך, אנחנו חשבנו על ההצעות הבאות: תיוג בסטורי פעם בשבוע, פרסום מוצרים בפיד, פרסום סרטון המלצה", 5);
            chatGame1.addTextMessage(Chat.Direction.RECEIVE, "petSyzaE חברת .במידה ויהיו לך פתרונות נוספים נדון עליהם בהמשך", 5);
            displayFinishGame1Screen();
        }
    }
    public void displayFinishGame1Screen()
    {
        //ביטול כפתור שלח
        sendBtnGame1.disableBtn();
        //כיבוי תיבת שיחה

        //הפעלת כפתור לסיום הצ'אטים
        finishgame1.SetActive(true);
    }

    //------------------------------------------------משחק 2 פידבקים

    public void initGame2()
    {
        finishgame2.SetActive(false);
        Game2Try = 0;
        MessageinputGame2 = "";
        chatGame2.setChatTitle("BetterLife");
        chatGame2.setProfilePhoto("BetterLife");
        chatGame2.initChat();
        chatGame2.addTextMessage(Chat.Direction.RECEIVE, "שלום, מדברת ענת מחברת efiLretteB, חברת מוצרי טכנולוגיה לשיפור אורח חיים בריא. רציתי לעדכן אותך לגבי שינויי החוזה שלנו. לצערי, אין לנו יכולת לשלם לך יותר מ-3,000 שקלים על כל העלאת פוסט של מוצרי החברה שלנו בפרופיל האישי שלך.מאחר ומאוד התרשמנו מהפרופיל שלך ומהאופן שבו אתה משווק את המוצרים שלנו, אנחנו נשמח לשמוע ממך איך אתה רוצה שנתגמל אותך במקום ? ", 13);
    }

    public void updateGame2Message(string Message)
    {
        MessageinputGame2 = Message;
    }

    public void sendMessageToGame2Chat()
    {
        chatGame2.addTextMessage(Chat.Direction.SEND, MessageinputGame2, 3);
        handleGame2Answer(MessageinputGame2);
    }

    public void handleGame2Answer(string answer)
    {
        bool isCorrectAnswer = answer.Contains("מוצרים") || answer.Contains("הנחות") || answer.Contains("קופונים") || answer.Contains("פרזנטור") || answer.Contains("פרסום") || answer.Contains("אירוע");
        if (isCorrectAnswer)
        {
            chatGame2.addTextMessage(Chat.Direction.RECEIVE, "נשמע פתרון מעולה! חשבנו גם על התגמולים הבאים: יותר מוצרים מחברה שלנו בחינם, קופונים והנחות לעוקבים, הארכת חוזה לשנה כפרזנטור, פרסום התמונה שלך עם המוצר באתר שלנו וכניסה חינם לאירועים שלנו.", 9);
            //אנימציה כל הכבוד
            chatGame2.addTextMessage(Chat.Direction.RECEIVE, " חוזה מעודכן ישלח בהמשך, תודה רבה על שיתוף efiLretteB הפעולה חברת", 5);
            displayFinishGame2Screen();
        }
        else if (Game2Try == 0)
        {
            chatGame2.addTextMessage(Chat.Direction.RECEIVE, "תודה על תשובתך, נשמח לשמוע רעיונות נוספים לתגמולים", 5);
            Game2Try = 1;
        }
        else
        {
            chatGame2.addTextMessage(Chat.Direction.RECEIVE, "תודה על השתתפותך, חשבנו גם על התגמולים הבאים: יותר מוצרים מחברה שלנו בחינם, קופונים והנחות לעוקבים, הארכת חוזה לשנה כפרזנטור, פרסום התמונה שלך עם המוצר באתר שלנו וכניסה חינם לאירועים שלנו. ", 8);
            chatGame2.addTextMessage(Chat.Direction.RECEIVE, "efiLretteB חברת .במידה ויהיו לך רעיונות נוספים נדון עליהם בהמשך", 4);
            displayFinishGame2Screen();
        }
    }

    public void displayFinishGame2Screen()
    {
        //ביטול כפתור שלח
        sendBtnGame2.disableBtn();
        //כיבוי תיבת שיחה

        //הפעלת כפתור לסיום הצ'אטים
        finishgame2.SetActive(true);
    }

    //השהיית משחק 2 שניות
    public IEnumerator seconds()
    {
        yield return new WaitForSeconds(2);
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
}