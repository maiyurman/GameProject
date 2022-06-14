using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CloseGameLogic : MonoBehaviour
{
    public navigation place;
    public navigation chat;
    public navigation user;
    public navigation level1;
    public navigation level2;
    public navigation level3;
    public navigation level4;
    public navigation level5;



    //------>אנימציה תמיר 
    public Animator tamirAnimator;

    private void Start()
    {
        place.disableBtn();
        chat.disableBtn();
        user.disableBtn();
        level1.enableBtn();
        level2.enableBtn();
        level3.enableBtn();
        level4.enableBtn();
        level5.enableBtn();

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
