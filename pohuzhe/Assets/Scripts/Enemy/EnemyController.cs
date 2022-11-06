using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
public class EnemyController : MonoBehaviour
{

    public LevelController levelController;

    public float stopDistance { get; private set; } = 1;
    public float moveInAccuracy { get; private set; } = 0;
    public bool isStuned { get; private set; } = false;
    [SerializeField] private float health = 100f;
    [SerializeField] private GameObject ExpPrefab;
    public  UnityAction Idle;
    public  UnityAction Run;
    public  UnityAction Died;
    public  UnityAction Stun;
    public  UnityAction Damaged;
    private ShootingWeapon shootingWeapon;
    private PlayerController playerController;
    private float unstunTime = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        playerController = levelController.playerController;
        shootingWeapon = GetComponent<ShootingWeapon>();
        shootingWeapon.shoot += OnShoot;
        Stun += Stuned;
        Died += Die;
        Damaged += OnDamaged;
    }

    // Update is called once per frame
    void Update()
    {
        UnStun();
    }


    private void OnShoot()
    {

    }

    private void OnDamaged()
    {

    }


    public void HealthDecrement(float damage)
    {
        DamageRecieved();
        health -= damage/levelController.playerMaxHealthMultiplier;
        if (health*levelController.playerMaxHealthMultiplier <= 0) Died.Invoke();
    }
    private void Stuned()
    {
        unstunTime = Time.time + PlayerController.stunLength * levelController.playerStunTimeMultiplier;
        isStuned = true;
    }
    void UnStun()
    {
        if(unstunTime <= Time.time)        isStuned = false;

    }
    System.Random rnd = new System.Random();
    void Die()
    {
        
        GameObject buff = Instantiate(ExpPrefab, transform.position, Quaternion.identity);
        buff.GetComponent<ExpParticle>().playerController = levelController.playerController;
        
        buff = Instantiate(levelController.foodPrefabs[rnd.Next(0, levelController.foodPrefabs.ToArray().Length)], transform.position, Quaternion.identity);
        buff.GetComponent<CollectableItem>().levelControllerSetup(levelController);
        Destroy(gameObject);
        
        
    }
    void DamageRecieved()
    {
        Damaged.Invoke();
        Stun.Invoke();
    }
}
