// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using System.Text.RegularExpressions;
// using TMPro;
// using Firebase;
// using Firebase.Auth;
// using Firebase.Extensions;
// using Firebase.Firestore;

// public class FirebaseFirestore : MonoBehaviour
// {
    
//     public TMP_InputField  PlayerNameInput;
//     public TMP_Text messageText;

//     [SerializeField]private FirebaseAuth auth;
//     [SerializeField]private FirebaseFirestore firestore;
//     // Start is called before the first frame update
//     void Start()
//     {
//         FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
//         {
//             FirebaseApp app = FirebaseApp.DefaultInstance;
//             auth = FirebaseAuth.DefaultInstance;
//            // firestore = FirebaseFirestore.DefaultInstance;
//         });
//     }

//     // Update is called once per frame
//     void Update()
//     {
        
//     }
//     public void SavePlayerName()
//     {
//         string PlayerName = PlayerNameInput.text;
//         if (string.IsNullOrEmpty(PlayerName))
//         {
//             messageText.text = "Please enter your good name";
//             return;
//         }
//         // Check if the name exists in the database
//         CheckNameExists(PlayerName);
//     }
//     private void CheckNameExists(string playerName)
//     {
//         CollectionReference playersRefs = firestore.Collection("Players");
//         playersRefs.Document(playerName).GetSnapshotAsync().Document(playerName).GetSnapshotAsync().ContinueWithOnMainThread(task =>
//         {
//             if (task.Result.Exists)
//             {
//                 messageText.text = "Welcome back, " + PlayerName + "!";
//             }
//             else
//             {
//                 // Name doesn't exist, add it to the database
//                 docRef.SetAsync(new { }).ContinueWithOnMainThread(setTask =>
//                 {
//                     if (setTask.Exception != null)
//                     {
//                         messageText.text = "Error adding name.";
//                     }
//                     else
//                     {
//                         messageText.text = "Name added: " + PlayerName;
//                     }
//                 });
//             }
//         });
//     }
// }
