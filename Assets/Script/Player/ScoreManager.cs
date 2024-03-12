using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{

    [Header("Player FreeSpace pipe Score")]
    public TMP_Text currentScoreText;
    public  int scoreCount = 0;
    public TMP_Text highestScoreText;
    public bool Isfreespace = false;

    BirdDamage birdDamage;
    public int PlayerHealth;

    [Header("Player Runner Score")]
    public TMP_Text RunScoreText;
    public Transform Player;

    [Header("PlayerDetail")]
    public TMP_Text CurrentPlayer;
    public Bird PlayerBird;
 
    // Start is called before the first frame update
    void Start()
    {
        string playerName = PlayerPrefs.GetString("PlayerName", "");
        //RunSCORE 
        RunScoreText.text = "Score:= 0";
        CurrentPlayer.text = playerName;
        PlayerPrefs.Save();
        highestScoreText.gameObject.SetActive(false);
                                            //     get score , default value
        int HighScore =  PlayerPrefs.GetInt("HighScore",0 ); //Typecasting
         highestScoreText.text = "HighScore:- "+HighScore.ToString();
        birdDamage = FindObjectOfType<BirdDamage>();
    }

    // Update is called once per frame
    void Update()
    {
        ScoreUpdateCount(); 
        RunScore();
        //PipeScore
        currentScoreText.text = "Score:- " + Mathf.Round(scoreCount);
        int PlayerHealth = birdDamage.currentHealthBar;
        if (PlayerHealth == 0)
        {
            highestScoreText.text = "Highest Score:- " + Mathf.Round(scoreCount);
            if (scoreCount >  PlayerPrefs.GetInt("HighScore",0))
            {
                PlayerPrefs.SetInt("HighScore",scoreCount);
                highestScoreText.gameObject.SetActive(true);
                highestScoreText.text = "HighScore:- "+scoreCount.ToString();
                Debug.Log("Highscore");
                GetScore();
            }
           
        }  
    }
    public void RunScore()
    {
        if (PlayerBird.isPlayGame == true)
        {
            RunScoreText.text = "Run Score:= "+Player.position.z.ToString("0");
        }
        
    }
    public void GetScore()
    {
        highestScoreText.text = "HighScore:- "+scoreCount.ToString();
    }
    public void ScoreUpdateCount()
    {
        if(Isfreespace == true)
        {
            scoreCount = scoreCount + 1;
            Isfreespace = false;
        }
        
    }
    
    private void OnTriggerEnter(Collider other) {
    if(other.gameObject.tag == "ScoreSpace")
        {
            Isfreespace = true;
            Destroy(other.gameObject);
        }
    }
    public void Reset()
    {
        PlayerPrefs.DeleteKey("HighScore");
    }



}
