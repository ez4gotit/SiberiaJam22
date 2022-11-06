using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{

    [Header("Controllers")]
    public PlayerController playerController;
    public List<EnemyController> enemyControllers;


    [Header("Global Stats")]
    public float allHealthRegenerationMultiplier = 0f;

    [Header("Enemy Stats")]
    public float enemyAccuracyMultiplier= 1f;
    public float enemyMoveSpeedMultiplier = 1f;
    public float enemyBulletSpeedMultiplier = 1f;
    public float enemyDamageMultiplier = 1f;
    public float enemyReloadSpeedMultiplier = 1f;
    public float enemyHealthMultiplier = 1f;

    [Header("Player Stats")]
    public float playerStunTimeMultiplier= 1f;
    public float playerMoveSpeedMultiplier = 1f;
    public float playerMaxStaminaMultiplier = 1f;
    public float playerStaminaRegenerationMultiplier = 1f;
    public float playerHungerRegenerationMultiplier = 1f;
    public float playerMaxHealthMultiplier = 1f;
    public float playerDamageMultiplier = 1f;
    public float playerSplashAttackRadius = 0f;
    public float playerSizeMultiplier = 1f;

    [Header("Player Statistics")]
    public StatisticsController statisticsController;
    public float timeLeft { get; private set; }

    public float maxTimeSeconds = 600f;

    // Start is called before the first frame update
    void Start()
    {
        playerController.Damaged += OnPlayerDamaged;
        playerController.Died += OnLevelRestart;
        timeLeft = maxTimeSeconds - Time.realtimeSinceStartup;
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft = maxTimeSeconds - Time.realtimeSinceStartup;
    }


    private void OnExperienceCollected()
    {
        statisticsController.IncrementExperience();
    }
    private void OnLevelUp()
    {

    }
    private void OnUpgradeCollected()
    {

    }
    private void OnBoostCollected()
    {

    }
    private void OnSpawnEnemy()
    {

    }
    private void OnEnemyDead()
    {

    }
    private void OnPlayerDamaged()
    {

    }
    private void OnLevelRestart()
    {
        SceneManager.LoadScene(0);
    }
}
