using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game2dropdownActive2 : MonoBehaviour
{
    public void handleInputData(int valActive)
    {
        if (valActive == 0)
        {
            PlayerPrefs.SetString("Active", "true");
        }
        else if (valActive == -1)
        {
            PlayerPrefs.SetString("Active", "notValue");
        }
        else
        {
            PlayerPrefs.SetString("Active", "false");
        }
    }
}
