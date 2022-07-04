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
                //������ ��� ����
                if (mybutton.image.sprite == imageOn)
                {
                    mybutton.image.overrideSprite = imageOnHover;
                    Debug.Log("������ �������� 1");
                    Debug.Log("����� ���� �����");
                }
                else
                {
                    mybutton.image.overrideSprite = imageOffHover;
                    Debug.Log("����� ���� ��� ����");
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
                //�� ������ �����
                if (mybutton.image.sprite == imageOff)
                {
                    Debug.Log("������ �����");
                    mybutton.image.overrideSprite = imageOff;
                }
                else
                {
                    mybutton.image.overrideSprite = imageOn;
                    Debug.Log("������ �������� 2");

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
                //�� ������ �����
                if (mybutton.image.sprite == imageOffHover)
                {
                    Debug.Log("������ �����");
                    mybutton.image.overrideSprite = imageOn;
                    Debug.Log("������ �������� 3");

                }
                 else
                {
                    mybutton.image.overrideSprite = imageOff;
                }
            }
        }
    }