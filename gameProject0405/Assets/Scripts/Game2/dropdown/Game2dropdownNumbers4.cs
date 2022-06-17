using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game2dropdownNumbers4 : MonoBehaviour
{
    public void handleInputData(int valNumbers)
    {
        if (valNumbers == 3)
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
