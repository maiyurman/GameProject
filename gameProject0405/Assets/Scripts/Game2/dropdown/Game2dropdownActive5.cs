using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game2dropdownActive5 : MonoBehaviour
{
    public void handleInputData(int valActive)
    {
        if (valActive == 2)
        {
            PlayerPrefs.SetString("Active", "true");
        }
        else
        {
            PlayerPrefs.SetString("Active", "false");
        }
    }
}
