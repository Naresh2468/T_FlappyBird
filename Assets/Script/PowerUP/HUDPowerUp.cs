using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDPowerUp : MonoBehaviour
{
    [Header("FireBall")]
    public Image FireBall;
    public Image UnFireBall;
    public Image One;

    [Header("Shield")]
    public Image Shield;
    public Image UnShield;
    public Image Two;

    [Header("FirstAid")]
    public Image FirstAid;
    public Image UnFirstAid;
    public Image Three;

    [Header("BoostUp")]
    public Image BoostUp;
    public Image UnBoostUp;
    public Image Four;

     [Header("Other Script")]
     public Bird playerScript;
    // Start is called before the first frame update
    void Start()
    {
        FireBall.gameObject.SetActive(true);
        UnFireBall.gameObject.SetActive(true);
        Shield.gameObject.SetActive(true);
        UnShield.gameObject.SetActive(true);
        FirstAid.gameObject.SetActive(true);
        UnFirstAid.gameObject.SetActive(true);
        BoostUp.gameObject.SetActive(true);
        UnBoostUp.gameObject.SetActive(true);
        One.gameObject.SetActive(false);
        Two.gameObject.SetActive(false);
        Three.gameObject.SetActive(false);
        Four.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        PowerUpHUD();
        
    }
    public void PowerUpHUD()
    {
        //Shunt(FireBall)
        if (playerScript.IsShuntAttack == true)
        {
           SetImageOpacity(FireBall, 1f); 
           One.gameObject.SetActive(true);
        }
        else
        {
            SetImageOpacity(FireBall, 0.25f); 
            One.gameObject.SetActive(false);
        }

        //FirstAid
        if (playerScript.FirstAidActivate == true)
        {
           SetImageOpacity(FirstAid, 1f); 
           Three.gameObject.SetActive(true);
        }
        else
        {
            SetImageOpacity(FirstAid, 0.25f);
            Three.gameObject.SetActive(false); 
        }

        //ShieldUp
        if (playerScript.ShieldActivate == true)
        {
           SetImageOpacity(Shield, 1f); 
           Two.gameObject.SetActive(true);
        }
        else
        {
            SetImageOpacity(Shield, 0.25f);
            Two.gameObject.SetActive(false); 
        }
        
        //BoostUp
        if (playerScript.IsBoostUpActive == true)
        {
            SetImageOpacity(BoostUp, 1f);
            Four.gameObject.SetActive(true);
        }
        else
        {
            SetImageOpacity(BoostUp, 0.25f);
            Four.gameObject.SetActive(false);
        }
    }
    
    // Method to set the opacity of an Image component
    private void SetImageOpacity(Image image, float opacity)
    {
        Color color = image.color;
        color.a = opacity; // Set the alpha channel of the color (opacity)
        image.color = color;
    }

    
}
