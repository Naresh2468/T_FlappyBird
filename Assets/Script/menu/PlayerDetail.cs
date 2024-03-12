using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;
using TMPro;
public class PlayerDetail : MonoBehaviour
{
    public TMP_InputField  PlayerNameInput;
    public TMP_Text messageText;
    public Color warningColor = Color.red;
    public FadeOut Fade;

   
   // private int LevelToload;

    // Start is called before the first frame update
    void Start()
    {
        messageText.text = "";
    }
    public void CheckPlayerName()
    {
        string playername = PlayerNameInput.text.Trim();

        if (string.IsNullOrEmpty(playername))
        {
            messageText.text = "Please enter a valid player name.";
            messageText.color = warningColor;
            
        }
        if (playername.Length < 5 || playername.Length > 12)
        {
            messageText.text = "Player name must be between 8 and 10 characters.";
            messageText.color = warningColor;
            return;
        }
        if (!IsAlphaNumeric(playername))
        {
            messageText.text = "Player name should only contain letters and numbers.";
            messageText.color = warningColor;
            return;
        }
        if (PlayerNameExists(playername))
        {
            messageText.text = "Welcome back, " + playername + "Good to see you";
            messageText.color = Color.green;
          //  StartCoroutine(FirebaseDB.Instance.OpenGame());

            Fade.Fadeout();
             StartCoroutine(OpenGame());
           
            
        }
        else
        {
            messageText.text = "New player: " + playername;
            messageText.color = Color.green;
             // Store player name using PlayerPrefs
            PlayerPrefs.SetString("PlayerName", playername);
            PlayerPrefs.Save();
           // FirebaseDB.Instance.SavePlayerName(playername);
            Fade.Fadeout();
            StartCoroutine(OpenGame());
        }
    }
    private bool IsAlphaNumeric(string str)
    {
        return Regex.IsMatch(str, @"^[a-zA-Z0-9]+$");
    }
    private bool PlayerNameExists(string name)
    {
        string savedPlayerName = PlayerPrefs.GetString("PlayerName", "");
        return savedPlayerName.Equals(name);
        // Implement your logic to check if the player name already exists
        
        //return false;
    }

    private IEnumerator OpenGame()
    {
         yield return new WaitForSeconds(5.0f);
         SceneManager.LoadScene("Game");
    }
}
