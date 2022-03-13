using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game1Logic : MonoBehaviour
{

    private Game1UIScript Game1UIScript;
    private string writeOnBtn;


    void Start()
    {
        Game1UIScript = transform.gameObject.GetComponent<Game1UIScript>();
    }
    bool isAnswerTrue = false;
    int numOfTrying = 0;


    public void pressTrueAnswer()
    {
        isAnswerTrue = true;
        writeOnBtn = "את לא מצליחה לנהל את הזמן שלך נכון";
        Game1UIScript.AnswerFeedback(numOfTrying, isAnswerTrue, writeOnBtn);
    }

    public void pressFalseAnswer1()
    {
        writeOnBtn = "החברים שלך לא מרוצים מההתנהגות שלך";
        Game1UIScript.AnswerFeedback(numOfTrying, isAnswerTrue, writeOnBtn);
        tryNumUp();
    }

    public void pressFalseAnswer2()
    {
        writeOnBtn = "הבוס שלך לא מתחשב בך";
        Game1UIScript.AnswerFeedback(numOfTrying, isAnswerTrue, writeOnBtn);
        tryNumUp();
    }

    public void pressFalseAnswer3()
    {
        writeOnBtn = "את לומדת בזמן העבודה";
        Game1UIScript.AnswerFeedback(numOfTrying, isAnswerTrue, writeOnBtn);
        tryNumUp();
    }

    public void tryNumUp()
    {
        if (numOfTrying != 2)
        {
            numOfTrying++;
        }
    }
}