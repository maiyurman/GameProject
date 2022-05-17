using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openGameData : MonoBehaviour
{
    int number=0;

    // Start is called before the first frame update
    void Start()
    {
        //הגדרת המשחק בו אני נמצאת עכשיו
        PlayerPrefs.SetInt("gameNumIn", number);

        //הגדרת המשחק המקסימלי
        PlayerPrefs.SetInt("openGameMax", number);
    }

}
