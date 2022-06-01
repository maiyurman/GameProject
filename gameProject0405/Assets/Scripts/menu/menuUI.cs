using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class menuUI : MonoBehaviour
{
    public GameObject aboutWindow;
    public GameObject menu;

    // Start is called before the first frame update
    void Start()
    {
        aboutWindow.SetActive(false);
        menu.SetActive(true);
    }

    public void openGame()
    {
        SceneManager.LoadScene("openGame");
    }

}
