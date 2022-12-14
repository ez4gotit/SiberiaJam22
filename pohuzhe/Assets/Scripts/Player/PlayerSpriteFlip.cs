using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpriteFlip : MonoBehaviour
{
    [SerializeField] LevelController levelController;
    
    // Start is called before the first frame update
    void Start()
    {
        levelController = transform.parent.GetComponent<PlayerController>().levelController;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.mousePosition.x<Screen.currentResolution.width/2)
        {
            gameObject.transform.GetComponent<SpriteRenderer>().flipX = true;
            
        }
        else
        {
            gameObject.transform.GetComponent<SpriteRenderer>().flipX = false;

        }
    }
}
