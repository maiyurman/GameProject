using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activenoExitCursor : MonoBehaviour
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
        cursorControllerNew.instance.ActivatenoExitCursor();
    }

    private void OnMouseExit()
    {
        cursorControllerNew.instance.ActivateRegularCursor();
    }

    private void OnMouseDown()
    {
        cursorControllerNew.instance.ActivatenoExitCursor();

    }

    private void OnMouseUp()
    {
        cursorControllerNew.instance.ActivatenoExitCursor();

    }
}
