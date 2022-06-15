using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Game3Data : MonoBehaviour
{
    // path witout extention
    public static string defaultPhotoPath = "DropAreaPlaceholder";
    public Game3UiManager uiManager;
    private loadStoryBtn loadStoryBtn;
    public Influencer[] influencers; // [SerializeField]
    public List<DropArea> dropAreas;
    public TextMeshProUGUI[] influenceDate;
    public int pageNumber = 0;

    public void Start()
    {
        uiManager = transform.gameObject.GetComponent<Game3UiManager>();

        initInfluencers();
        uiManager.UpdateUi(pageNumber);
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
            new Influencer("עדי ביטי", 3000 ,300 , 1500),
            new Influencer("קים אור אזולאי", 1600, 500, 550),
            new Influencer("ליאם גולן", 700, 100, 1250),
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