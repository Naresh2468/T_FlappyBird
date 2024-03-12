using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class BirdDamage : MonoBehaviour
{
    public Image healthBar;
    public int currentHealthBar = 100;
    public Image ShieldBar;
    public float currentShieldHealthBar = 100;
    public int damageAmount = 10;
    public float SdamageAmount = 10;
    public bool IsHudShiedActive = false;


    [Header("Others Scripts")]
    public GameMenu gameMenu;
    public Bird playerScript;

    
    // Start is called before the first frame update
    void Start()
    {
        healthBar.fillAmount  = 1f;
        ShieldBar.fillAmount = 0f;

        UpdateHealthBar();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Alpha2) && playerScript.ShieldActivate == true && playerScript.IsBoostUpActive == false )
        {
            IsHudShiedActive = true;
        }
        HUDShield();
    }

    //*********************HealthBar*****************************//
    void UpdateHealthBar()
    {
       
        if (healthBar != null)
        {
            healthBar.fillAmount  = (float)currentHealthBar / 100;
        }
        else
        {
            Debug.LogWarning("HealthBar not assigned in BirdDamage script.");
        }
    }
    public void TakeDamage(int damageAmount)
    {
        currentHealthBar  = currentHealthBar - damageAmount;

        if (currentHealthBar <= 0 )
        {
            gameMenu.RestartLevelEvent();
           // SceneManager.LoadScene("Game");
        }
        UpdateHealthBar();
       
    }
    public void HealthIncreased()
    {
          healthBar.fillAmount  = 1f;
    }

    //*********************ShieldBar*****************************//
    public void UpdateShieldBar()
    {
        if (ShieldBar != null)
        {
            ShieldBar.fillAmount = (float)currentShieldHealthBar / 100;
        }
    }
    public void ShieldDamage(float SdamageAmount)
    {
        currentShieldHealthBar = currentShieldHealthBar - SdamageAmount;
        if (currentShieldHealthBar <= 0)
        {
            Debug.Log("Unavailable to activate the shield");

        }
        UpdateShieldBar();
    }
    public void SheildHealthIncreased()
    {
          ShieldBar.fillAmount  = 1f;
    }
    public void HUDShield()
    {
        if (IsHudShiedActive == true)
        {
            ShieldDamage(0.35f);
            if (currentShieldHealthBar == 0f)
            {
                IsHudShiedActive = false;
            }
        }
    }
   

    // void DealDamage(Collider other)
    // {
    //     if (other.CompareTag("Obstacle"))
    //     {
    //        // BirdDamage playerHealth = other.GetComponent<BirdDamage>();
    //        // playerHealth.
    //        TakeDamage(damageAmount);
           
    //     }
    // }

    // private void OnTriggerEnter(Collider other)
    // {
    //     DealDamage(other);
    // }
}
