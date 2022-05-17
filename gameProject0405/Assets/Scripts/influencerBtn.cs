using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class influencerBtn : MonoBehaviour
{
    //------------------------> כפתור עזרה והוראות

    public navigation InfluencerBtn;
    public GameObject windowInfo;

    public navigation intoBtn;
    public navigation helpBtn;

    public TextMeshProUGUI infoTXt;
    public TextMeshProUGUI helpTxt;

    bool infoWindowOpen;

    private void Start()
    {
        InfluencerBtn.enableBtn();
        windowInfo.SetActive(false);
        intoBtn.transform.gameObject.SetActive(true);
        helpBtn.transform.gameObject.SetActive(true);
        helpBtn.enableBtn();
        intoBtn.enableBtn();
        infoWindowOpen = false;
    }

    //הצגת חלון אינפורמציה  
    public void infoWindow()
    {
        if (infoWindowOpen)
        {
            windowInfo.SetActive(false);
            InfluencerBtn.enableBtn();
        }
        else
        {
            windowInfo.SetActive(true);
            InfluencerBtn.disableBtn();
            intoBtn.transform.gameObject.SetActive(true);
            helpBtn.transform.gameObject.SetActive(true);
        }
        helpTxt.transform.gameObject.SetActive(false);
        infoTXt.transform.gameObject.SetActive(false);
    }

    //פתיחת הוראות
    public void infoText()
    {
        Debug.Log("הוראות");
        helpTxt.transform.gameObject.SetActive(false);
        infoTXt.transform.gameObject.SetActive(true);
        intoBtn.transform.gameObject.SetActive(false);
        helpBtn.transform.gameObject.SetActive(false);
    }

    //בלחיצה על כפתור עזרה
    public void helpText()
    {
        Debug.Log("עזרה");
        helpTxt.transform.gameObject.SetActive(true);
        infoTXt.transform.gameObject.SetActive(false);
        intoBtn.transform.gameObject.SetActive(false);
        helpBtn.transform.gameObject.SetActive(false);
    }
}
