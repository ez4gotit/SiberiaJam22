using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    public enum collectableType { food, strength, stamina, health, speed }
    public collectableType type;
    [SerializeField] private LevelController levelController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
   public void UpgradePlayerStats()
    {
        switch (type)
        {
            case collectableType.food:
                levelController.playerController.SatietyRegenerate(100);
                break;            case collectableType.strength:
                levelController.playerSizeMultiplier *= 1.2f;
                levelController.playerDamageMultiplier *= 1.2f;
                levelController.playerSplashAttackRadius *= 1.2f;
                break;            case collectableType.health:
                levelController.playerMaxHealthMultiplier *= 1.2f;
                break;            case collectableType.stamina:
                levelController.playerStaminaRegenerationMultiplier *= 1.2f;
                break;            case collectableType.speed:
                levelController.playerMoveSpeedMultiplier *= 1.2f;
                
                break;
        }

    }


    public void levelControllerSetup(LevelController _enemyController)
        {
        levelController = _enemyController;
        }
}
