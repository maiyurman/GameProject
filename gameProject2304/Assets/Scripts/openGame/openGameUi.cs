using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class openGameUi : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void pressOpenGameBtn()
    {
        PlayerPrefs.SetInt("gameNumIn", 1);
        PlayerPrefs.SetInt("openGameMax", 1);
        SceneManager.LoadScene("Game1");
    }
}
