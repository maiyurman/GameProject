using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class loadStoryBtn : MonoBehaviour
{
    public navigation[] storyBtns;
    public GameObject controleWindow;
    private int storyPressNum;

    public void pressYes()
    {
        ChangeScene(storyPressNum);
    }

    public void closeControleWindow()
    {
        controleWindow.SetActive(false);
    }
    public void clickStory1()
    {
        controleWindow.SetActive(true);
        storyPressNum = 1;
    }

    public void clickStory2()
    {
        controleWindow.SetActive(true);
        storyPressNum = 2;
    }
    public void clickStory3()
    {
        controleWindow.SetActive(true);
        storyPressNum = 3;
    }
    public void clickStory4()
    {
        controleWindow.SetActive(true);
        storyPressNum = 4;
    }
    public void clickStory5()
    {
        controleWindow.SetActive(true);
        storyPressNum = 5;
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
        Debug.Log("enableStoryBtn" + PlayerPrefs.GetInt("GameMax"));
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
