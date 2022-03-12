using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game1UIScript : MonoBehaviour
{
    public navigation messageBtn;
    public GameObject openScreen;
    public GameObject Screen1;
    public GameObject Screen2;

    public void btnMessageBtn()
    {
        Debug.Log("הפעלת כפתור הודעה");
        messageBtn.enableBtn();

    }

    public void openScreen1()
    {
        openScreen.SetActive(false);
        Screen1.SetActive(true);
    }

    public void openScreen2()
    {
        Screen1.SetActive(false);
        Screen2.SetActive(true);
    }

}
