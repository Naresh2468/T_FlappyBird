using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAttack : MonoBehaviour
{
    
    public GameObject PFire1Prefab;
    public GameObject PFire2Prefab;
    // Start is called before the first frame update
    void Start()
    {
        PFire1Prefab.SetActive(false);
        PFire2Prefab.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PFire1Prefab.SetActive(true);
            PFire2Prefab.SetActive(true);
        }
        
    }
}
