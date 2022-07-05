using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using System;
using UnityEngine;

public class audioMangerOpen : MonoBehaviour
{
    public sound[] sounds;

    public static audioMangerOpen instance;

    public navgationFor2 TamirSound;


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

}
