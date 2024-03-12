using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class C_KeyType : MonoBehaviour
{
    public TMP_Text TextDisplay;
    public bool isCheckingKey = false;
    [SerializeField] float textDisplayStartTime = 0f;
    [SerializeField] float textDisplayDuration = 1.5f;
    // Update is called once per frame
    void Start()
    {
        TextDisplay.text = "";
    }
    void Update()
    {
        if (Input.anyKey)
        {
            if (!isCheckingKey)
            {
                isCheckingKey = true;
                Debug.Log("Key Input Checking Started");
            }

            foreach (KeyCode keyCode in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(keyCode))
                {
                    TextDisplay.text = "Key := "+keyCode.ToString();
                    textDisplayStartTime = Time.realtimeSinceStartup; // Record the start time when the key used.
                                            // track the actual time since the game started
                    //StartCoroutine(ClearTextAfterDelay(1.5f));
                }
            }
        }
        else if (isCheckingKey)
        {
            if (Time.realtimeSinceStartup - textDisplayStartTime > textDisplayDuration) //checking whether the time that has passed since  started displaying the text is greater than the desired duration for displaying the text.
            {
                 TextDisplay.text = "";
                 isCheckingKey = false;
                 Debug.Log("Key input checking stopped");
            }
           
        }
        
    }
    // IEnumerator ClearTextAfterDelay(float delay)
    // {
    //     yield return new WaitForSeconds(delay);
    //     TextDisplay.text = ""; // Clear the text after the specified delay
    // }
}
