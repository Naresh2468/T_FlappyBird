using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FPS : MonoBehaviour
{
    public TMP_Text fpstext;
    public float updateInterval = 0.5f;
    private float accumlated = 0f;
    private int frames = 0;
    private float timeLeft;
    public TMP_Text fpsNotification;


  

    public void start()
    {
        timeLeft = updateInterval;
        
    }

    private void Update()
    {

        if(timeLeft <= 0f)
        {
            float fps = accumlated / frames;
            fpstext.text = $"FPS: {fps:F2}";

            // int fps = (int)accumlated / frames;
            // fpstext.text = $"FPS: {fps:F2}";
            
           
            if (fps < 30)
            {
                fpstext.color = Color.red;
                fpsNotification.text = "Weak strength FPS";
                fpsNotification.color = Color.red;

            }
            else if (fps >= 30 && fps <= 60)
            {
                fpstext.color = Color.yellow;
                fpsNotification.text = "Medium strength FPS";
                fpsNotification.color = Color.yellow;
            }
            else if (fps > 60)
            {
                fpstext.color = Color.green;
                fpsNotification.text = "Strong strength FPS";
                fpsNotification.color = Color.green;
            }
            timeLeft = updateInterval;
            accumlated = 0f;
            frames = 0;
        }
        timeLeft -= Time.deltaTime;
        accumlated += Time.timeScale / Time.deltaTime;
        frames++; //frames = frames + 1;
        
    }


}
