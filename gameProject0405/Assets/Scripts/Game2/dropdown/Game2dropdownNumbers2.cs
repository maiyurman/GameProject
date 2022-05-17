using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game2dropdownNumbers2 : MonoBehaviour
{
    public void handleInputData(int valNumbers)
    {
        if (valNumbers == 0)
        {
            PlayerPrefs.SetString("Numbers", "true");
        }
        else
        {
            PlayerPrefs.SetString("Numbers", "false");
        }
    }
}
