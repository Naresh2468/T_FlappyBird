using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointNavigator : MonoBehaviour
{
    [Header("NPC Character")]
    public AICharacter character;
    public Waypoint currentWaypoint;

    public Waypoint WaypointInitial;
    public Waypoint waypointNext;
    public Animator BirdAnimate;
    public float WaitDuration = 5f;
    private bool isIdle = true;

    
    private void Awake() {
        character = GetComponent<AICharacter>();
        BirdAnimate = GetComponent<Animator>();

    }
    // Start is called before the first frame update
    void Start()
    {
        character.LocateDestination(currentWaypoint.GetPosition());
    }

    // Update is called once per frame
    void Update()
    {
         
        if (isIdle)
        {
             BirdAnimate.SetTrigger("ExitIdle");
        }
        
        
        if (character.destinationReached)
        {
            character.LocateDestination(currentWaypoint.GetPosition());  
            if (currentWaypoint == null)
            {
                Debug.LogError("No waypoint assigned");
                return;
            }
            if (isIdle == false)
            {
                BirdAnimate.SetTrigger("Idle");
                currentWaypoint = currentWaypoint.nextWaypoint;
                character.LocateDestination(currentWaypoint.GetPosition());
            }
            if (currentWaypoint.nextWaypoint == waypointNext)
            {
                 if (currentWaypoint == WaypointInitial )
                {
                Debug.Log("Start Idle ");
                StartCoroutine(IdleAndContinue(WaitDuration));
                }
            }
            
             
            
           
            
        }
        
    }
    IEnumerator IdleAndContinue(float idleDuration)
    {
        isIdle =  true;
        Debug.Log("Idle 10 ");
        yield return new WaitForSeconds(idleDuration);
        isIdle = false;
        Debug.Log("Motion");
       
    }
}  
