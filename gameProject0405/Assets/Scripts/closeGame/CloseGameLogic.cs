using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CloseGameLogic : MonoBehaviour
{
    public navigation place;
    public navigation chat;
    public navigation user;

    private void Start()
    {
        place.disableBtn();
        chat.disableBtn();
        user.disableBtn();
    }
    public void startOverGame()
    {
        SceneManager.LoadScene("openGame");
    }

    public void closeGame()
    {
        SceneManager.LoadScene("menu");
    }
}
