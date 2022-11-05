using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavigation : MonoBehaviour
{
    public EnemyController enemyController;
    private Transform playerPosition() => enemyController.transform;
    private NavMeshAgent navMeshAgent;
    // Start is called before the first frame update
    void Start()
    {
/*        enemyController = gameObject.GetComponent<EnemyController>();*/
        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        navMeshAgent.updateRotation = false;
        navMeshAgent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
