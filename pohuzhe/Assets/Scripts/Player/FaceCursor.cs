using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCursor : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.up = (Vector2)gameObject.transform.position + (new Vector2(Screen.currentResolution.width/2 - Input.mousePosition.x, Screen.currentResolution.height/2 - Input.mousePosition.y));
    }
}
