using UnityEngine.Audio;
using System;
using UnityEngine;

public class audioManger3 : MonoBehaviour
{
    public sound[] sounds;

    public static audioManger3 instance;

    public navgationFor2 sentence1;
    public navgationFor2 sentence2;
    public navgationFor2 sentence3;
    public navgationFor2 sentence4;

    private Game3Logic Game3Logic;

    void Start()
    {
        Game3Logic = GameObject.Find("GameManager").GetComponent<Game3Logic>();

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
            PlayerPrefs.SetString("isMusicOn", "true");
            s.source.volume = 1;

            if (sound == "stage3Sentence1")
            {
                sentence1.enableBtn();
            }
            else if (sound == "stage3Sentence2")
            {
                sentence2.enableBtn();
            }
            else if (sound == "stage3Sentence3")
            {
                sentence3.enableBtn();
            }
            else if (sound == "stage3Sentence4")
            {
                sentence4.enableBtn();
            }
        }
        else
        {
            s.source.volume = 0;
            PlayerPrefs.SetString("isMusicOn", "false");

            if (sound == "stage3Sentence1")
            {
                sentence1.notMusic();
            }
            else if (sound == "stage3Sentence2")
            {
                sentence2.notMusic();
            }
            else if (sound == "stage3Sentence3")
            {
                sentence3.notMusic();
            }
            else if (sound == "stage3Sentence4")
            {
                sentence4.notMusic();
            }
        }
    }

    public void stayOn(string sound)
    {
        sound s = Array.Find(sounds, item => item.name == sound);
        s.source.volume = 1;
        PlayerPrefs.SetString("isMusicOn", "true");

        if (sound == "stage3Sentence1")
        {
            sentence1.enableBtn();
        }
        else if (sound == "stage3Sentence2")
        {
            sentence2.enableBtn();
        }
        else if (sound == "stage3Sentence3")
        {
            sentence3.enableBtn();
        }
        else if (sound == "stage3Sentence4")
        {
            sentence4.enableBtn();
        }
    }

    public void stayOff(string sound)
    {
        sound s = Array.Find(sounds, item => item.name == sound);
        s.source.volume = 0;
        PlayerPrefs.SetString("isMusicOn", "false");

        if (sound == "stage3Sentence1")
        {
            sentence1.notMusic();
        }
        else if (sound == "stage3Sentence2")
        {
            sentence2.notMusic();
        }
        else if (sound == "stage3Sentence3")
        {
            sentence3.notMusic();
        }
        else if (sound == "stage3Sentence4")
        {
            sentence4.notMusic();
        }
    }

    public void isPlaying(string sound)
    {
        sound s = Array.Find(sounds, item => item.name == sound);
        Invoke(sound, s.clip.length);
    }


    /// <summary>
    /// משפטי סאונד בועיות
    /// </summary>

    public void stage3Sentence1()
    {
        Game3Logic.tamir.SetBool("isTalk", false);
    }

    public void stage3Sentence2()
    {
        Game3Logic.tamir.SetBool("isTalk", false);
    }

    public void stage3Sentence3()
    {
        Game3Logic.tamir.SetBool("isTalk", false);
    }

    public void stage3Sentence4()
    {
        Game3Logic.tamir.SetBool("isTalk", false);
        Debug.Log("tamirFinishSentence4");
    }


}