using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetRotate : MonoBehaviour
{
    public float TurnSpeed = 90f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,TurnSpeed * Time.deltaTime,0);
    }
   
}
