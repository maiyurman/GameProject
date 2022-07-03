using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activeGrabCursor : MonoBehaviour
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
        cursorControllerNew.instance.ActivategrabCursor();
    }

    private void OnMouseDrag()
    {
        cursorControllerNew.instance.ActivateholdCursor();
    }

    private void OnMouseUp()
    {
        cursorControllerNew.instance.ActivateRegularCursor();

    }

    private void OnMouseExit()
    {
        cursorControllerNew.instance.ActivateRegularCursor();
    }

    private void OnMouseDown()
    {
        cursorControllerNew.instance.ActivateRegularCursor();

    }
}
