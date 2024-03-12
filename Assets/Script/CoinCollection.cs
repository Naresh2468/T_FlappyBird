using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CoinCollection : MonoBehaviour
{
    public float TurnSpeed = 90f;
 

    //[Header("Magnetic Variable")]
    // public Transform playerTransform;
    // public float moveSpeed = 15f;
   // CoinMove coinMoveScript;
    // public TMP_Text coinScore;
    // public AudioSource myAudio;
    // public AudioClip coinCollection;
    // public int CoinScoreNum;
    // Start is called before the first frame update
    void Start()
    {
       //playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    //    coinMoveScript = gameObject.GetComponent<CoinMove>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0,TurnSpeed * Time.deltaTime);
        
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
        // if(other.gameObject.tag == "CoinDetect")
        // {
        //     coinMoveScript.enabled = true;
        // }
    }
   
}
