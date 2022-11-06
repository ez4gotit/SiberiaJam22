using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    public UnityAction Damaged;
    public UnityAction Died;
    public UnityAction Run;
    public UnityAction Eat;
    public UnityAction Throw;
    public UnityAction Idle;
    public UnityAction Shield;
    public UnityAction Attack;
    public LevelController levelController;
    public float health { get; private set; } = 100;
    public float stamina { get; private set; } = 100;
    public float satiety { get; private set; } = 100;
    public float staminaReduceSpeed = 10f;
    public float staminaRegenerationSpeed = 5f;
    public float satietyReduceSpeed = 20f;
    public const float stunLength = 0.2f;
    public bool isProtected = false;
    [SerializeField]private AnimationController animationController;
    [SerializeField]private InputControls inputControls;
    [SerializeField] private float maxStamina= 100;
    [SerializeField] private float maxSatiety= 100;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(stamina + "   " + satiety);
        clampStamina();
        Run.Invoke();
        if(satiety>=0)
        {
            satiety -= Time.deltaTime*satietyReduceSpeed;
            StaminaRegenerate(staminaRegenerationSpeed*Time.deltaTime*levelController.playerStaminaRegenerationMultiplier);
        }
    }

    public void HealthReduce(float damage)
    {
        if (!isProtected)
        {
            health -= damage;
            if (health <= 0)
            {
                Died.Invoke();
                return;
            }
            if (Damaged != null) Damaged.Invoke();
        }
    }
    public void StaminaRegenerate(float amount)
    {
        stamina += amount;
        
    }
    public void StaminaReduce(float amount)
    {
        stamina -= amount;
    }
    public void SatietyRegenerate(float amount)
    {
        satiety += amount;
    }

    private void clampStamina()
    {
        if (stamina >= maxStamina*levelController.playerMaxStaminaMultiplier) stamina = maxStamina*levelController.playerMaxStaminaMultiplier;
    }
    public void ExpIncrement()
    {
        levelController.statisticsController.IncrementExperience();
    }

}
