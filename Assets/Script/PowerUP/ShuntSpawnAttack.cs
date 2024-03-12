using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuntSpawnAttack : MonoBehaviour
{
    //public GameObject DamageEffects;
    // Start is called before the first frame update
    void Start()
    {
       // DamageEffects.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject,5f); 
    }
    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == "Obstacle")
        {
          //  DamageEffects.SetActive(true);
            Destroy(other.gameObject); // Destroy the collided obstacle
            Debug.Log(other.gameObject);
            Destroy(gameObject);       // Destroy the object with this script attached
        }
    }
}
