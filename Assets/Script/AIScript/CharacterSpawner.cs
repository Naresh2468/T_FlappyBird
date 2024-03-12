using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    public GameObject[] AIprefabs;
    public int AItoSpawn;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Spawn()
    {
        int count = 0;
        while (count < AItoSpawn)
        {
            int randomIndex = Random.Range(0,AIprefabs.Length); //Random Spawn
            GameObject obj  = Instantiate(AIprefabs[randomIndex]);
            Transform child = transform.GetChild(Random.Range(0 , transform.childCount  - 1));
            obj.GetComponent<WaypointNavigator>().currentWaypoint = child.GetComponent<Waypoint>();
            obj.transform.position = child.position;

            yield return new WaitForSeconds(1f);

            count++;
        }
    }

}
