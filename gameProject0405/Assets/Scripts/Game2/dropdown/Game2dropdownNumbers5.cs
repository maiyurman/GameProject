using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game2dropdownNumbers5 : MonoBehaviour
{
    public void handleInputData(int valNumbers)
    {
        if (valNumbers == 1)
        {
            PlayerPrefs.SetString("Numbers", "true");
        }
        else if (valNumbers == -1)
        {
            PlayerPrefs.SetString("Numbers", "notValue");
        }
        else
        {
            PlayerPrefs.SetString("Numbers", "false");
        }
    }
}
