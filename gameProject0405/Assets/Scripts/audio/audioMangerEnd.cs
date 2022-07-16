using UnityEngine.Audio;
using System;
using UnityEngine;

public class audioMangerEnd : MonoBehaviour
{
    public sound[] sounds;

    public static audioMangerEnd instance;

    public navgationFor2 sentence1;
    public navgationFor2 sentence2;
    public navgationFor2 sentence3;
    public navgationFor2 sentence4;

    CloseGameLogic CloseGameLogic;

    private void Start()
    {
        CloseGameLogic = GameObject.Find("GameManager").GetComponent<CloseGameLogic>();
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

            if (sound == "endSentence1")
            {
                sentence1.enableBtn();
            }
            else if (sound == "endSentence2")
            {
                sentence2.enableBtn();
            }
            else if (sound == "endSentence3")
            {
                sentence3.enableBtn();
            }
            else if (sound == "endSentence4")
            {
                sentence4.enableBtn();
            }
        }
        else
        {
            s.source.volume = 0;
            PlayerPrefs.SetString("isMusicOn", "false");


            if (sound == "endSentence1")
            {
                sentence1.notMusic();
            }
            else if (sound == "endSentence2")
            {
                sentence2.notMusic();
            }
            else if (sound == "endSentence3")
            {
                sentence3.notMusic();
            }
            else if (sound == "endSentence4")
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

        if (sound == "endSentence1")
        {
            sentence1.enableBtn();
        }
        else if (sound == "endSentence2")
        {
            sentence2.enableBtn();
        }
        else if (sound == "endSentence3")
        {
            sentence3.enableBtn();
        }
        else if (sound == "endSentence4")
        {
            sentence4.enableBtn();
        }
    }

    public void stayOff(string sound)
    {
        sound s = Array.Find(sounds, item => item.name == sound);
        s.source.volume = 0;
        PlayerPrefs.SetString("isMusicOn", "false");

        if (sound == "endSentence1")
        {
            sentence1.notMusic();
        }
        else if (sound == "endSentence2")
        {
            sentence2.notMusic();
        }
        else if (sound == "endSentence3")
        {
            sentence3.notMusic();
        }
        else if (sound == "endSentence4")
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

    public void endSentence1()
    {
        CloseGameLogic.tamirTTB.SetBool("isTalk", false);
    }

    public void endSentence2()
    {
        CloseGameLogic.tamirTTB.SetBool("isTalk", false);
    }

    public void endSentence3()
    {
        CloseGameLogic.tamirTTB.SetBool("isTalk", false);
    }

    public void endSentence4()
    {
        CloseGameLogic.tamirTTB.SetBool("isTalk", false);
    }
}
