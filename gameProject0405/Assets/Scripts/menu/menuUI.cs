using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class menuUI : MonoBehaviour
{
    public GameObject aboutWindow;
    public GameObject menu;
    public navigation HIT;
    public navigation Matach;

    // Start is called before the first frame update
    void Start()
    {
        aboutWindow.SetActive(false);
        menu.SetActive(true);
        PlayerPrefs.SetString("isMusicOn", "true");
    }

    public void openGame()
    {
        SceneManager.LoadScene("openGame");
    }


    public void linkHIT()
    {
        Application.OpenURL("https://www.hit.ac.il/");
    }

    public void linkTelem()
    {
        Application.OpenURL("https://www.hit.ac.il/telem/overview");

    }

    public void linkMatach()
    {
        Application.OpenURL("https://home.cet.ac.il/");

    }

}
