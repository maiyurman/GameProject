using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursorControllerNew : MonoBehaviour
{

    public static cursorControllerNew instance;

    public Texture2D regularCursor, clickerCursor, grabCursor;

    private void Awake()
    {
        instance = this;

    }

    public void ActivateRegularCursor()
    {
        Cursor.SetCursor(regularCursor, Vector2.zero, cursorMode:CursorMode.Auto);
    }


    public void ActivateclickerCursor()
    {
        Cursor.SetCursor(clickerCursor, Vector2.zero, cursorMode: CursorMode.Auto);
    }

    public void ActivategrabCursor()
    {
        Cursor.SetCursor(grabCursor, Vector2.zero, cursorMode: CursorMode.Auto);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
