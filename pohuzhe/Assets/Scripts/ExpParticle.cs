using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpParticle : MonoBehaviour
{
    public PlayerController playerController;
    Rigidbody2D rb;
    [SerializeField]private LayerMask player;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(playerController.gameObject.transform.position, gameObject.transform.position) <= 4) rb.AddForce( Time.deltaTime*(playerController.gameObject.transform.position - gameObject.transform.position));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            playerController.ExpIncrement();
            Destroy(gameObject);

        }
    }
}
