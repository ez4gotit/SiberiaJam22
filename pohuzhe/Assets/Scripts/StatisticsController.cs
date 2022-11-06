using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatisticsController : MonoBehaviour
{

    public float deadEnemiesAmount { get; private set; } = 0;
    public float experienceCollected { get; private set; } = 0;
    public float playerLevel { get; private set; } = 0;
    public float playerScore { get; private set; } = 0;
    public GameObject upgradeMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(experienceCollected >0 && experienceCollected%10 ==0)
        {
            playerLevel++;
            upgradeMenu.SetActive(true) ;
        }
    }


    public void IncrementExperience()
    {
        experienceCollected ++;
    }
}
