using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game3Logic : MonoBehaviour
{
    private loadStoryBtn loadStoryBtn;
    
    void Start()
    {
        loadStoryBtn = transform.gameObject.GetComponent<loadStoryBtn>();
        //����� �� ������
        loadStoryBtn.disableStoryBtnAll();
        Debug.Log(PlayerPrefs.GetInt("GameMax"));
        //������ �� ������ ���������� ���� ��������
        int myMaxLevel = PlayerPrefs.GetInt("GameMax");
        Debug.Log("Max Level start" + myMaxLevel);

        if (PlayerPrefs.GetInt("GameMax") != 0)
        {
            int MaxStage = PlayerPrefs.GetInt("GameMax");
            Debug.Log(MaxStage);
            loadStoryBtn.EnableStoryBtnsForLevel(MaxStage);
            Debug.Log(MaxStage);
        }
    }

    //������ �� ����� ���� ����
    public void finishGame()
    {
        //����� ����� �����
        if (PlayerPrefs.GetInt("GameMax") < 3)
        {
            PlayerPrefs.SetInt("GameMax", 3);
        }

        int myMaxLevel = PlayerPrefs.GetInt("GameMax");
        Debug.Log("Max Level" + myMaxLevel);
        loadStoryBtn.enableStoryBtn(myMaxLevel);
    }
}
