using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowBird : MonoBehaviour
{
    public Transform  CameraTarget;
    public float speed = 10.0f;

    public Vector3 distance;
    public Transform lookTarget;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dPos = CameraTarget.position + distance;
        Vector3 sPos = Vector3.Lerp(transform.position,dPos, speed* Time.deltaTime);
        transform.position =sPos;
        transform.LookAt(lookTarget.position);
    }
}
