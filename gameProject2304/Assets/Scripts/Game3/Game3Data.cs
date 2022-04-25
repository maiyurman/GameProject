using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game3Data : MonoBehaviour
{
    // path witout extention
    public static string defaultPhotoPath = "DropAreaPlaceholder";
    public Game3UiManager uiManager;
    private loadStoryBtn loadStoryBtn;
    public Influencer[] influencers; // [SerializeField]
    public List<DropArea> dropAreas;
    public Text[] influenceDate;
    public int pageNumber = 0;
    private int openGameMax;

    public void Start()
    {
        PlayerPrefs.SetInt("gameNumIn",3);
        uiManager = transform.gameObject.GetComponent<Game3UiManager>();
        loadStoryBtn = GameObject.Find("levels").GetComponent<loadStoryBtn>();

        initInfluencers();
        uiManager.UpdateUi(pageNumber);
        PlayerPrefs.SetInt("openGameMax",3);
        openGameMax = PlayerPrefs.GetInt("openGameMax");
        Debug.Log(openGameMax);
        loadStoryBtn.EnableStoryBtnsForLevel(openGameMax);
    }

    public Influencer getCurrentInfluencer()
    {
        return influencers[pageNumber];
    }

    public int getIndexOfDropArea(DropArea dropArea)
    {
        return dropAreas.IndexOf(dropArea);
    }

    private void initInfluencers()
    {
        influencers = new Influencer[]
        {
            new Influencer("אור בן ישי", 50, 700, 2500),
            new Influencer("דניאל עמית", 3000 ,300 , 1500),
            new Influencer("מאיה ורטהיימר", 1600, 500, 550),
            new Influencer("אוראל צברי", 700, 100, 1250),
            new Influencer("נועה בוג", 100, 250, 800),
        };
        initInfluencersPhotos();
    }

    private void initInfluencersPhotos()
    {
        influencers[0].initDefaultPhotos(defaultPhotoPath);
        for (int i = 1; i < influencers.Length; i++)
        {
            influencers[i].initPhotos(i);
        }
    }

}