using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activeClickerCursor : MonoBehaviour
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
        Debug.Log("πλπρ");
        cursorControllerNew.instance.ActivateclickerCursor();
    }

    private void OnMouseExit()
    {
        cursorControllerNew.instance.ActivateRegularCursor();
    }

    private void OnMouseDown()
    {
        cursorControllerNew.instance.ActivateRegularCursor();

    }

    private void OnMouseUp()
    {
        cursorControllerNew.instance.ActivateRegularCursor();

    }
}
