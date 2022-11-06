using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerAttack : MonoBehaviour
{
    private Animator anim;
    public float attackTime;
    public float startTimeAttack;
    public Transform attackLocation;
    public float attackRange;
    public LayerMask enemies;
    [SerializeField] private float damageAmount = 65;
    [SerializeField] private PlayerController playerController;

    private void Start()
    {
        anim = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
    }
    void Update()
    {
        if (attackTime <= 0)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                anim.SetBool("Is_attacking", true);
                Collider2D[] damage = Physics2D.OverlapCircleAll(attackLocation.position, attackRange*playerController.levelController.playerSplashAttackRadius, enemies);
                
                for (int i = 0; i < damage.Length; i++)
                {
                    damage[i].gameObject.GetComponent<EnemyController>().HealthDecrement(damageAmount*playerController.levelController.playerDamageMultiplier);
                }
            }
            attackTime = startTimeAttack;
        }
        else
        {
            attackTime -= Time.deltaTime;
            anim.SetBool("Is_attacking", false);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackLocation.position, attackRange*playerController.levelController.playerSplashAttackRadius);
    }
}