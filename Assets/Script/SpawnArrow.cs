using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArrow : MonoBehaviour
{
    public GameObject ArrowPrefabs;
    public Transform SpawnPoint;
    public float spawnZAxis = 0f; // The Z-axis value for the spawn point
    public float DestroyDelay = 2f;// The delay before destroying the instantiated object
    public float ArrowMoveSpeed = 5f;

    private void Start()
    {
        InvokeRepeating("SpawnObject" , 1.5f ,1.5f);
    }
    private void SpawnObject()
    {
        Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y, spawnZAxis);
        GameObject ArrowSpawn = Instantiate(ArrowPrefabs, spawnPosition ,Quaternion.identity);
        ArrowSpawn.transform.Translate(Vector3.forward * ArrowMoveSpeed * Time.deltaTime);
        Rigidbody rb = ArrowSpawn.GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = ArrowSpawn.AddComponent<Rigidbody>();
        }

        rb.velocity = new Vector3(0f, 0f, -ArrowMoveSpeed);
        
        Destroy(ArrowSpawn,DestroyDelay);
    }
    
   
}
