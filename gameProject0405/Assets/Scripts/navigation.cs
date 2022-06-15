using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class navigation : MonoBehaviour
{
    private Button mybutton;
    public Sprite imageOff;
    public Sprite imageOn;

    public void Awake()
    {
        mybutton = GetComponent<Button>();
        //disableBtn();
    }

    public void enableBtn()
    {
        mybutton.image.overrideSprite = imageOn;
        mybutton.enabled = true;
    }

    public void disableBtn()
    {
        mybutton.image.overrideSprite = imageOff;
        mybutton.enabled = false;
    }

    public void notMusic()
    {
        mybutton.image.overrideSprite = imageOff;

    }


}
