using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Game5DragLogic : MonoBehaviour, i_DragAndDropLogic
{
    private Game5UIManager Game5UIManager;
    public bool isTrueAnswer;

    void Start()
    {
        Game5UIManager = transform.gameObject.GetComponent<Game5UIManager>();
        isTrueAnswer = false;
    }

    public void validateOnRelese(Dragable dragable, DropArea dropArea)
    {
        GameObject correct = GameObject.FindWithTag("correct");
        GameObject notcorrect1 = GameObject.FindWithTag("notcorrect1");
        GameObject notcorrect2 = GameObject.FindWithTag("notcorrect2");

        string correctName = correct.name;
        string notcorrect1Name = notcorrect1.name;
        string notcorrect2Name = notcorrect2.name;


        string mydropArea = dropArea.name;

        //בדיקה אם יש תשובה נכונה או לא
        if (correctName == mydropArea)
        {
            isTrueAnswer = true;
            Game5UIManager.movetoPlace(dragable, dropArea);
        }
        else if(notcorrect1Name == mydropArea)
        {
            Game5UIManager.movetoPlace(dragable, dropArea);
        }
        else if (notcorrect2Name == mydropArea)
        {
            Game5UIManager.movetoPlace(dragable, dropArea);
        }
        else if(Game5UIManager.numRound == 3)
        {
            GameObject notcorrect3 = GameObject.FindWithTag("notcorrect3");
            string notcorrect3Name = notcorrect3.name;
            if (notcorrect3Name == mydropArea)
            {
                Game5UIManager.movetoPlace(dragable, dropArea);
            }
        }
    }

}
