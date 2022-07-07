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
        Debug.Log("������ 1 ����");
        openGameUi.sentence2tamir();
    }

    public void openSentence2()
    {
        Debug.Log("������ 2 ����");
        openGameUi.sentence3tamir();
    }

    public void openSentence3()
    {
        Debug.Log("������ 3 ����");
        openGameUi.sentence4tamir();
    }

    public void openSentence4()
    {
        Debug.Log("������ 4 ����");
        openGameUi.sentence5tamir();
    }

    public void openSentence5()
    {
        Debug.Log("������ 5 ����");
        openGameUi.sentence6tamir();
    }

    public void openSentence6()
    {
        Debug.Log("������ 6 ����");
        openGameUi.sentence7tamir();
    }

    public void openSentence7()
    {
        Debug.Log("������ 7 ����");
        openGameUi.sentence8tamir();
    }

    public void openSentence8()
    {
        Debug.Log("������ 8 ����");
        openGameUi.sentence9tamir();
    }

    public void openSentence9()
    {
        Debug.Log("������ 9 ����");
        openGameUi.sentence10tamir();
    }

    public void openSentence10()
    {
        Debug.Log("������ 10 ����");
        openGameUi.sentence11tamir();
    }

    public void openSentence11()
    {
        Debug.Log("������ 11 ����");
        openGameUi.sentence12tamir();
    }

    public void openSentence12()
    {
        Debug.Log("������ 12 ����");
        openGameUi.sentence13tamir();
    }

    public void openSentence13()
    {
        Debug.Log("������ 13 ����");
        openGameUi.sentence14tamir();
    }

    public void openSentence14()
    {
        Debug.Log("������ 14 ����");
        openGameUi.sentence15tamir();
    }

    public void openSentence15()
    {
        Debug.Log("������ 15 ����");
        openGameUi.sentence16tamir();
    }

    public void openSentence16()
    {
        Debug.Log("������ 16 ����");
        openGameUi.sentence17tamir();
    }

    public void openSentence17()
    {
        Debug.Log("������ 17 ����");
        openGameUi.sentence18tamir();
    }

    public void openSentence18()
    {
        Debug.Log("������ 18 ����");
        openGameUi.finishTalk();
    }
}
