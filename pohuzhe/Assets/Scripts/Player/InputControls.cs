using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputControls : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private KeyCode Up = KeyCode.W;
    [SerializeField] private KeyCode Down =  KeyCode.S;
    [SerializeField] private KeyCode Left = KeyCode.A;
    [SerializeField] private KeyCode Right = KeyCode.D;
    [SerializeField] private KeyCode Interact= KeyCode.E;
    [SerializeField] private KeyCode Attack = KeyCode.Mouse0;
    [SerializeField] private KeyCode Shield = KeyCode.Space;
    private Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        playerController = gameObject.GetComponent<PlayerController>();
        playerController.Run += Run;
        playerController.Shield += ShieldActivate;
    }
    Vector2 _direction = Vector2.zero;
    Vector2 _negativeDirection = Vector2.zero;
    Vector2 finalDirection = Vector2.zero;
    // Update is called once per frame
    void Update()
    {
        _direction = Vector2.zero;
        _negativeDirection = Vector2.zero;
        finalDirection = Vector2.zero;
        if (Input.GetKey(Up)) _direction.y = 1;
        if (Input.GetKey(Down)) _negativeDirection.y = -1 ;
        if (Input.GetKey(Left)) _negativeDirection.x = -1;
        if (Input.GetKey(Right)) _direction.x = 1;
        if(Input.GetKeyDown(Shield))
        {
            playerController.Shield.Invoke();
        }
        if(Input.GetKeyUp(Shield))
        {
            playerController.isProtected = false;
        }


        finalDirection = Vector2.ClampMagnitude(_direction* playerController.levelController.playerMoveSpeedMultiplier + _negativeDirection* playerController.levelController.playerMoveSpeedMultiplier, playerController.levelController.playerMoveSpeedMultiplier);
    }

    private void Run()
    {
        rigidbody.velocity = finalDirection;
    }

    private void ShieldActivate()
    {
        if (playerController.stamina >= 0)
        {
            playerController.isProtected = true;
            playerController.StaminaRegenerate(Time.deltaTime);
            return;
        }
        
    }

}
