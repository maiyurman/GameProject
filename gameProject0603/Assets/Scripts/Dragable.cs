using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragable : MonoBehaviour
{
    public bool canDrag = true;
    private Vector3 initPosition;

    // Start is called before the first frame update
    void Start()
    {
        updateInitPosition();
    }

    private void updateInitPosition()
    {
        initPosition = this.transform.position;
    }

    public void returnToInitPosition()
    {
        this.transform.position = initPosition;
    }

    public void setImage(Sprite image)
    {
        GetComponent<SpriteRenderer>().sprite = image;
    }

    public Sprite getImage()
    {
        return GetComponent<SpriteRenderer>().sprite;
    }
}
