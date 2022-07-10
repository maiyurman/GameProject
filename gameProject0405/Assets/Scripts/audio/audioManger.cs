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

        //string btntamar = "tamarRecord";
        //for (int i = 1; i < 7; i++)
        //{
        //    string number = i.ToString();
        //    string thebtn = btntamar + i;
        //    sound myBtn = Array.Find(sounds, item => item.name == thebtn);
        //    myBtn.source.Stop();
        //}
        //string btnor = "orRecord";
        //for (int i = 1; i < 7; i++)
        //{
        //    string number = i.ToString();
        //    string thebtn = btnor + i;
        //    sound myBtn = Array.Find(sounds, item => item.name == thebtn);
        //    myBtn.source.Stop();
        //}
        //string btn = "emaRecord";
        //for (int i = 1; i < 7; i++)
        //{
        //    string number = i.ToString();
        //    string thebtn = btn + i;
        //    sound myBtn = Array.Find(sounds, item => item.name == thebtn);
        //    myBtn.source.Stop();
        //}
    }

    public void click(string sound)
    {
        sound s = Array.Find(sounds, item => item.name == sound);
        if (s.source.volume == 0)
        {
            s.source.volume = 1;
            PlayerPrefs.SetString("isMusicOn","true");

            //string btntamar = "tamarRecord";
            //for (int i = 1; i < 7; i++)
            //{
            //    string number = i.ToString();
            //    string thebtn = btntamar + i;
            //    sound myBtn = Array.Find(sounds, item => item.name == thebtn);
            //    myBtn.source.volume = 1;
            //}
            //string btnor = "orRecord";
            //for (int i = 1; i < 7; i++)
            //{
            //    string number = i.ToString();
            //    string thebtn = btnor + i;
            //    sound myBtn = Array.Find(sounds, item => item.name == thebtn);
            //    myBtn.source.volume = 1;
            //}
            //string btn = "emaRecord";
            //for (int i = 1; i < 7; i++)
            //{
            //    string number = i.ToString();
            //    string thebtn = btn + i;
            //    sound myBtn = Array.Find(sounds, item => item.name == thebtn);
            //    myBtn.source.volume = 1;
            //}
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
            PlayerPrefs.SetString("isMusicOn", "false");
            //string btntamar = "tamarRecord";
            //for (int i = 1; i < 7; i++)
            //{
            //    string number = i.ToString();
            //    string thebtn = btntamar + i;
            //    sound myBtn = Array.Find(sounds, item => item.name == thebtn);
            //    myBtn.source.volume = 0;
            //}
            //string btnor = "orRecord";
            //for (int i = 1; i < 7; i++)
            //{
            //    string number = i.ToString();
            //    string thebtn = btnor + i;
            //    sound myBtn = Array.Find(sounds, item => item.name == thebtn);
            //    myBtn.source.volume = 0;
            //}
            //string btn = "emaRecord";
            //for (int i = 1; i < 7; i++)
            //{
            //    string number = i.ToString();
            //    string thebtn = btn + i;
            //    sound myBtn = Array.Find(sounds, item => item.name == thebtn);
            //    myBtn.source.volume = 0;
            //}
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

    public void stayOn(string sound)
    {
        sound s = Array.Find(sounds, item => item.name == sound);
        s.source.volume = 1;
        PlayerPrefs.SetString("isMusicOn", "true");

        //string btntamar = "tamarRecord";
        //for (int i = 1; i < 7; i++)
        //{
        //    string number = i.ToString();
        //    string thebtn = btntamar + i;
        //    sound myBtn = Array.Find(sounds, item => item.name == thebtn);
        //    myBtn.source.volume = 1;
        //}
        //string btnor = "orRecord";
        //for (int i = 1; i < 7; i++)
        //{
        //    string number = i.ToString();
        //    string thebtn = btnor + i;
        //    sound myBtn = Array.Find(sounds, item => item.name == thebtn);
        //    myBtn.source.volume = 1;
        //}
        //string btn = "emaRecord";
        //for (int i = 1; i < 7; i++)
        //{
        //    string number = i.ToString();
        //    string thebtn = btn + i;
        //    sound myBtn = Array.Find(sounds, item => item.name == thebtn);
        //    myBtn.source.volume = 1;
        //}
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

    public void stayOff(string sound)
    {
        sound s = Array.Find(sounds, item => item.name == sound);
        s.source.volume = 0;
        PlayerPrefs.SetString("isMusicOn", "false");
        //string btntamar = "tamarRecord";
        //for (int i = 1; i < 7; i++)
        //{
        //    string number = i.ToString();
        //    string thebtn = btntamar + i;
        //    sound myBtn = Array.Find(sounds, item => item.name == thebtn);
        //    myBtn.source.volume = 0;
        //}
        //string btnor = "orRecord";
        //for (int i = 1; i < 7; i++)
        //{
        //    string number = i.ToString();
        //    string thebtn = btnor + i;
        //    sound myBtn = Array.Find(sounds, item => item.name == thebtn);
        //    myBtn.source.volume = 0;
        //}
        //string btn = "emaRecord";
        //for (int i = 1; i < 7; i++)
        //{
        //    string number = i.ToString();
        //    string thebtn = btn + i;
        //    sound myBtn = Array.Find(sounds, item => item.name == thebtn);
        //    myBtn.source.volume = 0;
        //}
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

    //public void isPlaying(string sound)
    //{
    //    sound s = Array.Find(sounds, item => item.name == sound);
    //    Invoke(sound, s.clip.length);
    //}

    //public void emaRecord1()
    //{
    //    Debug.Log("дсаерг 1 рвош");
    //    Game1Logic.emaRecord1();
    //}

    //public void emaRecord2()
    //{
    //    Debug.Log("дсаерг 2 рвош");
    //    Game1Logic.emaRecord2();
    //}

    //public void emaRecord3()
    //{
    //    Debug.Log("дсаерг 3 рвош");
    //    Game1Logic.emaRecord3();
    //}

    //public void emaRecord4()
    //{
    //    Debug.Log("дсаерг 4 рвош");
    //    Game1Logic.emaRecord4();
    //}

    //public void emaRecord5()
    //{
    //    Debug.Log("дсаерг 5 рвош");
    //    Game1Logic.emaRecord5();
    //}

    //public void emaRecord6()
    //{
    //    Debug.Log("дсаерг 6 рвош");
    //    Game1Logic.emaRecord6();
    //}

    //public void orRecord1()
    //{
    //    Debug.Log("дсаерг 7 рвош");
    //    Game1Logic.orRecord1();
    //}

    //public void orRecord2()
    //{
    //    Debug.Log("дсаерг 8 рвош");
    //    Game1Logic.orRecord2();
    //}

    //public void orRecord3()
    //{
    //    Debug.Log("дсаерг 9 рвош");
    //    Game1Logic.orRecord3();
    //}

    //public void orRecord4()
    //{
    //    Debug.Log("дсаерг 10 рвош");
    //    Game1Logic.orRecord4();
    //}

    //public void orRecord5()
    //{
    //    Debug.Log("дсаерг 11 рвош");
    //    Game1Logic.orRecord5();
    //}

    //public void orRecord6()
    //{
    //    Debug.Log("дсаерг 12 рвош");
    //    Game1Logic.orRecord6();
    //}

    //public void tamarRecord1()
    //{
    //    Debug.Log("дсаерг 13 рвош");
    //    Game1Logic.tamarRecord1();
    //}

    //public void tamarRecord2()
    //{
    //    Debug.Log("дсаерг 14 рвош");
    //    Game1Logic.tamarRecord2();
    //}

    //public void tamarRecord3()
    //{
    //    Debug.Log("дсаерг 15 рвош");
    //    Game1Logic.tamarRecord3();
    //}

    //public void tamarRecord4()
    //{
    //    Debug.Log("дсаерг 16 рвош");
    //    Game1Logic.tamarRecord4();
    //}

    //public void tamarRecord5()
    //{
    //    Debug.Log("дсаерг 17 рвош");
    //    Game1Logic.tamarRecord5();
    //}

    //public void tamarRecord6()
    //{
    //    Debug.Log("дсаерг 18 рвош");
    //    Game1Logic.tamarRecord6();
    //}


}
