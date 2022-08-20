using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class greyHome : MonoBehaviour
{
    public GameObject NOTher;

    // Start is called before the first frame update
    void Start()
    {
        
    }
        public void validateOnRelese(Dragable dragable, DropArea dropArea)
        {
            NOTher.SetActive(true);
        }
    
}
