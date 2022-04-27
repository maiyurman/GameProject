using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadStoryBtn : MonoBehaviour
{
    public navigation[] storyBtns;

    public void clickStory1()
    {
        ChangeScene(1);
    }

    public void clickStory2()
    {
        ChangeScene(2);
    }
    public void clickStory3()
    {
        ChangeScene(3);
    }
    public void clickStory4()
    {
        ChangeScene(4);
    }
    public void clickStory5()
    {
        ChangeScene(5);
    }

    public void ChangeScene(int numGame)
    {
        PlayerPrefs.SetInt("gameNumIn", numGame);
        SceneManager.LoadScene("stories");
    }

    //הפעלת כפתורי סטורי
    public void EnableStoryBtnsForLevel(int numOfLevel)
    {
        for (int i = 1; i <= numOfLevel; i++)
        {
                enableStoryBtn(i);
        }
    }

    //הפעלת כפתור סטורי
    public void enableStoryBtn(int buttonNum)
    {
        PlayerPrefs.SetInt("GameMax", buttonNum);
        storyBtns[buttonNum - 1].enableBtn();
    }

    //כיבוי כל הסטורי
    public void disableStoryBtnAll()
    {
        for (int i = 0;i< 5; i++)
        {
            storyBtns[i].disableBtn();
        }
    }
}
