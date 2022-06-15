using UnityEngine.Audio;
using System;
using UnityEngine;

public class audioManger : MonoBehaviour
{ 
    public sound[] sounds;

    public static audioManger instance;

    public navigation mybutton1;
    public navigation mybutton2;
    public navigation mybutton3;


    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        //DontDestroyOnLoad(gameObject);

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

    public void click(string sound, int numvolume)
    {
        sound s = Array.Find(sounds, item => item.name == sound);
        if(s.source.volume == 0)
        {
            s.source.volume = numvolume;
            if (sound == "tamarRecord")
            {
                mybutton1.enableBtn();

            }
            else if(sound == "orRecord")
            {
                mybutton2.enableBtn();

            }
            else if(sound == "emaRecord")
            {
                mybutton3.enableBtn();
            }
        }
        else
        {
            s.source.volume = 0;

            if (sound == "tamarRecord")
            {
                mybutton1.notMusic();
            }
            else if (sound == "orRecord")
            {
                mybutton2.notMusic();
            }
            else if (sound == "emaRecord")
            {
                mybutton3.notMusic();
            }
        }
    }


}
