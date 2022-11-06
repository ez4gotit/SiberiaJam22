using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShootingWeapon : MonoBehaviour
{
    [SerializeField] private float beginShootingRange;
    public EnemyController enemyController { get; private set; }
    [SerializeField] private Transform target;
    [SerializeField] private bool isPlayerDetected = false;
    [SerializeField] private float bulletDamage;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float fireRate;
    [SerializeField] private float shootingInaccuracy;
    [SerializeField] private float NextTimeToShoot = 0;
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private GameObject weapon;
    [SerializeField] private LayerMask mask;
    public GameObject bulletPrefab;
    
    public UnityAction shoot;

    Vector2 targetPosition = Vector2.zero;
    Vector2 _direction = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        shoot += Shoot;
        enemyController = gameObject.GetComponent<EnemyController>();
        target = enemyController.levelController.playerController.gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        targetPosition = (Vector2)target.position;
        _direction = targetPosition - (Vector2)transform.position;
        if (!enemyController.isStuned)
        {

            RaycastHit2D raycastHit2D = Physics2D.Raycast(transform.position, _direction, beginShootingRange, mask);
            if (raycastHit2D)
            {
                Debug.Log(raycastHit2D.collider.gameObject.name);
                if (LayerMask.LayerToName(raycastHit2D.collider.gameObject.layer)== "Player")
                {

                    isPlayerDetected = true;

                }
                else { isPlayerDetected = false; }

            }

            if (isPlayerDetected)
            {
                weapon.transform.up = target.position - transform.position;
                if (Time.time > NextTimeToShoot)
                {
                    NextTimeToShoot = Time.time + 1 / fireRate;
                    if (shoot != null) shoot.Invoke();
                }
            }
        }
    }


    private void OnPlayerLost()
    {
        
    }

    private void Shoot()
    {
        GameObject currentBullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
        currentBullet.GetComponent<Rigidbody2D>().velocity = (_direction + RandomVector(shootingInaccuracy/(Vector2.Distance(transform.position,target.position)*enemyController.levelController.enemyAccuracyMultiplier))) * bulletSpeed * enemyController.levelController.enemyBulletSpeedMultiplier;
        currentBullet.GetComponent<Bullet>().DamageSet(bulletDamage * enemyController.levelController.enemyDamageMultiplier);
        currentBullet.GetComponent<Bullet>().shootingWeapon = this;
    }

    Vector2 RandomVector(float ranges)
    {
        return new Vector2(Random.Range(-1 * ranges, ranges), Random.Range(-1 * ranges, ranges));
    }

}
