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
    public Sprite imagehover;

    public void Awake()
    {
        mybutton = GetComponent<Button>();
        //disableBtn();
    }

    public void enableBtn()
    {
        mybutton.image.sprite = imageOn;
        mybutton.enabled = true;
    }

    public void disableBtn()
    {
        mybutton.image.sprite = imageOff;
        mybutton.enabled = false;
    }

    public void notMusic()
    {
        mybutton.image.sprite = imageOff;

    }

    void OnMouseOver()
    {
        if (mybutton.enabled == false)
        {
            cursorControllerNew.instance.ActivatenoExitCursor();
        }
        else
        {
            //כשפעיל ולא כבוי
            if (mybutton.image.sprite == imageOn || mybutton.image.sprite == imagehover)
            {
                cursorControllerNew.instance.ActivateclickerCursor();
                Debug.Log("כפתור פעיל ולא כבוי");
                mybutton.image.sprite = imagehover;
                Debug.Log(mybutton.image.sprite);
            }
            else
            {
                mybutton.image.sprite = imageOff;
                cursorControllerNew.instance.ActivateclickerCursor();
                Debug.Log(mybutton.image.sprite);

            }
        }
    }

    void OnMouseExit()
    {
        if (mybutton.enabled == false)
        {
            cursorControllerNew.instance.ActivateRegularCursor();
        }
        else
        {
            cursorControllerNew.instance.ActivateRegularCursor();
            //אם התמונה מכובה
            if (mybutton.image.sprite == imageOff)
            {
                Debug.Log("התמונה מכובה");
                mybutton.image.sprite = imageOff;
            }
            else
            {
                mybutton.image.sprite = imageOn;
            }
        }

    }

    private void OnMouseDown()
    {
        if (mybutton.enabled == false)
        {
            cursorControllerNew.instance.ActivatenoExitCursor();
        }
        else
        {
            cursorControllerNew.instance.ActivateclickerCursor();
            mybutton.image.sprite = imagehover;
        }
    }


}
