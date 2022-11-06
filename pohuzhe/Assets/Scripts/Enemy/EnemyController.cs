using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour
{

    public LevelController levelController;

    public float stopDistance { get; private set; } = 1;
    public float moveInAccuracy { get; private set; } = 0;
    public bool isStuned { get; private set; } = false;
    [SerializeField] private float health;
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
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnShoot()
    {

    }

    private void OnDamaged()
    {
        Stun.Invoke();
    }


    public void HealthDecrement(float damage)
    {
        health -= damage;
        if (health <= 0) Died.Invoke();
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
    void Die()
    {

    }
    void DamageRecieved()
    {
        Damaged.Invoke();
        Stun.Invoke();
    }
}
