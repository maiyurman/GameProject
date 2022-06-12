using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CloseGameLogic : MonoBehaviour
{
    public navigation place;
    public navigation chat;
    public navigation user;


    //------>אנימציה תמיר 
    public Animator tamirAnimator;

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

    public void stopTamirTalk()
    {
        StartCoroutine(stopTamirStartTalk());

    }

    IEnumerator stopTamirStartTalk()
    {
        yield return new WaitForSeconds(2);
        tamirAnimator.SetBool("isTalk", false);
    }
}
