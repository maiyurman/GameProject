using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class audioMangerOpen : MonoBehaviour
{
    public sound[] sounds;

    public static audioMangerOpen instance;

    public navgationFor2 TamirSound;

    private openGameUi openGameUi;


    void Start()
    {
        openGameUi = GameObject.Find("GameManager").GetComponent<openGameUi>();

    }
    void Awake()
    {

        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }


        foreach (sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Play(string name)
    {
        sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }

    public void StopPlaying(string sound)
    {
        sound s = Array.Find(sounds, item => item.name == sound);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        string btn = "openSentence";
        for (int i = 1; i < 19; i++)
        {
            string number = i.ToString();
            string thebtn = btn + i;
            sound myBtn = Array.Find(sounds, item => item.name == thebtn);
            myBtn.source.Stop();
        }
    }

    public void click(string sound)
    {
        sound s = Array.Find(sounds, item => item.name == sound);
        if (s.source.volume == 0)
        {
            s.source.volume = 1;
            PlayerPrefs.SetString("isMusicOn", "true");
            string btn = "openSentence";
            for (int i = 1; i < 19; i++)
            {
                string number = i.ToString();
                string thebtn = btn + i;
                sound myBtn = Array.Find(sounds, item => item.name == thebtn);
                myBtn.source.volume = 1;
            }
            TamirSound.enableBtn();
        }
        else
        {
            s.source.volume = 0;
            PlayerPrefs.SetString("isMusicOn", "false");
            string btn = "openSentence";
            for (int i = 1; i < 19; i++)
            {
                string number = i.ToString();
                string thebtn = btn + i;
                sound myBtn = Array.Find(sounds, item => item.name == thebtn);
                myBtn.source.volume = 0;
            }
            TamirSound.notMusic();
        }
    }

    public void Pause(string sound)
    {
        sound s = Array.Find(sounds, sound => sound.name == name);
        Debug.Log("s " + s);
        s.source.Pause();
    }

    public void NotPause(string sound)
    {
        sound s = Array.Find(sounds, sound => sound.name == name);
        Debug.Log("s " + s);
        s.source.UnPause();
    }

    public void stayOn()
    {
        PlayerPrefs.SetString("isMusicOn", "true");
        string btn = "openSentence";
        for (int i = 1; i < 19; i++)
        {
            string number = i.ToString();
            string thebtn = btn + i;
            sound myBtn = Array.Find(sounds, item => item.name == thebtn);
            myBtn.source.volume = 1;
        }
        TamirSound.enableBtn();
    }

    public void stayOff()
    {
        PlayerPrefs.SetString("isMusicOn", "false");
        string btn = "openSentence";
        for (int i = 1; i < 19; i++)
        {
            string number = i.ToString();
            string thebtn = btn + i;
            sound myBtn = Array.Find(sounds, item => item.name == thebtn);
            myBtn.source.volume = 0;
        }
        TamirSound.notMusic();
    }

    public void isPlaying(string sound)
    {
        sound s = Array.Find(sounds, item => item.name == sound);
        Invoke(sound, s.clip.length);
    }

    public void openSentence1()
    {
        openGameUi.sentence2tamir();
    }

    public void openSentence2()
    {
        openGameUi.sentence3tamir();
    }

    public void openSentence3()
    {
        openGameUi.sentence4tamir();
    }

    public void openSentence4()
    {
        openGameUi.sentence5tamir();
    }

    public void openSentence5()
    {
        openGameUi.sentence6tamir();
    }

    public void openSentence6()
    {
        openGameUi.sentence7tamir();
    }

    public void openSentence7()
    {
        openGameUi.sentence8tamir();
    }

    public void openSentence8()
    {
        openGameUi.sentence9tamir();
    }

    public void openSentence9()
    {
        openGameUi.sentence10tamir();
    }

    public void openSentence10()
    {
        openGameUi.sentence11tamir();
    }

    public void openSentence11()
    {
        openGameUi.sentence12tamir();
    }

    public void openSentence12()
    {
        openGameUi.sentence13tamir();
    }

    public void openSentence13()
    {
        openGameUi.sentence14tamir();
    }

    public void openSentence14()
    {
        openGameUi.sentence15tamir();
    }

    public void openSentence15()
    {
        openGameUi.sentence16tamir();
    }

    public void openSentence16()
    {
        openGameUi.sentence17tamir();
    }

    public void openSentence17()
    {
        openGameUi.sentence18tamir();
    }

    public void openSentence18()
    {
        openGameUi.finishTalk();
    }
}
