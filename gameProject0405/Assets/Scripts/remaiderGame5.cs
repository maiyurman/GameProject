using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class remaiderGame5 : MonoBehaviour
{
    public GameObject remaider;
    // Start is called before the first frame update
    private void OnMouseDrag()
    {
        remaider.SetActive(false);
    }
}
