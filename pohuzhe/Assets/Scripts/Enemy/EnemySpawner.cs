using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float frequency = 1;
    [SerializeField] private float frequencyIncreaseCoefficient = 1.1f;
    [SerializeField] private float startTimeSecs = 1;

    [SerializeField] private LevelController levelController;
    float timeBuffer;
    // Start is called before the first frame update
    void Start()
    {
        startTimeSecs += Time.time;
        timeBuffer = startTimeSecs;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > startTimeSecs) Spawn();
        
    }


    private void Spawn()
    {
        
        if(Time.time-timeBuffer > frequency && Time.time-timeBuffer>0)
        {
            timeBuffer = Time.time + frequency;
            Vector2 Position = new Vector2(levelController.playerController.gameObject.transform.position.x+(0.5f-Random.value)*(Random.value * 80+20), levelController.playerController.gameObject.transform.position.y + (0.5f - Random.value) * (Random.value *52+13));
            GameObject enemy = Instantiate(enemyPrefab,Position, Quaternion.identity);
            enemy.GetComponent<EnemyController>().levelController = levelController;
        }
    }
}
