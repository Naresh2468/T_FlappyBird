using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using TMPro;
using System.Threading.Tasks;

public class FirebaseDB : MonoBehaviour
{
    private string  playerId;
    [SerializeField] public DatabaseReference databaseReference;
    public TMP_InputField  PlayerNameInput;
    
  
    private void Start() {
        playerId = SystemInfo.deviceUniqueIdentifier; // Use a unique identifier for each player
        
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
        FirebaseApp app = FirebaseApp.DefaultInstance;
        if (app == null) {
            app = FirebaseApp.Create();
        }
        // Specify your Realtime Database URL here
        DatabaseReference databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
            Debug.Log("Database Reference: " + databaseReference);
        });
    }


    public void SavePlayerName(string playername)
    {
        
        playerId = SystemInfo.deviceUniqueIdentifier;
        DatabaseReference databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
        Debug.Log("Database Reference: " + databaseReference);
        if (PlayerNameInput != null)
            {
                PlayerData playerData = new PlayerData(PlayerNameInput.text);
                string json = JsonUtility.ToJson(playerData);
               
                databaseReference.Child("Players").Child(playerId).SetRawJsonValueAsync(json);
                //databaseReference.Child("Player").Child(playerId).SetRawJsonValueAsync(json);
                
            }
            else
            {
                Debug.LogError("PlayerNameInput is not assigned.");
            }

    }
   
  
}
[System.Serializable]
public class PlayerData
{
    public string playername;

    public PlayerData(string playername)
    {
        this.playername = playername;
    }
}
