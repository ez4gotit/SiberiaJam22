using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerAttack : MonoBehaviour
{
    public float attackTime;
    public float startTimeAttack;
    public Transform attackLocation;
    public float attackRange;
    public LayerMask enemies;
    [SerializeField] private float damageAmount = 65;
    [SerializeField] private PlayerController playerController;

    private void Start()
    {
 
        playerController = GetComponent<PlayerController>();
    }
    void Update()
    {
        if (attackTime <= 0)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
            
                Collider2D[] damage = Physics2D.OverlapCircleAll(attackLocation.position, attackRange*playerController.levelController.playerSplashAttackRadius, enemies);
                
                for (int i = 0; i < damage.Length; i++)
                {
                    damage[i].gameObject.GetComponent<EnemyController>().HealthDecrement(damageAmount*playerController.levelController.playerDamageMultiplier);
                    playerController.animator.Play("MCAttack");
                }
            }
            attackTime = startTimeAttack;
        }
        else
        {
            attackTime -= Time.deltaTime;
            
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackLocation.position, attackRange*playerController.levelController.playerSplashAttackRadius);
    }
}