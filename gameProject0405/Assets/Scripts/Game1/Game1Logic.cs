using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game1Logic : MonoBehaviour
{
    //משתנים משחק 1
    private Game1UIScript Game1UIScript;
    public Chat chatGame1;
    private int tryGame1;
    public GameObject finishGame1;

    //משתנים משחק 2
    public Chat chatGame2;
    private int tryGame2;
    public GameObject finishGame2;

    //משתנים משחק 3
    public Chat chatGame3;
    private int tryGame3;
    public GameObject finishGame3;

    //סטורי
    private loadStoryBtn loadStoryBtn;
    bool isAnswerTrue = false;

    void Start()
    {
        loadStoryBtn = transform.gameObject.GetComponent<loadStoryBtn>();
        Game1UIScript = transform.gameObject.GetComponent<Game1UIScript>();

        //משחק 1
        chatGame1.initChat();
        chatGame1.setChatTitle("תמר לוי");
        chatGame1.setProfilePhoto("");
        chatGame1.addVideo(Chat.Direction.RECEIVE, "6", playVideo1);
        tryGame1 = 2;

        //משחק 2
        chatGame2.initChat();
        chatGame2.setChatTitle("אור בן ישי");
        chatGame2.setProfilePhoto("");
        chatGame2.addVideo(Chat.Direction.RECEIVE, "6", playVideo2);
        tryGame2 = 2;

        //משחק 3
        chatGame3.initChat();
        chatGame3.setChatTitle("'אמה דוידוביץ");
        chatGame3.setProfilePhoto("");
        chatGame3.addVideo(Chat.Direction.RECEIVE, "6", playVideo3);
        tryGame3 = 2;

        //כיבוי כל הסטורי
        loadStoryBtn.disableStoryBtnAll();

        //להדליק את הסטורי שרלוונטיים לשלב המקסימלי
        if (PlayerPrefs.GetInt("GameMax") != 0)
        {
            int MaxStage = PlayerPrefs.GetInt("GameMax");
            Debug.Log(MaxStage);
            loadStoryBtn.EnableStoryBtnsForLevel(MaxStage);        
        }
    }

    private void playVideo1()
    {
        Debug.Log("video 1");
    }

    private void playVideo2()
    {
        Debug.Log("video 2");
    }

    private void playVideo3()
    {
        Debug.Log("video 3");
    }


    //------------------------------------------------משחק 1 פידבקים

    public void Game1TrueAnswer()
    {
        isAnswerTrue = true;
        chatGame1.addTextMessage(Chat.Direction.SEND,"את לא מצליחה לנהל את הזמן שלך נכון", 3);
        Game1feedbackforanswers();
    }

    public void Game1FalseAnswer1()
    {
        chatGame1.addTextMessage(Chat.Direction.SEND, "החברים שלך לא מרוצים מההתנהגות שלך", 3);
        Game1feedbackforanswers();
        tryGame1Down();
    }

    public void Game1FalseAnswer2()
    {
        chatGame1.addTextMessage(Chat.Direction.SEND, "הבוס שלך לא מתחשב בך", 3);
        Game1feedbackforanswers();
        tryGame1Down();
    }

    public void Game1FalseAnswer3()
    {
        chatGame1.addTextMessage(Chat.Direction.SEND, "את לומדת בזמן העבודה", 3);
        Game1feedbackforanswers();
        tryGame1Down();
    }

    public void Game1feedbackforanswers()
    {
        if (isAnswerTrue)
        {
            chatGame1.addTextMessage(Chat.Direction.RECEIVE, "ניהול זמן בהחלט יכול לעזור לי להתנהל טוב יותר", 2);
            finishGame1.SetActive(true);
            isAnswerTrue = false;
        }
        else
        {
            if (tryGame1 == 2)
            {
                chatGame1.addTextMessage(Chat.Direction.RECEIVE, ",אני לא בטוחה שזה מקור הבעיה, נסה לבחור באפשרות אחרת", 2);
            }
            else if (tryGame1 == 1)
            {
                chatGame1.addTextMessage(Chat.Direction.RECEIVE, "צפייה חוזרת בסרטון למעלה תעזור לזהות את מקור הבעיה", 2);
            }
            else
            {
                chatGame1.addTextMessage(Chat.Direction.RECEIVE, ".אחרי שחשבתי על זה, הגעתי למסקנה שהבעיה שלי היא בכלל ניהול זמן לא נכון !צפיתי בסרטון שוב ומצאתי את המכנה המשותף אבל תודה על הרצון לעזור", 5);
                finishGame1.SetActive(true);
                isAnswerTrue = false;
            }
        }
    }

    //------------------------------------------------משחק 2 פידבקים

    public void Game2TrueAnswer()
    {
        isAnswerTrue = true;
        chatGame2.addTextMessage(Chat.Direction.SEND, "אתה מתנהג בפזיזות ולא שוקל מילים", 3);
        Game2feedbackforanswers();
    }

    public void Game2FalseAnswer1()
    {
        chatGame2.addTextMessage(Chat.Direction.SEND, "קבעת שיעור נהיגה ארוך מידי", 3);
        Game2feedbackforanswers();
        tryGame2Down();
    }

    public void Game2FalseAnswer2()
    {
        chatGame2.addTextMessage(Chat.Direction.SEND, "ההורים שלך מתנהגים בחוסר סבלנות", 3);
        Game2feedbackforanswers();
        tryGame2Down();
    }

    public void Game2FalseAnswer3()
    {
        chatGame2.addTextMessage(Chat.Direction.SEND, "המורה לנהיגה לא סומך עליך", 3);
        Game2feedbackforanswers();
        tryGame2Down();
    }

    public void Game2feedbackforanswers()
    {
        if (isAnswerTrue)
        {
            chatGame2.addTextMessage(Chat.Direction.RECEIVE, "!נכון, לחשוב לפני שאני פועל יכול לעזור לי, תודה על העזרה", 2);
            finishGame2.SetActive(true);
            isAnswerTrue = false;
        }
        else
        {
            if (tryGame2 == 2)
            {
                chatGame2.addTextMessage(Chat.Direction.RECEIVE, ".אני לא בטוח שזה מקור הבעיה, נסה לבחור באפשרות אחרת", 2);
            }
            else if (tryGame2 == 1)
            {
                chatGame2.addTextMessage(Chat.Direction.RECEIVE, "צפייה חוזרת בסרטון למעלה תעזור לזהות את מקור הבעיה", 2);
            }
            else
            {
                chatGame2.addTextMessage(Chat.Direction.RECEIVE, ".אחרי שחשבתי על זה, הגעתי למסקנה שהבעיה שלי היא שאני פזיז ולא חושב לפני שאני פועל !צפיתי בסרטון שוב ומצאתי את המכנה המשותף אבל תודה על הרצון לעזור", 5);
                finishGame2.SetActive(true);
                isAnswerTrue = false;
            }
        }
    }

    //------------------------------------------------משחק 3 פידבקים

    public void Game3TrueAnswer()
    {
        isAnswerTrue = true;
        chatGame3.addTextMessage(Chat.Direction.SEND, "את נהגת ביהירות בנוגע לקבלה ליחידה", 3);
        Game3feedbackforanswers();
    }

    public void Game3FalseAnswer1()
    {
        chatGame3.addTextMessage(Chat.Direction.SEND, "את לא מוכנה להתפשר על התפקיד", 3);
        Game3feedbackforanswers();
        tryGame3Down();
    }

    public void Game3FalseAnswer2()
    {
        chatGame3.addTextMessage(Chat.Direction.SEND, "המבחנים היו קשים מידי", 3);
        Game3feedbackforanswers();
        tryGame3Down();
    }

    public void Game3FalseAnswer3()
    {
        chatGame3.addTextMessage(Chat.Direction.SEND, "שכחת להתכונן למבחנים", 3);
        Game3feedbackforanswers();
        tryGame3Down();
    }

    public void Game3feedbackforanswers()
    {
        if (isAnswerTrue)
        {
            chatGame3.addTextMessage(Chat.Direction.RECEIVE, "נכון, יש לי נטייה כזו אני צריכה לעבוד על זה! תודה על העזרה", 2);
            finishGame3.SetActive(true);
            isAnswerTrue = false;
        }
        else
        {
            if (tryGame3 == 2)
            {
                chatGame3.addTextMessage(Chat.Direction.RECEIVE, "אני לא בטוחה שזה מקור הבעיה, כדאי לבחור באפשרות אחרת", 2);
            }
            else if (tryGame3 == 1)
            {
                chatGame3.addTextMessage(Chat.Direction.RECEIVE, "צפייה חוזרת בסרטון למעלה תעזור לזהות את מקור הבעיה", 2);
            }
            else
            {
                chatGame3.addTextMessage(Chat.Direction.RECEIVE, ".אחרי שחשבתי על זה, הגעתי למסקנה שהבעיה שלי היא שהייתי יהירה מידי בנוגע לקבלה ליחידה. צפיתי בסרטון שוב ומצאתי את המכנה המשותף אבל תודה על הרצון לעזור", 5);
                finishGame3.SetActive(true);
                isAnswerTrue = false;
            }
        }
    }

    //הורדת מספר ניסיונות כלל המשחקים
    public void tryGame1Down()
    {
        if (tryGame1 != 0)
        {
            tryGame1--;
        }
    }

    public void tryGame2Down()
    {
        if (tryGame2 != 0)
        {
            tryGame2--;
        }
    }

    public void tryGame3Down()
    {
        if (tryGame3 != 0)
        {
            tryGame3--;
        }
    }

    public void finishGame()
    {
        //הפעלת כפתור סטורי
        if (PlayerPrefs.GetInt("GameMax") < 1)
        {
            PlayerPrefs.SetInt("GameMax", 1);
        }
        int myMaxLevel = PlayerPrefs.GetInt("GameMax");
        loadStoryBtn.enableStoryBtn(myMaxLevel);

    }
}