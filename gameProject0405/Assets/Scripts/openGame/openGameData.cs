using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openGameData : MonoBehaviour
{
    int number=0;

    // Start is called before the first frame update
    void Start()
    {
        //����� ����� �� ��� ����� �����
        PlayerPrefs.SetInt("gameNumIn", number);

        //����� ����� ��������
        PlayerPrefs.SetInt("openGameMax", number);
    }

}
