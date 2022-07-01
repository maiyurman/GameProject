using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class activeRegularCuror : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        cursorControllerNew.instance.ActivateRegularCursor();
    }

    private void OnMouseUp()
    {
        cursorControllerNew.instance.ActivateRegularCursor();

    }
}
