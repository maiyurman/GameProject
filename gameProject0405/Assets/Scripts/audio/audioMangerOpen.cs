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
        openGameUi = transform.gameObject.GetComponent<openGameUi>();

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

        s.source.Stop();
    }

    public void click(string sound)
    {
        sound s = Array.Find(sounds, item => item.name == sound);
        if (s.source.volume == 0)
        {
            s.source.volume = 1;
            PlayerPrefs.SetString("isMusicOn", "true");
            TamirSound.enableBtn();
        }
        else
        {
            s.source.volume = 0;
            PlayerPrefs.SetString("isMusicOn", "false");
            TamirSound.notMusic();
        }
    }

    public void stayOn(string sound)
    {
        PlayerPrefs.SetString("isMusicOn", "true");
        sound s = Array.Find(sounds, item => item.name == sound);
        s.source.volume = 1;
        TamirSound.enableBtn();
    }

    public void stayOff(string sound)
    {
        PlayerPrefs.SetString("isMusicOn", "false");
        sound s = Array.Find(sounds, item => item.name == sound);
        s.source.volume = 0;
        TamirSound.notMusic();
    }

    public void isPlaying(string sound)
    {
        sound s = Array.Find(sounds, item => item.name == sound);
        Invoke(sound, s.clip.length);
    }

    public void openSentence1()
    {
        Debug.Log("дсаерг 1 рвош");
        openGameUi.sentence2tamir();
    }

    public void openSentence2()
    {
        Debug.Log("дсаерг 2 рвош");
        openGameUi.sentence3tamir();
    }

    public void openSentence3()
    {
        Debug.Log("дсаерг 3 рвош");
        openGameUi.sentence4tamir();
    }

    public void openSentence4()
    {
        Debug.Log("дсаерг 4 рвош");
        openGameUi.sentence5tamir();
    }

    public void openSentence5()
    {
        Debug.Log("дсаерг 5 рвош");
        openGameUi.sentence6tamir();
    }

    public void openSentence6()
    {
        Debug.Log("дсаерг 6 рвош");
        openGameUi.sentence7tamir();
    }

    public void openSentence7()
    {
        Debug.Log("дсаерг 7 рвош");
        openGameUi.sentence8tamir();
    }

    public void openSentence8()
    {
        Debug.Log("дсаерг 8 рвош");
        openGameUi.sentence9tamir();
    }

    public void openSentence9()
    {
        Debug.Log("дсаерг 9 рвош");
        openGameUi.sentence10tamir();
    }

    public void openSentence10()
    {
        Debug.Log("дсаерг 10 рвош");
        openGameUi.sentence11tamir();
    }

    public void openSentence11()
    {
        Debug.Log("дсаерг 11 рвош");
        openGameUi.sentence12tamir();
    }

    public void openSentence12()
    {
        Debug.Log("дсаерг 12 рвош");
        openGameUi.sentence13tamir();
    }

    public void openSentence13()
    {
        Debug.Log("дсаерг 13 рвош");
        openGameUi.sentence14tamir();
    }

    public void openSentence14()
    {
        Debug.Log("дсаерг 14 рвош");
        openGameUi.sentence15tamir();
    }

    public void openSentence15()
    {
        Debug.Log("дсаерг 15 рвош");
        openGameUi.sentence16tamir();
    }

    public void openSentence16()
    {
        Debug.Log("дсаерг 16 рвош");
        openGameUi.sentence17tamir();
    }

    public void openSentence17()
    {
        Debug.Log("дсаерг 17 рвош");
        openGameUi.sentence18tamir();
    }

    public void openSentence18()
    {
        Debug.Log("дсаерг 18 рвош");
        openGameUi.finishTalk();
    }
}
