using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPowerUp : MonoBehaviour
{
   // public float shieldDuration = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) 
    {
        Bird player = other.GetComponent<Bird>();
        
        // if (player != null)
        // {
        //    // player.ActivateShield(shieldDuration);

        //     Destroy(gameObject);
        // }
        
        if(other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
