using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropArea : MonoBehaviour
{
    public bool canDrop = true;

    public void setImage(Sprite image)
    {
        GetComponent<SpriteRenderer>().sprite = image;
    }

    public Sprite getImage()
    {
        return GetComponent<SpriteRenderer>().sprite;
    }
}
