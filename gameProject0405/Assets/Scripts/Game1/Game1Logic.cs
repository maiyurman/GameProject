using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Game1Logic : MonoBehaviour
{
    //משתנים משחק 1
    private Game1UIScript Game1UIScript;
    public Chat chatGame1;
    private int tryGame1;
    public GameObject finishGame1;
    public GameObject video1;
    public TextMeshProUGUI textVideo1;
    public GameObject trueAnimation1;
    public GameObject questions1;
    public GameObject finishgame1;
    public GameObject subtitleBK1;
    public GameObject lightBtn1;

    //משתנים משחק 2
    public Chat chatGame2;
    private int tryGame2;
    public GameObject finishGame2;
    public GameObject video2;
    public TextMeshProUGUI textVideo2;
    public GameObject trueAnimation2;
    public GameObject questions2;
    public GameObject finishgame2;
    public GameObject subtitleBK2;
    public GameObject lightBtn2;


    //משתנים משחק 3
    public Chat chatGame3;
    private int tryGame3;
    public GameObject finishGame3;
    public GameObject video3;
    public TextMeshProUGUI textVideo3;
    public GameObject trueAnimation3;
    public GameObject questions3;
    public GameObject finishgame3;
    public GameObject subtitleBK3;
    public GameObject lightBtn3;

    //סטורי
    private loadStoryBtn loadStoryBtn;
    bool isAnswerTrue = false;

    //אנימציות
    public Animator orAnimator;
    public Animator tamarAnimator;
    public Animator emaAnimator;
    public Animator tamir;

    public Image sound1;
    public Image sound2;
    public Image sound3;

    string musicOn;
    string currentMusic;
    public navgationFor2 pauseBtn1;
    public navgationFor2 pauseBtn2;
    public navgationFor2 pauseBtn3;


    public static bool GameIsPaused;

    private audioManger audioManger;
    private int currentVideo;

    void Start()
    {
        currentVideo = 0;
        audioManger = GameObject.Find("audioManger").GetComponent<audioManger>();
        loadStoryBtn = transform.gameObject.GetComponent<loadStoryBtn>();
        Game1UIScript = transform.gameObject.GetComponent<Game1UIScript>();
        
        //משחק 1
        chatGame1.initChat();
        chatGame1.setChatTitle("תמר לוי");
        chatGame1.setProfilePhoto("tamar");
        chatGame1.addVideo(Chat.Direction.RECEIVE, "tamarVideoPhotos", playVideo1);
        chatGame1.addTextMessage(Chat.Direction.RECEIVE, "תודה שצפיתם תמיד תוכלו לחזור ולצפות בסרטון שוב כדי לעזור לי", 3);
        tryGame1 = 2;
        video1.SetActive(false);
        textVideo1.text = "";
        trueAnimation1.SetActive(false);
        questions1.SetActive(true);
        finishgame1.SetActive(false);
        subtitleBK1.SetActive(true);

    //משחק 2
    chatGame2.initChat();
        chatGame2.setChatTitle("אור בן ישי");
        chatGame2.setProfilePhoto("or");
        chatGame2.addVideo(Chat.Direction.RECEIVE, "orVideoPhotos", playVideo2);
        chatGame2.addTextMessage(Chat.Direction.RECEIVE, "תודה שצפיתם תמיד תוכלו לחזור ולצפות בסרטון שוב כדי לעזור לי", 3);
        tryGame2 = 2;
        video2.SetActive(false);
        textVideo2.text = "";
        trueAnimation2.SetActive(false);
        questions2.SetActive(true);
        finishgame2.SetActive(false);
        subtitleBK2.SetActive(true);

        //משחק 3
        chatGame3.initChat();
        chatGame3.setChatTitle("אמה דוידוביץ'");
        chatGame3.setProfilePhoto("ema");
        chatGame3.addVideo(Chat.Direction.RECEIVE, "emaVideoPhotos", playVideo3);
        chatGame3.addTextMessage(Chat.Direction.RECEIVE, "תודה שצפיתם תמיד תוכלו לחזור ולצפות בסרטון שוב כדי לעזור לי", 3);
        tryGame3 = 2;
        video3.SetActive(false);
        textVideo3.text = "";
        trueAnimation3.SetActive(false);
        questions3.SetActive(true);
        finishgame3.SetActive(false);
        subtitleBK3.SetActive(true);

        //כיבוי כל הסטורי
        loadStoryBtn.disableStoryBtnAll();

        //להדליק את הסטורי שרלוונטיים לשלב המקסימלי
        if (PlayerPrefs.GetInt("GameMax") != 0)
        {
            int MaxStage = PlayerPrefs.GetInt("GameMax");
            Debug.Log(MaxStage);
            loadStoryBtn.EnableStoryBtnsForLevel(MaxStage);        
        }

        currentMusic = "stage1Sentence1";
        Checkmusicbtns("stage1Sentence1");
        stage1Sentence1();
    }


    public void clickPauseBtn()
    {
        if (GameIsPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    public void Resume()
    {
        Debug.Log("resume");
        if (currentVideo == 1)
        {
            pauseBtn1.enableBtn();

        }
        else if(currentVideo == 2)
        {
            pauseBtn2.enableBtn();

        }
        else if(currentVideo == 3)
        {
            pauseBtn3.enableBtn();

        }
        Time.timeScale = 1f;
        GameIsPaused = false;
        Debug.Log("Resume " + currentMusic);
        audioManger.NotPause(currentMusic);
    }

    public void Pause()
    {
        Debug.Log("pasue");

        if (currentVideo == 1)
        {
            pauseBtn1.notMusic();

        }
        else if (currentVideo == 2)
        {
            pauseBtn2.notMusic();

        }
        else if(currentVideo == 3)
        {
            pauseBtn3.notMusic();

        }
        Time.timeScale = 0f;
        GameIsPaused = true;
        Debug.Log("Pause " + currentMusic);
        audioManger.Pause(currentMusic);
    }

    public void startoverTime()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;

    }

    public void Checkmusicbtns(string musicBtnName)
    {
        musicOn = PlayerPrefs.GetString("isMusicOn");
        Debug.Log("סטטוס מוזיקה" + musicOn);
        //אם המוזיקה מופעלת
        if (musicOn == "true")
        {
            Debug.Log("שם המוזיקה" + musicBtnName);
            FindObjectOfType<audioManger>().stayOn(musicBtnName);
        }
        else
        {
            FindObjectOfType<audioManger>().stayOff(musicBtnName);
        }
    }

    //משפטים סאונד

    public void stage1Sentence1()
    {
            tamir.SetBool("isTalk", true);
            currentMusic = "stage1Sentence1";
            Checkmusicbtns(currentMusic);
            FindObjectOfType<audioManger>().Play("stage1Sentence1");
            FindObjectOfType<audioManger>().isPlaying("stage1Sentence1");
    }

    public void stage1Sentence2()
    {
        if (currentMusic == "stage1Sentence1")
        {
            tamir.SetBool("isTalk", true);
            currentMusic = "stage1Sentence2";
            Checkmusicbtns(currentMusic);
            FindObjectOfType<audioManger>().Play("stage1Sentence2");
            FindObjectOfType<audioManger>().isPlaying("stage1Sentence2");
        }
    }

    public void stage1Sentence3()
    {
            tamir.SetBool("isTalk", true);
            currentMusic = "stage1Sentence3";
            Checkmusicbtns(currentMusic);
            FindObjectOfType<audioManger>().Play("stage1Sentence3");
            FindObjectOfType<audioManger>().isPlaying("stage1Sentence3");
    }


    public void playVideo1()
    {
        video1.SetActive(false);
        video1.SetActive(true);
        Checkmusicbtns("tamarRecord1");
        tamarRecord1();
    }

    public void playVideo2()
    {
        video2.SetActive(false);
        video2.SetActive(true);
        Checkmusicbtns("orRecord1");
        orRecord1();

    }

    public void playVideo3()
    {
        video3.SetActive(false);
        video3.SetActive(true);
        Checkmusicbtns("emaRecord1");
        emaRecord1();

    }


    //-----> וידאו מספר 1


    public void tamarRecord1()
    {
        currentVideo = 1;
        currentMusic = "tamarRecord1";
        tamarAnimator.SetBool("isTalk", true);
        subtitleBK1.SetActive(true);
        Checkmusicbtns(currentMusic);
        textVideo1.text = "היי תמיר, שאלת בזמן האחרון למה נעלמתי" + "\n" + "והחלטתי פשוט לצלם לך סרטון ולתאר מה עבר עלי.";
        FindObjectOfType<audioManger>().Play("tamarRecord1");
        FindObjectOfType<audioManger>().isPlaying("tamarRecord1");
    }

    public void tamarRecord2()
    {
        if (currentMusic == "tamarRecord1")
        {
            currentMusic = "tamarRecord2";
            tamarAnimator.SetBool("isTalk", true);
            subtitleBK1.SetActive(true);
            Checkmusicbtns(currentMusic);
            textVideo1.text = "הרגשתי בזמן האחרון שאין לי זמן לשום דבר.";
            FindObjectOfType<audioManger>().Play("tamarRecord2");
            FindObjectOfType<audioManger>().isPlaying("tamarRecord2");
        }
    }

    public void tamarRecord3()
    {
        if (currentMusic == "tamarRecord2")
        {
            currentMusic = "tamarRecord3";
            tamarAnimator.SetBool("isTalk", true);
            subtitleBK1.SetActive(true);
            Checkmusicbtns(currentMusic);
            textVideo1.text = "אני מנסה לשלב הכל חברים, עבודה, לימודים" + "\n" + "ותמיד אני מוצאת את עצמי מפספסת משהו. כולם תמיד נעלבים ממני.";
            FindObjectOfType<audioManger>().Play("tamarRecord3");
            FindObjectOfType<audioManger>().isPlaying("tamarRecord3");
        }
    }

    public void tamarRecord4()
    {
        if (currentMusic == "tamarRecord3")
        {
            currentMusic = "tamarRecord4";
            tamarAnimator.SetBool("isTalk", true);
            subtitleBK1.SetActive(true);
            Checkmusicbtns(currentMusic);
            textVideo1.text = "שום דבר לא יוצא כמו שאני רוצה.";
            FindObjectOfType<audioManger>().Play("tamarRecord4");
            FindObjectOfType<audioManger>().isPlaying("tamarRecord4");
        }
    }

    public void tamarRecord5()
    {
        if (currentMusic == "tamarRecord4")
        {
            currentMusic = "tamarRecord5";
            tamarAnimator.SetBool("isTalk", true);
            subtitleBK1.SetActive(true);
            Checkmusicbtns(currentMusic);
            textVideo1.text = "בשבוע שעבר, הבוס שלי ביקש ממני לעבוד כל השבוע והיה מבחן ביום רביעי" + "\n" + "אז מצאתי את עצמי לומדת בזמן המשמרת ואז לא התרכזתי לא בעבודה ולא בלימודים.";
            FindObjectOfType<audioManger>().Play("tamarRecord5");
            FindObjectOfType<audioManger>().isPlaying("tamarRecord5");
        }
    }

    public void tamarRecord6()
    {
        if (currentMusic == "tamarRecord5")
        {
            currentMusic = "tamarRecord6";
            tamarAnimator.SetBool("isTalk", true);
            subtitleBK1.SetActive(true);
            Checkmusicbtns(currentMusic);
            textVideo1.text = "אני לא יודעת מה לעשות.. מחכה לתגובה ממך.";
            FindObjectOfType<audioManger>().Play("tamarRecord6");
            FindObjectOfType<audioManger>().isPlaying("tamarRecord6");
        }
    }

    public void finishtamarRecord6()
    {
        tamarAnimator.SetBool("isTalk", false);
        subtitleBK1.SetActive(false);
        Resume();
        stopMusic();
        video1.SetActive(false);
    }


    //-----> וידאו מספר 2

    public void orRecord1()
    {
        currentVideo = 2;
        currentMusic = "orRecord1";
        orAnimator.SetBool("isTalk", true);
        subtitleBK2.SetActive(true);
        Checkmusicbtns(currentMusic);
        textVideo2.text = "היי אחי, השעה 03:11 ירדתי בדיוק מהאוטו של יוסי המורה שלי לנהיגה.";
        FindObjectOfType<audioManger>().Play("orRecord1");
        FindObjectOfType<audioManger>().isPlaying("orRecord1");
    }

    public void orRecord2()
    {
        if (currentMusic == "orRecord1")
        {
            currentMusic = "orRecord2";
            Checkmusicbtns(currentMusic);
            textVideo2.text = "נהגתי כמעט שעה ואפילו עליתי על הכביש המהיר! אתה לא מבין איזה גז דפקתי! ";
            FindObjectOfType<audioManger>().Play("orRecord2");
            FindObjectOfType<audioManger>().isPlaying("orRecord2");
        }
    }

    public void orRecord3()
    {
        if (currentMusic == "orRecord2")
        {
            currentMusic = "orRecord3";
            Checkmusicbtns(currentMusic);
            textVideo2.text = "המורה לנהיגה ממש התעצבן עלי הוא אמר שאני לא יכול לעשות מה שאני רוצה.";
            FindObjectOfType<audioManger>().Play("orRecord3");
            FindObjectOfType<audioManger>().isPlaying("orRecord3");
        }
    }


    public void orRecord4()
    {
        if (currentMusic == "orRecord3")
        {
            currentMusic = "orRecord4";
            Checkmusicbtns(currentMusic);
            textVideo2.text = "אני חייב לחשוב לפני שאני מגיב.";
            FindObjectOfType<audioManger>().Play("orRecord4");
            FindObjectOfType<audioManger>().isPlaying("orRecord4");
        }
    }

    public void orRecord5()
    {
        if (currentMusic == "orRecord4")
        {
            currentMusic = "orRecord5";
            Checkmusicbtns(currentMusic);
            textVideo2.text = "אני לא מבין מה הוא רוצה ממני! גם כשאני רב עם ההורים שלי אני כל קודם מדבר" + "\n" + "ורק אז חושב, אני מרגיש שאני לא מצליח לעצור ולרוב זה פוגע בי ובהם.";
            FindObjectOfType<audioManger>().Play("orRecord5");
            FindObjectOfType<audioManger>().isPlaying("orRecord5");
        }
    }

    public void orRecord6()
    {
        if (currentMusic == "orRecord5")
        {
            currentMusic = "orRecord6";
            Checkmusicbtns(currentMusic);
            textVideo2.text = "אני לא מבין מה הבעיה שלי.";
            FindObjectOfType<audioManger>().Play("orRecord6");
            FindObjectOfType<audioManger>().isPlaying("orRecord6");
        }
    }

    public void finishorRecord6()
    {
        orAnimator.SetBool("isTalk", false);
        subtitleBK2.SetActive(false);
        Resume();
        stopMusic();
        textVideo2.text = "";
        video2.SetActive(false);
    }


    //-----> וידאו מספר 3

    public void emaRecord1()
    {
        currentVideo = 3;
        currentMusic = "emaRecord1";
        orAnimator.SetBool("isTalk", true);
        subtitleBK3.SetActive(true);
        Checkmusicbtns(currentMusic);
        textVideo3.text = "היי תמיר, אתה לא מאמין מה קרה לי?";
        FindObjectOfType<audioManger>().Play("emaRecord1");
        FindObjectOfType<audioManger>().isPlaying("emaRecord1");
    }

    public void emaRecord2()
    {
        if (currentMusic == "emaRecord1")
        {
            currentMusic = "emaRecord2";
            Checkmusicbtns(currentMusic);
            textVideo3.text = "אתה זוכר שסיפרתי לך שאני הולכת למיונים" + "\n" + "ליחידה של 0028 של חיל המודיעין ואני בדוק עוברת?";
            FindObjectOfType<audioManger>().Play("emaRecord2");
            FindObjectOfType<audioManger>().isPlaying("emaRecord2");
        }
    }


    public void emaRecord3()
    {
        if (currentMusic == "emaRecord2")
        {
            currentMusic = "emaRecord3";
            Checkmusicbtns(currentMusic);
            textVideo3.text = "מרוב שהייתי בטוחה בעצמי אפילו לא התכוננתי למבחנים" + "\n" + "וכבר סיפרתי לכולם שבטוח התקבלתי.";
            FindObjectOfType<audioManger>().Play("emaRecord3");
            FindObjectOfType<audioManger>().isPlaying("emaRecord3");
        }
    }

    public void emaRecord4()
    {
        if (currentMusic == "emaRecord3")
        {
            currentMusic = "emaRecord4";
            Checkmusicbtns(currentMusic);
            textVideo3.text = "שובצתי בכלל להיות תצפיתנית, אני לא מבינה איך זה קרה.";
            FindObjectOfType<audioManger>().Play("emaRecord4");
            FindObjectOfType<audioManger>().isPlaying("emaRecord4");
        }
    }


    public void finishemaRecord4()
    {
        emaAnimator.SetBool("isTalk", false);
        Resume();
        stopMusic();
        textVideo3.text = "";
        subtitleBK3.SetActive(false);
        video3.SetActive(false);
    }


    //התחלה מחדש של סרטונים

    public void startOverVideo1()
    {
        video1.SetActive(false);
        video1.SetActive(true);
        Resume();
        stopMusic();
        currentMusic = "tamarRecord1";
        playVideo1();
    }

    public void startOverVideo2()
    {
        video2.SetActive(false);
        video2.SetActive(true);
        Resume();
        stopMusic();
        currentMusic = "orRecord1";
        playVideo2();
    }

    public void startOverVideo3()
    {
        video3.SetActive(false);
        video3.SetActive(true);
        Resume();
        stopMusic();
        currentMusic = "emaRecord1";
        playVideo3();
    }

    public void ClickSoundBtn()
    {
        string sound = currentMusic;
        FindObjectOfType<audioManger>().click(sound);
    }

    public void stopMusic()
    {
        string musicName = currentMusic;
        if (musicName.Contains("tamar") == true)
        {
            string btn = "tamarRecord";
            for (int i = 1; i < 7; i++)
            {
                string number = i.ToString();
                string thebtn = btn + i;
                FindObjectOfType<audioManger>().StopPlaying(thebtn);
            }
        }
        else if (musicName.Contains("orRecord") == true)
        {
            string btn = "orRecord";
            for (int i = 1; i < 7; i++)
            {
                string number = i.ToString();
                string thebtn = btn + i;
                FindObjectOfType<audioManger>().StopPlaying(thebtn);
            }
        }
        else if (musicName.Contains("emaRecord") == true)
        {
            Debug.Log("emalopping");
            string btn = "emaRecord";
            for (int i = 1; i < 5; i++)
            {
                string number = i.ToString();
                string thebtn = btn + i;
                Debug.Log("thebtn "+ thebtn);
                FindObjectOfType<audioManger>().StopPlaying(thebtn);
                Debug.Log("stop the music " + thebtn);
            }
        }
        else
        {
            FindObjectOfType<audioManger>().StopPlaying(musicName);
        }
        currentMusic = "none";
    }




    //------------------------------------------------משחק 1 פידבקים

    public void Game1TrueAnswer()
    {
        isAnswerTrue = true;
        chatGame1.addTextMessage(Chat.Direction.SEND,"את לא מצליחה לנהל את הזמן שלך נכון", 3);
        StartCoroutine(Game1feedbackforanswers());
    }

    public void Game1FalseAnswer1()
    {
        chatGame1.addTextMessage(Chat.Direction.SEND, "החברים שלך לא מרוצים מההתנהגות שלך", 3);
        StartCoroutine(Game1feedbackforanswers());
    }

    public void Game1FalseAnswer2()
    {
        chatGame1.addTextMessage(Chat.Direction.SEND, "הבוס שלך לא מתחשב בך", 3);
        StartCoroutine(Game1feedbackforanswers());
    }

    public void Game1FalseAnswer3()
    {
        chatGame1.addTextMessage(Chat.Direction.SEND, "את לומדת בזמן העבודה", 3);
        StartCoroutine(Game1feedbackforanswers());
    }

    IEnumerator Game1feedbackforanswers()
    {
        yield return new WaitForSeconds(1);
        if (isAnswerTrue)
        {
            if (musicOn == "true")
            {
                FindObjectOfType<audioManger>().Play("receiveMessage");
            }
            chatGame1.addTextMessage(Chat.Direction.RECEIVE, "ניהול זמן בהחלט יכול לעזור לי להתנהל טוב יותר.", 3);
            finishGame1.SetActive(true);
            trueAnimation1.SetActive(true);
            isAnswerTrue = false;
            finishGame1Open();
        }
        else
        {
            if (tryGame1 == 2)
            {
                if (musicOn == "true")
                {
                    FindObjectOfType<audioManger>().Play("receiveMessage");
                }
                chatGame1.addTextMessage(Chat.Direction.RECEIVE, "אני לא בטוחה שזה מקור הבעיה, כדאי לבחור באפשרות אחרת.", 3);
            }
            else if (tryGame1 == 1)
            {
                if (musicOn == "true")
                {
                    FindObjectOfType<audioManger>().Play("receiveMessage");
                }
                chatGame1.addTextMessage(Chat.Direction.RECEIVE, "צפייה חוזרת בסרטון למעלה תעזור לזהות את מקור הבעיה.", 3);
            }
            else
            {
                if (musicOn == "true")
                {
                    FindObjectOfType<audioManger>().Play("receiveMessage");
                }
                chatGame1.addTextMessage(Chat.Direction.RECEIVE, "אחרי שחשבתי על זה, הגעתי למסקנה שהבעיה שלי היא בכלל ניהול זמן לא נכון !צפיתי בסרטון שוב ומצאתי את המכנה המשותף אבל תודה על הרצון לעזור.", 7);
                finishGame1.SetActive(true);
                isAnswerTrue = false;
                finishGame1Open();
            }
            tryGame1Down();
        }
    }

    //------------------------------------------------משחק 2 פידבקים

    public void Game2TrueAnswer()
    {
        isAnswerTrue = true;
        chatGame2.addTextMessage(Chat.Direction.SEND, "אתה מתנהג בפזיזות ולא שוקל מילים", 3);
        StartCoroutine(Game2feedbackforanswers());
    }

    public void Game2FalseAnswer1()
    {
        chatGame2.addTextMessage(Chat.Direction.SEND, "קבעת שיעור נהיגה ארוך מידי", 3);
        StartCoroutine(Game2feedbackforanswers());
    }

    public void Game2FalseAnswer2()
    {
        chatGame2.addTextMessage(Chat.Direction.SEND, "ההורים שלך מתנהגים בחוסר סבלנות", 3);
        StartCoroutine(Game2feedbackforanswers());
    }

    public void Game2FalseAnswer3()
    {
        chatGame2.addTextMessage(Chat.Direction.SEND, "המורה לנהיגה לא סומך עליך", 3);
        StartCoroutine(Game2feedbackforanswers());
    }

    IEnumerator Game2feedbackforanswers()
    {
        yield return new WaitForSeconds(1);
        if (isAnswerTrue)
        {
            if (musicOn == "true")
            {
                FindObjectOfType<audioManger>().Play("receiveMessage");
            }
            chatGame2.addTextMessage(Chat.Direction.RECEIVE, "נכון, לחשוב לפני שאני פועל יכול לעזור לי, תודה על העזרה!", 3);
            finishGame2.SetActive(true);
            trueAnimation2.SetActive(true);
            isAnswerTrue = false;
            finishGame2Open();
        }
        else
        {
            if (tryGame2 == 2)
            {
                if (musicOn == "true")
                {
                    FindObjectOfType<audioManger>().Play("receiveMessage");
                }
                chatGame2.addTextMessage(Chat.Direction.RECEIVE, "אני לא בטוח שזה מקור הבעיה, כדאי לבחור באפשרות אחרת.", 3);
            }
            else if (tryGame2 == 1)
            {
                if (musicOn == "true")
                {
                    FindObjectOfType<audioManger>().Play("receiveMessage");
                }
                chatGame2.addTextMessage(Chat.Direction.RECEIVE, "צפייה חוזרת בסרטון למעלה תעזור לזהות את מקור הבעיה.", 3);
            }
            else
            {
                if (musicOn == "true")
                {
                    FindObjectOfType<audioManger>().Play("receiveMessage");
                }
                chatGame2.addTextMessage(Chat.Direction.RECEIVE, "צפיתי בסרטון שוב ומצאתי את המכנה המשותף, אני צריך לחשוב לפני שאני פועל. אבל תודה על הרצון לעזור.", 5);
                finishGame2.SetActive(true);
                isAnswerTrue = false;
                finishGame2Open();
            }
            tryGame2Down();
        }
    }

    //------------------------------------------------משחק 3 פידבקים

    public void Game3TrueAnswer()
    {
        isAnswerTrue = true;
        chatGame3.addTextMessage(Chat.Direction.SEND, "את נהגת ביהירות בנוגע לקבלה ליחידה", 3);
        StartCoroutine(Game3feedbackforanswers());
    }

    public void Game3FalseAnswer1()
    {
        chatGame3.addTextMessage(Chat.Direction.SEND, "את לא מוכנה להתפשר על התפקיד", 3);
        StartCoroutine(Game3feedbackforanswers());
    }

    public void Game3FalseAnswer2()
    {
        chatGame3.addTextMessage(Chat.Direction.SEND, "המבחנים היו קשים מידי", 3);
        StartCoroutine(Game3feedbackforanswers());
    }

    public void Game3FalseAnswer3()
    {
        chatGame3.addTextMessage(Chat.Direction.SEND, "שכחת להתכונן למבחנים", 3);
       StartCoroutine(Game3feedbackforanswers());
    }

    IEnumerator Game3feedbackforanswers()
    {
        yield return new WaitForSeconds(1);
        if (isAnswerTrue)
        {
            if (musicOn == "true")
            {
                FindObjectOfType<audioManger>().Play("receiveMessage");
            }
            chatGame3.addTextMessage(Chat.Direction.RECEIVE, "נכון, יש לי נטייה כזו אני צריכה לעבוד על זה! תודה על העזרה!", 3);
            finishGame3.SetActive(true);
            trueAnimation3.SetActive(true);
            isAnswerTrue = false;
            finishGame3Open();
        }
        else
        {
            if (tryGame3 == 2)
            {
                if (musicOn == "true")
                {
                    FindObjectOfType<audioManger>().Play("receiveMessage");
                }
                chatGame3.addTextMessage(Chat.Direction.RECEIVE, "אני לא בטוחה שזה מקור הבעיה, כדאי לבחור באפשרות אחרת.", 3);
            }
            else if (tryGame3 == 1)
            {
                if (musicOn == "true")
                {
                    FindObjectOfType<audioManger>().Play("receiveMessage");
                }
                chatGame3.addTextMessage(Chat.Direction.RECEIVE, "צפייה חוזרת בסרטון למעלה תעזור לזהות את מקור הבעיה.", 3);
            }
            else
            {
                if (musicOn == "true")
                {
                    FindObjectOfType<audioManger>().Play("receiveMessage");
                }
                chatGame3.addTextMessage(Chat.Direction.RECEIVE, "אחרי שחשבתי על זה, הגעתי למסקנה שהבעיה שלי היא שהייתי יהירה מידי בנוגע לקבלה ליחידה. צפיתי בסרטון שוב ומצאתי את המכנה המשותף אבל תודה על הרצון לעזור.", 7);
                finishGame3.SetActive(true);
                isAnswerTrue = false;
                finishGame3Open();

            }
            tryGame3Down();
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

    public void finishGame1Open()
    {
        questions1.SetActive(false);
        finishgame1.SetActive(true);
    }

    public void finishGame2Open()
    {
        questions2.SetActive(false);
        finishgame2.SetActive(true);
    }

    public void finishGame3Open()
    {
        questions3.SetActive(false);
        finishgame3.SetActive(true);
    }




}