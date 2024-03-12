using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LagRate : MonoBehaviour
{
    public TMP_Text lagPercentageText;

    private float lagThreshold = 0.01667f; // 60 FPS equivalent frame time
    private float laggyFrameCount = 0;
    private float totalFrameCount = 0;
    private float updateInterval = 1f; // Update once per second
    private float updateTimeLeft;
   

    private void Start()
    {
        updateTimeLeft = updateInterval;
    }

    private void Update()
    {
        float frameTime = Time.deltaTime;

        if (frameTime > lagThreshold)
        {
            laggyFrameCount++;
        }
        
        totalFrameCount++;
        updateTimeLeft -= Time.deltaTime;

        if (updateTimeLeft <= 0f)
        {
            int lagPercentage = Mathf.RoundToInt((laggyFrameCount / (float)totalFrameCount) * 100f);
            lagPercentageText.text = $"Lag Rate: {lagPercentage} %";
           // lagMeterFill.fillAmount = lagPercentage / 100f;

            if (lagPercentage > 60)
            {
                lagPercentageText.color = Color.red;
            }else if(lagPercentage >=30 && lagPercentage <= 59)
            {
                lagPercentageText.color = Color.yellow;
            }
            else if(lagPercentage < 29)
            {
                lagPercentageText.color = Color.green;
            }
            


            laggyFrameCount = 0;
            totalFrameCount = 0;
            updateTimeLeft = updateInterval;
        }
    }
}
