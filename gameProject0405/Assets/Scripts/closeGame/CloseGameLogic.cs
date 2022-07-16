using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CloseGameLogic : MonoBehaviour
{
    public navigation place;
    public navigation chat;
    public navigation user;
    public navigation level1;
    public navigation level2;
    public navigation level3;
    public navigation level4;
    public navigation level5;



    //------>אנימציה תמיר 

    public Animator tamirTTB;
    string musicOn;
    string currentMusic;

    private void Start()
    {
        place.disableBtn();
        chat.disableBtn();
        user.disableBtn();
        level1.enableBtn();
        level2.enableBtn();
        level3.enableBtn();
        level4.enableBtn();
        level5.enableBtn();
        endSentence1();

    }

    public void Checkmusicbtns(string musicBtnName)
    {
        musicOn = PlayerPrefs.GetString("isMusicOn");
        //אם המוזיקה מופעלת
        if (musicOn == "true")
        {
            FindObjectOfType<audioMangerEnd>().stayOn(musicBtnName);
        }
        else
        {
            FindObjectOfType<audioMangerEnd>().stayOff(musicBtnName);
        }
    }


    public void endSentence1()
    {
        tamirTTB.SetBool("isTalk", true);
        currentMusic = "endSentence1";
        Checkmusicbtns(currentMusic);
        FindObjectOfType<audioMangerEnd>().Play("endSentence1");
        FindObjectOfType<audioMangerEnd>().isPlaying("endSentence1");
    }

    public void endSentence2()
    {
        if (currentMusic == "endSentence1")
        {
            stopMusic();
            tamirTTB.SetBool("isTalk", true);
            currentMusic = "endSentence2";
            Checkmusicbtns(currentMusic);
            FindObjectOfType<audioMangerEnd>().Play("endSentence2");
            FindObjectOfType<audioMangerEnd>().isPlaying("endSentence2");
        }
    }

    public void endSentence3()
    {
        if (currentMusic == "endSentence2")
        {
            stopMusic();
            tamirTTB.SetBool("isTalk", true);
            currentMusic = "endSentence3";
            Checkmusicbtns(currentMusic);
            FindObjectOfType<audioMangerEnd>().Play("endSentence3");
            FindObjectOfType<audioMangerEnd>().isPlaying("endSentence3");
        }
    }

    public void endSentence4()
    {
        if (currentMusic == "endSentence3")
        {
            stopMusic();
            tamirTTB.SetBool("isTalk", true);
            currentMusic = "endSentence4";
            Checkmusicbtns(currentMusic);
            FindObjectOfType<audioMangerEnd>().Play("endSentence4");
            FindObjectOfType<audioMangerEnd>().isPlaying("endSentence4");
        }
    }


    public void ClickSoundBtn(string sound)
    {
        FindObjectOfType<audioMangerEnd>().click(sound);
    }

    public void stopMusic()
    {
        string musicName = currentMusic;
        FindObjectOfType<audioMangerEnd>().StopPlaying(musicName);
    }

    public void startOverGame()
    {
        PlayerPrefs.SetInt("gameNumIn", 0);
        PlayerPrefs.SetInt("GameMax", 0);
        SceneManager.LoadScene("Game1");
    }

    public void closeGame()
    {
        SceneManager.LoadScene("menu");
    }

    public void stopTamirTalk()
    {
        tamirTTB.SetBool("isTalk", false);

    }

    public void startTamirTalk()
    {
        tamirTTB.SetBool("isTalk", true);

    }

}
