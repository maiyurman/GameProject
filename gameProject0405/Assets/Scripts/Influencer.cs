using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class Influencer
{
    public string InfluencerName { get; set; }
    public int NumofPosts { get; set; }
    public int NumOfFollowers { get; set; }
    public int NumOfFollowing { get; set; }
    public string InfluencerPic { get; set; }
    //מערך של תמונות של המשפיען
    public Sprite[] photos = new Sprite[6];

    //מערך של תאריכים
    public string[] dates = new string[6];

    
    public Influencer(string name, int numOfPosts, int numOfFollowers, int numOfFollowing)
    {
        InfluencerName = name;
        NumofPosts = numOfPosts;
        NumOfFollowers = numOfFollowers;
        NumOfFollowing = numOfFollowing;
        initDatesOfPhotos();
    }

    public void setImage(Sprite image, int index)
    {
        photos[index] = image;
    }

    public void initPhotos(int influencerNum)
    {
        for (int i = 0; i < photos.Length; i++)
        {
            photos[i] = Resources.Load<Sprite>("Influencers/" + influencerNum + "/" + (i + 1).ToString());
        }
    }

    public void initDefaultPhotos(string photoPath)
    {
        for (int i = 0; i < photos.Length; i++)
        {
            photos[i] = Resources.Load<Sprite>(photoPath);
        }
    }

    private void initDatesOfPhotos()
    {
        float firstDay = 1;
        float lastDay = 5;

        for(int i = 0; i < dates.Length; i++)
        {
            float randomDay = UnityEngine.Random.Range((firstDay), (lastDay));
            int randomDayInt = Convert.ToInt32(randomDay);

            dates[i] = randomDayInt.ToString() + " / 9";

            firstDay += 5;
            lastDay += 5;
        }
    }

};
