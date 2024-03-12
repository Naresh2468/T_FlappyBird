using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menubird : MonoBehaviour
{
    public List<GameObject> waypoints;
    public float speed = 1.2f;
    int Index = 0;
    public bool isLoop = true;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {     
        Vector3 destination = waypoints[Index].transform.position;
        Vector3 newPos = Vector3.MoveTowards(transform.position,destination,speed * Time.deltaTime);
        transform.position = newPos;

        float distance = Vector3.Distance(transform.position,destination);
        if (distance <= 0.05)
        {
            if (Index < waypoints.Count - 1)
            {
                 Index++;
                 if (Index == 0)
                {
                        StartCoroutine(Wait());
                }
    
            }
            else
            {
                if (isLoop)
                {
                    Index = 0;
    
                }
            }  
        }
        // Rotate player towards the destination
        transform.LookAt(destination);
    }
    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(10);
        anim.Play("Run");
        Debug.Log("IDle");
    }
    
}
