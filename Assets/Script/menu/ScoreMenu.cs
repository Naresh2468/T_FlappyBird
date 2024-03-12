using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreMenu : MonoBehaviour
{
    public TMP_Text PlayerName;
    public TMP_Text BestScore;
    //public ScoreManager scoreManager;
    
    // Start is called before the first frame update
    void Start()
    {
        PlayerName.text = PlayerPrefs.GetString("PlayerName","");
        
        int HighScore =  PlayerPrefs.GetInt("HighScore",0 ); //check the concept of the layerPrefs get set key with condition
        BestScore.text = HighScore.ToString(); 
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Reset()
    {
        PlayerPrefs.DeleteKey("HighScore");
    }
}
