using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public ShootingWeapon shootingWeapon;
    public float damage { get; private set; } = 0;
    [SerializeField] private float lifeTime = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0) Destroy(gameObject);
    }

    public void DamageSet(float damage)
    {
        this.damage = damage;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player") {
            shootingWeapon.enemyController.levelController.playerController.HealthReduce(damage);
        Destroy(gameObject);       
        }
  
    }

}
