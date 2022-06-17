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
            new Influencer("��� �� ���", 50, 700, 250),
            new Influencer("��� ����", 3000 ,300000, 150000),
            new Influencer("��� ��� ������", 1600, 50000, 55000),
            new Influencer("���� ����", 1000, 100000, 125000),
            new Influencer("���� ���", 1500, 250000, 80000),
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