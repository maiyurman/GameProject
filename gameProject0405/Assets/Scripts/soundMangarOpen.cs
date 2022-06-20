using UnityEngine.Audio;
using System;
using UnityEngine;


public class soundMangarOpen : MonoBehaviour
{
    public sound[] sounds;

    public static soundMangarOpen instance;

    public navigation mybuttonTamir;


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
        Debug.Log(name);
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
        if (s.source.volume == 0)
        {
            s.source.volume = numvolume;
            mybuttonTamir.enableBtn();
        }
        else
        {
            s.source.volume = 0;
            mybuttonTamir.disableBtn();
        }
    }
}
