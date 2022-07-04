using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class navgationFor2 : MonoBehaviour
    {
        private Button mybutton;
        public Sprite imageOff;
        public Sprite imageOn;
        public Sprite imageOnHover;
        public Sprite imageOffHover;


    public void Awake()
        {
            mybutton = GetComponent<Button>();
        }

        public void enableBtn()
        {
            cursorControllerNew.instance.ActivateclickerCursor();
            mybutton.image.overrideSprite = imageOn;
            mybutton.image.sprite = imageOn;
            mybutton.enabled = true;

    }

    public void disableBtn()
        {
            mybutton.image.overrideSprite = imageOff;
            mybutton.image.sprite = imageOff;
            mybutton.enabled = false;
        }

        public void notMusic()
        {
            mybutton.image.overrideSprite = imageOff;
            mybutton.image.sprite = imageOff;
            cursorControllerNew.instance.ActivateclickerCursor();
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
                if (mybutton.image.sprite == imageOn)
                {
                    mybutton.image.overrideSprite = imageOnHover;
                    Debug.Log("נכנסתי לפונקציה 1");
                    Debug.Log("כפתור פעיל וכבוי");
                }
                else
                {
                    mybutton.image.overrideSprite = imageOffHover;
                    Debug.Log("כפתור פעיל ולא כבוי");
                }
                cursorControllerNew.instance.ActivateclickerCursor();
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
                    mybutton.image.overrideSprite = imageOff;
                }
                else
                {
                    mybutton.image.overrideSprite = imageOn;
                    Debug.Log("נכנסתי לפונקציה 2");

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
                //אם התמונה מכובה
                if (mybutton.image.sprite == imageOffHover)
                {
                    Debug.Log("התמונה מכובה");
                    mybutton.image.overrideSprite = imageOn;
                    Debug.Log("נכנסתי לפונקציה 3");

                }
                 else
                {
                    mybutton.image.overrideSprite = imageOff;
                }
            }
        }
    }