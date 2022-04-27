using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Game1UIScript : MonoBehaviour
{
    private Game1Logic Game1LogicScript;
    public navigation messageBtn;
    public GameObject openScreen;
    public GameObject game1ChatBox;
    public GameObject game1Chat;
    public GameObject game2ChatBox;
    public GameObject game2Chat;
    public GameObject game3ChatBox;
    public GameObject game3Chat;

    private void Start()
    {

        Game1LogicScript = transform.gameObject.GetComponent<Game1Logic>();
        messageBtn.disableBtn();
        openScreen.SetActive(true);
        game1ChatBox.SetActive(false);
        game1Chat.SetActive(false);
        game2ChatBox.SetActive(false);
        game2Chat.SetActive(false);
        game3ChatBox.SetActive(false);
        game3Chat.SetActive(false);
    }

    public void openMessageBtn()
    {
        messageBtn.enableBtn();
    }

    public void opengame1ChatBox()
    {
        openScreen.SetActive(false);
        game1ChatBox.SetActive(true);
    }

    public void opengame1Chat()
    {
        game1ChatBox.SetActive(false);
        game1Chat.SetActive(true);
    }

    public void opengame2ChatBox()
    {
        game1Chat.SetActive(false);
        game2ChatBox.SetActive(true);
    }

    public void opengame2Chat()
    {
        game2ChatBox.SetActive(false);
        game2Chat.SetActive(true);
    }

    public void opengame3ChatBox()
    {
        game2Chat.SetActive(false);
        game3ChatBox.SetActive(true);
    }

    public void opengame3Chat()
    {
        game3ChatBox.SetActive(false);
        game3Chat.SetActive(true);
    }

}