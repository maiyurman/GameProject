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



    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }


        foreach(sound s in sounds)
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

            if (sound == "tamarRecord")
            {
                tamarSound.enableBtn();

            }
            else if (sound == "orRecord")
            {
                orSound.enableBtn();

            }
            else if (sound == "emaRecord")
            {
                emaSound.enableBtn();
            }
            else if (sound == "stage1Sentence1")
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
        }
        else
        {
            s.source.volume = 0;

            if (sound == "tamarRecord")
            {
                tamarSound.notMusic();
            }
            else if (sound == "orRecord")
            {
                orSound.notMusic();
            }
            else if (sound == "emaRecord")
            {
                emaSound.notMusic();
            }
            else if (sound == "stage1Sentence1")
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
        }
    }


}
