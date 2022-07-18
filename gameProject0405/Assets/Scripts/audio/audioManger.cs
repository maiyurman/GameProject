using UnityEngine.Audio;
using System;
using UnityEngine;

public class audioManger : MonoBehaviour
{
    public sound[] sounds;

    public static audioManger instance;

    public navgationFor2 tamarSound;
    public navgationFor2 orSound;
    public navgationFor2 emaSound;
    public navgationFor2 sentence1;
    public navgationFor2 sentence2;
    public navgationFor2 sentence3;

    private Game1Logic Game1Logic;

    void Start()
    {
        Game1Logic = GameObject.Find("GameManager").GetComponent<Game1Logic>();

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

    public void Pause(string soundName)
    {
        sound currentSound = Array.Find(sounds, s => s.name == soundName);
        Debug.Log("currentSound: " + currentSound.name);
        currentSound.source.Pause();
    }

    public void NotPause(string soundName)
    {
        sound currentSound = Array.Find(sounds, s => s.name == soundName);
        Debug.Log("currentSound: " + currentSound.name);
        currentSound.source.UnPause();
    }

    public void click(string sound)
    {
        sound s = Array.Find(sounds, item => item.name == sound);
        if (s.source.volume == 0)
        {
            s.source.volume = 1;
            PlayerPrefs.SetString("isMusicOn", "true");

            if (sound == "stage1Sentence1")
            {
                sentence1.enableBtn();
            }
            else if (sound == "stage1Sentence2")
            {
                sentence2.enableBtn();
            }
            else if (sound == "stage1Sentence3")
            {
                sentence3.enableBtn();
            }
            else if (sound == "tamarRecord1")
            {
                sound tamarRecord1S = Array.Find(sounds, item => item.name == sound);
                tamarRecord1S.source.volume = 1;
                tamarSound.enableBtn();
            }
            else if (sound == "tamarRecord2")
            {
                sound tamarRecord2S = Array.Find(sounds, item => item.name == sound);
                tamarRecord2S.source.volume = 1;
                tamarSound.enableBtn();

            }
            else if (sound == "tamarRecord3")
            {
                sound tamarRecord3S = Array.Find(sounds, item => item.name == sound);
                tamarRecord3S.source.volume = 1;
                tamarSound.enableBtn();

            }
            else if (sound == "tamarRecord4")
            {
                sound tamarRecord4S = Array.Find(sounds, item => item.name == sound);
                tamarRecord4S.source.volume = 1;
                tamarSound.enableBtn();

            }
            else if (sound == "tamarRecord5")
            {
                sound tamarRecord5S = Array.Find(sounds, item => item.name == sound);
                tamarRecord5S.source.volume = 1;
                tamarSound.enableBtn();

            }
            else if (sound == "tamarRecord6")
            {
                sound tamarRecord6S = Array.Find(sounds, item => item.name == sound);
                tamarRecord6S.source.volume = 1;
                tamarSound.enableBtn();

            }
            else if (sound == "orRecord1")
            {
                sound orRecord1S = Array.Find(sounds, item => item.name == sound);
                orRecord1S.source.volume = 1;
                orSound.enableBtn();

            }
            else if (sound == "orRecord2")
            {
                sound orRecord2S = Array.Find(sounds, item => item.name == sound);
                orRecord2S.source.volume = 1;
                orSound.enableBtn();

            }
            else if (sound == "orRecord3")
            {
                sound orRecord3S = Array.Find(sounds, item => item.name == sound);
                orRecord3S.source.volume = 1;
                orSound.enableBtn();

            }
            else if (sound == "orRecord4")
            {
                sound orRecord4S = Array.Find(sounds, item => item.name == sound);
                orRecord4S.source.volume = 1;
                orSound.enableBtn();

            }
            else if (sound == "orRecord5")
            {
                sound orRecord5S = Array.Find(sounds, item => item.name == sound);
                orRecord5S.source.volume = 1;
                orSound.enableBtn();

            }
            else if (sound == "orRecord6")
            {
                sound orRecord6S = Array.Find(sounds, item => item.name == sound);
                orRecord6S.source.volume = 1;
                orSound.enableBtn();
            }
            else if (sound == "emaRecord1")
            {
                sound emaRecord1S = Array.Find(sounds, item => item.name == sound);
                emaRecord1S.source.volume = 1;
                emaSound.enableBtn();

            }
            else if (sound == "emaRecord2")
            {
                sound emaRecord2S = Array.Find(sounds, item => item.name == sound);
                emaRecord2S.source.volume = 1;
                emaSound.enableBtn();
            }
            else if (sound == "emaRecord3")
            {
                sound emaRecord3S = Array.Find(sounds, item => item.name == sound);
                emaRecord3S.source.volume = 1;
                emaSound.enableBtn();

            }
            else if (sound == "emaRecord4")
            {
                sound emaRecord4S = Array.Find(sounds, item => item.name == sound);
                emaRecord4S.source.volume = 1;
                emaSound.enableBtn();
            }
        }
        else
        {
            s.source.volume = 0;
            PlayerPrefs.SetString("isMusicOn", "false");
            if (sound == "stage1Sentence1")
            {
                sentence1.notMusic();
            }
            else if (sound == "stage1Sentence2")
            {
                sentence2.notMusic();
            }
            else if (sound == "stage1Sentence3")
            {
                sentence3.notMusic();
            }
            else if (sound == "tamarRecord1")
            {
                sound tamarRecord1S = Array.Find(sounds, item => item.name == sound);
                tamarRecord1S.source.volume = 0;
                tamarSound.notMusic();
            }
            else if (sound == "tamarRecord2")
            {
                sound tamarRecord2S = Array.Find(sounds, item => item.name == sound);
                tamarRecord2S.source.volume = 0;
                tamarSound.notMusic();
            }
            else if (sound == "tamarRecord3")
            {
                sound tamarRecord3S = Array.Find(sounds, item => item.name == sound);
                tamarRecord3S.source.volume = 0;
                tamarSound.notMusic();
            }
            else if (sound == "tamarRecord4")
            {
                sound tamarRecord4S = Array.Find(sounds, item => item.name == sound);
                tamarRecord4S.source.volume = 0;
                tamarSound.notMusic();

            }
            else if (sound == "tamarRecord5")
            {
                sound tamarRecord5S = Array.Find(sounds, item => item.name == sound);
                tamarRecord5S.source.volume = 0;
                tamarSound.notMusic();

            }
            else if (sound == "tamarRecord6")
            {
                sound tamarRecord6S = Array.Find(sounds, item => item.name == sound);
                tamarRecord6S.source.volume = 0;
                tamarSound.notMusic();
            }
            else if (sound == "orRecord1")
            {
                sound orRecord1S = Array.Find(sounds, item => item.name == sound);
                orRecord1S.source.volume = 0;
                orSound.notMusic();
            }
            else if (sound == "orRecord2")
            {
                sound orRecord2S = Array.Find(sounds, item => item.name == sound);
                orRecord2S.source.volume = 0;
                orSound.notMusic();
            }
            else if (sound == "orRecord3")
            {
                sound orRecord3S = Array.Find(sounds, item => item.name == sound);
                orRecord3S.source.volume = 0;
                orSound.notMusic();
            }
            else if (sound == "orRecord4")
            {
                sound orRecord4S = Array.Find(sounds, item => item.name == sound);
                orRecord4S.source.volume = 0;
                orSound.notMusic();
            }
            else if (sound == "orRecord5")
            {
                sound orRecord5S = Array.Find(sounds, item => item.name == sound);
                orRecord5S.source.volume = 0;
                orSound.notMusic();
            }
            else if (sound == "orRecord6")
            {
                sound orRecord6S = Array.Find(sounds, item => item.name == sound);
                orRecord6S.source.volume = 0;
                emaSound.notMusic();
            }
            else if (sound == "emaRecord1")
            {
                sound emaRecord1S = Array.Find(sounds, item => item.name == sound);
                emaRecord1S.source.volume = 0;
                emaSound.notMusic();
            }
            else if (sound == "emaRecord2")
            {
                sound emaRecord2S = Array.Find(sounds, item => item.name == sound);
                emaRecord2S.source.volume = 0;
                emaSound.notMusic();
            }
            else if (sound == "emaRecord3")
            {
                sound emaRecord3S = Array.Find(sounds, item => item.name == sound);
                emaRecord3S.source.volume = 0;
                emaSound.notMusic();
            }
            else if (sound == "emaRecord4")
            {
                sound emaRecord4S = Array.Find(sounds, item => item.name == sound);
                emaRecord4S.source.volume = 0;
                emaSound.notMusic();

            }
        }
    }

    public void stayOn(string sound)
    {
        Debug.Log("stayOn " + sound);
        sound s = Array.Find(sounds, item => item.name == sound);
        s.source.volume = 1;
        PlayerPrefs.SetString("isMusicOn", "true");
        if (sound == "stage1Sentence1")
        {
            sentence1.enableBtn();
        }
        else if (sound == "stage1Sentence2")
        {
            sentence2.enableBtn();
        }
        else if (sound == "stage1Sentence3")
        {
            sentence3.enableBtn();
        }
        else if (sound == "tamarRecord1")
        {
            sound tamarRecord1S = Array.Find(sounds, item => item.name == sound);
            tamarRecord1S.source.volume = 1;
            tamarSound.enableBtn();
        }
        else if (sound == "tamarRecord2")
        {
            sound tamarRecord2S = Array.Find(sounds, item => item.name == sound);
            tamarRecord2S.source.volume = 1;
            tamarSound.enableBtn();

        }
        else if (sound == "tamarRecord3")
        {
            sound tamarRecord3S = Array.Find(sounds, item => item.name == sound);
            tamarRecord3S.source.volume = 1;
            tamarSound.enableBtn();

        }
        else if (sound == "tamarRecord4")
        {
            sound tamarRecord4S = Array.Find(sounds, item => item.name == sound);
            tamarRecord4S.source.volume = 1;
            tamarSound.enableBtn();

        }
        else if (sound == "tamarRecord5")
        {
            sound tamarRecord5S = Array.Find(sounds, item => item.name == sound);
            tamarRecord5S.source.volume = 1;
            tamarSound.enableBtn();

        }
        else if (sound == "tamarRecord6")
        {
            sound tamarRecord6S = Array.Find(sounds, item => item.name == sound);
            tamarRecord6S.source.volume = 1;
            tamarSound.enableBtn();

        }
        else if (sound == "orRecord1")
        {
            sound orRecord1S = Array.Find(sounds, item => item.name == sound);
            orRecord1S.source.volume = 1;
            orSound.enableBtn();

        }
        else if (sound == "orRecord2")
        {
            sound orRecord2S = Array.Find(sounds, item => item.name == sound);
            orRecord2S.source.volume = 1;
            orSound.enableBtn();

        }
        else if (sound == "orRecord3")
        {
            sound orRecord3S = Array.Find(sounds, item => item.name == sound);
            orRecord3S.source.volume = 1;
            orSound.enableBtn();

        }
        else if (sound == "orRecord4")
        {
            sound orRecord4S = Array.Find(sounds, item => item.name == sound);
            orRecord4S.source.volume = 1;
            orSound.enableBtn();

        }
        else if (sound == "orRecord5")
        {
            sound orRecord5S = Array.Find(sounds, item => item.name == sound);
            orRecord5S.source.volume = 1;
            orSound.enableBtn();

        }
        else if (sound == "orRecord6")
        {
            sound orRecord6S = Array.Find(sounds, item => item.name == sound);
            orRecord6S.source.volume = 1;
            orSound.enableBtn();
        }
        else if (sound == "emaRecord1")
        {
            sound emaRecord1S = Array.Find(sounds, item => item.name == sound);
            emaRecord1S.source.volume = 1;
            emaSound.enableBtn();

        }
        else if (sound == "emaRecord2")
        {
            sound emaRecord2S = Array.Find(sounds, item => item.name == sound);
            emaRecord2S.source.volume = 1;
            emaSound.enableBtn();
        }
        else if (sound == "emaRecord3")
        {
            sound emaRecord3S = Array.Find(sounds, item => item.name == sound);
            emaRecord3S.source.volume = 1;
            emaSound.enableBtn();

        }
        else if (sound == "emaRecord4")
        {
            sound emaRecord4S = Array.Find(sounds, item => item.name == sound);
            emaRecord4S.source.volume = 1;
            emaSound.enableBtn();
        }

    }

    public void stayOff(string sound)
    {
        Debug.Log("stayOff " + sound);
        sound s = Array.Find(sounds, item => item.name == sound);
        s.source.volume = 0;
        PlayerPrefs.SetString("isMusicOn", "false");

        if (sound == "stage1Sentence1")
        {
            sentence1.notMusic();
        }
        else if (sound == "stage1Sentence2")
        {
            sentence2.notMusic();
        }
        else if (sound == "stage1Sentence3")
        {
            sentence3.notMusic();
        }
        else if (sound == "tamarRecord1")
        {
            sound tamarRecord1S = Array.Find(sounds, item => item.name == sound);
            tamarRecord1S.source.volume = 0;
            tamarSound.notMusic();
        }
        else if (sound == "tamarRecord2")
        {
            sound tamarRecord2S = Array.Find(sounds, item => item.name == sound);
            tamarRecord2S.source.volume = 0;
            tamarSound.notMusic();
        }
        else if (sound == "tamarRecord3")
        {
            sound tamarRecord3S = Array.Find(sounds, item => item.name == sound);
            tamarRecord3S.source.volume = 0;
            tamarSound.notMusic();
        }
        else if (sound == "tamarRecord4")
        {
            sound tamarRecord4S = Array.Find(sounds, item => item.name == sound);
            tamarRecord4S.source.volume = 0;
            tamarSound.notMusic();

        }
        else if (sound == "tamarRecord5")
        {
            sound tamarRecord5S = Array.Find(sounds, item => item.name == sound);
            tamarRecord5S.source.volume = 0;
            tamarSound.notMusic();

        }
        else if (sound == "tamarRecord6")
        {
            sound tamarRecord6S = Array.Find(sounds, item => item.name == sound);
            tamarRecord6S.source.volume = 0;
            tamarSound.notMusic();
        }
        else if (sound == "orRecord1")
        {
            sound orRecord1S = Array.Find(sounds, item => item.name == sound);
            orRecord1S.source.volume = 0;
            orSound.notMusic();
        }
        else if (sound == "orRecord2")
        {
            sound orRecord2S = Array.Find(sounds, item => item.name == sound);
            orRecord2S.source.volume = 0;
            orSound.notMusic();
        }
        else if (sound == "orRecord3")
        {
            sound orRecord3S = Array.Find(sounds, item => item.name == sound);
            orRecord3S.source.volume = 0;
            orSound.notMusic();
        }
        else if (sound == "orRecord4")
        {
            sound orRecord4S = Array.Find(sounds, item => item.name == sound);
            orRecord4S.source.volume = 0;
            orSound.notMusic();
        }
        else if (sound == "orRecord5")
        {
            sound orRecord5S = Array.Find(sounds, item => item.name == sound);
            orRecord5S.source.volume = 0;
            orSound.notMusic();
        }
        else if (sound == "orRecord6")
        {
            sound orRecord6S = Array.Find(sounds, item => item.name == sound);
            orRecord6S.source.volume = 0;
            emaSound.notMusic();
        }
        else if (sound == "emaRecord1")
        {
            sound emaRecord1S = Array.Find(sounds, item => item.name == sound);
            emaRecord1S.source.volume = 0;
            emaSound.notMusic();
        }
        else if (sound == "emaRecord2")
        {
            sound emaRecord2S = Array.Find(sounds, item => item.name == sound);
            emaRecord2S.source.volume = 0;
            emaSound.notMusic();
        }
        else if (sound == "emaRecord3")
        {
            sound emaRecord3S = Array.Find(sounds, item => item.name == sound);
            emaRecord3S.source.volume = 0;
            emaSound.notMusic();
        }
        else if (sound == "emaRecord4")
        {
            sound emaRecord4S = Array.Find(sounds, item => item.name == sound);
            emaRecord4S.source.volume = 0;
            emaSound.notMusic();

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

    public void stage1Sentence1()
    {
        Game1Logic.tamir.SetBool("isTalk", false);
    }

    public void stage1Sentence2()
    {
        Game1Logic.tamir.SetBool("isTalk", false);
    }

    public void stage1Sentence3()
    {
        Game1Logic.tamir.SetBool("isTalk", false);
    }


    /// <summary>
    /// משפטי סאונד סרטון תמר
    /// </summary>

    public void tamarRecord1()
    {
        Game1Logic.tamarRecord2();
    }

    public void tamarRecord2()
    {
        Game1Logic.tamarRecord3();
    }

    public void tamarRecord3()
    {
        Game1Logic.tamarRecord4();
    }

    public void tamarRecord4()
    {
        Game1Logic.tamarRecord5();
    }

    public void tamarRecord5()
    {
        Game1Logic.tamarRecord6();
    }

    public void tamarRecord6()
    {
        Game1Logic.finishtamarRecord6();
    }


    /// <summary>
    /// משפטי סאונד סרטון אור
    /// </summary>

    public void orRecord1()
    {
        Game1Logic.orRecord2();
    }

    public void orRecord2()
    {
        Game1Logic.orRecord3();
    }

    public void orRecord3()
    {
        Game1Logic.orRecord4();
    }

    public void orRecord4()
    {
        Game1Logic.orRecord5();
    }

    public void orRecord5()
    {
        Game1Logic.orRecord6();
    }

    public void orRecord6()
    {
        Game1Logic.finishorRecord6();
    }


    /// <summary>
    /// משפטי סאונד סרטון אמה
    /// </summary>



    public void emaRecord1()
    {
        Game1Logic.emaRecord2();
    }

    public void emaRecord2()
    {
        Game1Logic.emaRecord3();
    }

    public void emaRecord3()
    {
        Game1Logic.emaRecord4();
    }

    public void emaRecord4()
    {
        Game1Logic.finishemaRecord4();
    }

}
