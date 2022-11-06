using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavigation : MonoBehaviour
{
    [SerializeField]private EnemyController enemyController;
    [SerializeField]private LevelController levelController;

    private NavMeshAgent navMeshAgent;
    private Transform playerTransform;
    private Vector3 inAccuracy = Vector3.zero;
    // Start is called before the first frame update


    void Start()
    {


        enemyController = gameObject.GetComponent<EnemyController>();
        levelController = enemyController.levelController;
        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        navMeshAgent.updateRotation = false;
        navMeshAgent.updateUpAxis = false;
        playerTransform = levelController.playerController.gameObject.transform;
    }
    
    // Update is called once per frame
    void Update()
    {

        if (!enemyController.isStuned)
        {
            inAccuracy = RandomVector(enemyController.moveInAccuracy);
            if (Vector2.Distance(gameObject.transform.position, playerTransform.position) > enemyController.stopDistance)
            {
                navMeshAgent.SetDestination(playerTransform.position + inAccuracy);
                OnRun();
            }
            else
            {
                transform.position = this.transform.position;
                OnIdle();
            }
        }
    }


    Vector2 RandomVector(float ranges)
    {
        return new Vector2(Random.Range(-1 * ranges, ranges), Random.Range(-1 * ranges, ranges));
    }


    private void OnRun()
    {
        
    }
    private void OnIdle()
    {

    }
}
