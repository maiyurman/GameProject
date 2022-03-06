using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game5Data : MonoBehaviour
{

    private Game5UIManager Game5UIManager;
    private loadStoryBtn loadStoryBtn;

    private int openGameMax;


    // Start is called before the first frame update
    void Start()
    {
        Game5UIManager = transform.gameObject.GetComponent<Game5UIManager>();
        loadStoryBtn = GameObject.Find("levels").GetComponent<loadStoryBtn>();
        PlayerPrefs.SetInt("openGameMax",4);
        openGameMax = PlayerPrefs.GetInt("openGameMax");
        loadStoryBtn.EnableStoryBtnsForLevel(openGameMax);
        loadStoryBtn.enableStoryBtn(openGameMax);
    }
}
