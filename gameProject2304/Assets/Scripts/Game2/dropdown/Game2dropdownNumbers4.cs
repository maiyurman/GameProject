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
        else
        {
            PlayerPrefs.SetString("Numbers", "false");
        }
    }
}
