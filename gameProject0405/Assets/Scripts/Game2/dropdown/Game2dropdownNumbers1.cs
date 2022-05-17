using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game2dropdownNumbers1 : MonoBehaviour
{
    public void handleInputData(int valNumbers)
    {
        if (valNumbers == 2)
        {
            PlayerPrefs.SetString("Numbers", "true");
        }
        else
        {
            PlayerPrefs.SetString("Numbers", "false");
        }
    }

    
}