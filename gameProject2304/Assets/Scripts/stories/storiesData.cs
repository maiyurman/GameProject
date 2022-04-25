using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class storiesData : MonoBehaviour
{
    [TextArea(3, 10)]
    public string[] Storytext;
    public int pageNumber;
    private UIMangerstory UIMangerstory;
    private loadStoryBtn loadStoryBtn;

    private int openGameMax;



    void Start()
    {
        UIMangerstory = transform.gameObject.GetComponent<UIMangerstory>();
        loadStoryBtn = GameObject.Find("levels").GetComponent<loadStoryBtn>();

        pageNumber = PlayerPrefs.GetInt("gameNumIn");
        UIMangerstory.updateArrows();
        UIMangerstory.updateUi();
        openGameMax = PlayerPrefs.GetInt("openGameMax");
        loadStoryBtn.EnableStoryBtnsForLevel(openGameMax);
        loadStoryBtn.enableStoryBtn(openGameMax);
        
    }

    

}