using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game2dropdownNumbers1 : MonoBehaviour
{
    public void handleInputData(int valNumbers)
    {
        Debug.Log("valNumbers" + valNumbers);
        if (valNumbers == 2)
        {
            PlayerPrefs.SetString("Numbers", "true");
        }
        else if(valNumbers == -1)
        {
            PlayerPrefs.SetString("Numbers", "notValue");
        }
        else
        {
            PlayerPrefs.SetString("Numbers", "false");
        }
    }

    
}