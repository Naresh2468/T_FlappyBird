using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DiamondCollection : MonoBehaviour
{
    public float TurnSpeed = 90f;
    // public TMP_Text diamondScore;
    // public AudioSource myAudio;
    // public AudioClip DimaondCollection;
    // public int DiamondScoreNum;
    // Start is called before the first frame update
    // void Start()
    // {
    //     myAudio = GetComponent<AudioSource>();
    //     DiamondScoreNum = 0;
    //     diamondScore.text = ""+DiamondScoreNum;
    // }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,TurnSpeed * Time.deltaTime,0);
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player")
        {
            
            Destroy(gameObject);
        }
    }
}
