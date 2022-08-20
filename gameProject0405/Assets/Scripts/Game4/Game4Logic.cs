using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Game4Logic : MonoBehaviour
{
    private Game4UiManager Game4UiManager;
    
    public navigation sendBtnGame2;

    public navigation placeBtn;
    public navigation userBtn;
    public navigation MessageBtn;


    //משתנים משחק 
    public Chat chatGame2;
    string MessageinputGame2;
    public GameObject finishgame2;
    public GameObject questionGame2;
    public TMP_InputField inputGame2;
    public GameObject lightBtn2;

    //סטורי
    private loadStoryBtn loadStoryBtn;

    //אנימציית הצלחה
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

    int isAnswer;


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
        isAnswer = 0;

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

    public void initGame2()
    {
        game4Animation2.SetActive(false);
        finishgame2.SetActive(false);
        MessageinputGame2 = "";
        chatGame2.setChatTitle("petSysaE");
        chatGame2.setProfilePhoto("EasyStep");
        chatGame2.initChat();
    }

   public void sendMessageTochat()
    {
        chatGame2.addTextMessage(Chat.Direction.RECEIVE, "שלום, מדברת ענת מחברת petSysaE, חברת מוצרי טכנולוגיה לשיפור אורח חיים בריא. כדי לקדם את המוצרים שלנו אנחנו משתפים פעולה עם משפיענים שונים.", 8);
        StartCoroutine(sendMessageChat2());
        sendBtnGame2.disableBtn();
    }

    IEnumerator sendMessageChat2()
    {
        yield return new WaitForSeconds(6);
        playMessage();
        chatGame2.addTextMessage(Chat.Direction.RECEIVE, "בגלל שהיינו מאוד מרוצים מהשיתוף פעולה איתך בפעם הקודמת חשוב לנו להמשיך לעבוד יחד.", 5);

        yield return new WaitForSeconds(4);
        playMessage();
        chatGame2.addTextMessage(Chat.Direction.RECEIVE, "על כל ההעלאת פוסט עם מוצר שלנו אנחנו משלמים 000,3 שקלים, הבנו שאתה דורש סכומים גבוהים ולצערי אין לנו את היכולת לשלם לך סכום גבוה יותר. ", 8);


        yield return new WaitForSeconds(5);
        playMessage();
        chatGame2.addTextMessage(Chat.Direction.RECEIVE, "מאחר ומאוד התרשמנו מהפרופיל שלך ומהאופן שבו אתה משווק את המוצרים שלנו, אנחנו נשמח לשמוע ממך איך אתה רוצה שנתגמל אותך במקום?", 6);

        yield return new WaitForSeconds(4);
        playMessage();
        chatGame2.addTextMessage(Chat.Direction.RECEIVE, "משפיענים שונים הציעו לנו כל מיני הצעות כמו: כניסה חינם לאירועים שלנו, מוצרים שלנו בחינם וכדומה. נשמח לשמוע רעיונות נוספים כל הצעה תתקבל בברכה.", 8);
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
        if (isAnswer == 0)
        {
            playMessage();
            chatGame2.addTextMessage(Chat.Direction.RECEIVE, "תודה על תשובתך! נתת לנו רעיונות נוספים, נשמח לשמוע עוד רעיון כדי לבוא עם כמה שיותר פתרונות להנהלה.",5);
            isAnswer = 1;
        }
        else
        {
            playMessage();
            chatGame2.addTextMessage(Chat.Direction.RECEIVE, "מעולה! תודה רבה על הפתרונות שהצעת. נחזור אלייך בהקדם עם ההסכם.",4);
            //אנימציה כל הכבוד
            game4Animation2.SetActive(true);
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
            chatGame2.addObject(Chat.Direction.SEND, emojiHappy);
            yield return new WaitForSeconds(1);
            playMessage();
            chatGame2.addTextMessage(Chat.Direction.RECEIVE, "אנחנו שמחים שזו התחושה שלכם ושאתם חלק ממשפחתנו!", 2);
    }



    public void tamirSadPhoto(int number)
    {
        StartCoroutine(tamirSadPhotowaitSeconds(number));
    }

    IEnumerator tamirSadPhotowaitSeconds(int number)
    {
            chatGame2.addObject(Chat.Direction.SEND, emojiSad);
            yield return new WaitForSeconds(1);
            playMessage();
            chatGame2.addTextMessage(Chat.Direction.RECEIVE, "מצטערים לשמוע שככה אתם מרגישים, תמיד תוכלו ללחוץ על הכפתור של תמיר על מנת לבקש עזרה.", 4);
        
    }

    public void tamirDisgustPhoto(int number)
    {

        StartCoroutine(tamirDisgustPhotowaitSeconds(number));

    }

    IEnumerator tamirDisgustPhotowaitSeconds(int number)
    {      
            chatGame2.addObject(Chat.Direction.SEND, emojiLike);
            yield return new WaitForSeconds(1);
            playMessage();
            chatGame2.addTextMessage(Chat.Direction.RECEIVE, "אנחנו שמחים שזו התחושה שלכם.", 2);
        
    }


    public void tamirAngryPhoto(int number)
    {
        StartCoroutine(tamirAngryPhotowaitSeconds(number));
    }

    IEnumerator tamirAngryPhotowaitSeconds(int number)
    {
            chatGame2.addObject(Chat.Direction.SEND, emojiDislike);
            yield return new WaitForSeconds(1);
            playMessage();
            chatGame2.addTextMessage(Chat.Direction.RECEIVE, "מצטערים לשמוע שזו התחושה שלכם. תוכלו להיכנס ללחוץ על הכפתור של תמיר על מנת לבקש עזרה.", 4);
        
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