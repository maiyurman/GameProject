using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wavingTime : MonoBehaviour
{
    public Animator tamirAnimator;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waving(1));
    }

    public IEnumerator waving(float numbersec)
    {
        tamirAnimator.SetBool("isWave", true);
        //??? ?????? ??????
        int numbergro = 0;
        int finalenumber = 6;
        for (int i = numbergro; i <= finalenumber; i++)
        {
            Debug.Log(i);
            yield return new WaitForSeconds(numbersec);
        }
        Debug.Log("??????");
        tamirAnimator.SetBool("isWave", false);
        
        yield return new WaitForSeconds(2);
        StartCoroutine(waving(1));
    }
}
