using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public GameObject PauseButton;
    public GameObject Gamemenu;
    public GameObject RestartLevel;
    public GameObject GameSettingPanel;
    public GameObject BackTOMenuPanel;
    public bool IsPaused = false;
    [SerializeField]public bool IsBackMenu = true;
   // public GameObject BackButton;

    [Header("KeyMapping ")]
    public GameObject KeyMapping;

    [Header("FPS Settings")]
    public GameObject FPSScreen;
    public GameObject FPSPanel;
    public GameObject FpsMeterMonitor;
    public GameObject FpsMeterNotify;
    public GameObject LagMeter;
    public bool isFPSMonitor = false;
    public bool isFPSNotify = false;
    public bool isLagMeter = false;
    
   // Start is called before the first frame update
    void Start()
    {
        FPSScreen.SetActive(false);
        PauseButton.SetActive(true);
        Gamemenu.SetActive(false);
        RestartLevel.SetActive(false);
        GameSettingPanel.SetActive(false);
        FPSPanel.SetActive(false);
        FpsMeterMonitor.SetActive(false);
        FpsMeterNotify.SetActive(false);
        LagMeter.SetActive(false);
        KeyMapping.SetActive(false);
        BackTOMenuPanel.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused && IsBackMenu == true)
            {
                ResumeGame();
            }
            else
            {
                if (IsBackMenu == true)
                {
                    PauseGame();
                }
                
            }
        }

        // if (Input.GetKeyDown(KeyCode.Escape))
        // {
        //     PauseButton.SetActive(false);
        //     Time.timeScale = 0;
        //     Gamemenu.SetActive(true);
        // }
      
    }

    void PauseGame()
    {
        IsPaused = true;
        
        PauseButton.SetActive(false);
        Time.timeScale = 0;
        Gamemenu.SetActive(true);
    }
    void ResumeGame()
    {
        IsPaused = false;
        IsBackMenu = true;
        KeyMapping.SetActive(false);
        GameSettingPanel.SetActive(false);
        BackTOMenuPanel.SetActive(false);
        FPSPanel.SetActive(false);
        PauseButton.SetActive(true);
        Time.timeScale = 1; // Resume normal time scale
        Gamemenu.SetActive(false);
    }

    //Back To Menu  Setting
    public void YesExit()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    } 
    public void NOExit()
    {
        IsBackMenu = true;
        BackTOMenuPanel.SetActive(false);
       
        Gamemenu.SetActive(true);
    }

    public void BackTOMenu()
    {
       
        IsBackMenu = false;
       // IsPaused = false;
        Gamemenu.SetActive(false);
      
        BackTOMenuPanel.SetActive(true);
       // SceneManager.LoadScene("MainMenu");
       
    }

   




    public void PauseEvent()
    {
        IsPaused = true;
        PauseButton.SetActive(false);
        Time.timeScale = 0;
        Gamemenu.SetActive(true);
    }
    public void Play()
    {
        Gamemenu.SetActive(false);
        Time.timeScale = 1;
        PauseButton.SetActive(true);
    }
    



    //RestartLevel
    public void RestartLevelEvent()
    {
        Time.timeScale = 0;
        PauseButton.SetActive(false);
        RestartLevel.SetActive(true);
    }
    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
    }


    //setting Panel
    public void INGameSettingPanel()
    {
        PauseButton.SetActive(false);
        Gamemenu.SetActive(false);
        GameSettingPanel.SetActive(true); 
       

    }
    public void SettingBackButton()
    {
        GameSettingPanel.SetActive(false); 
       // PauseButton.SetActive(true);
        Gamemenu.SetActive(true);
    }



    /// FPS PANEL 
    public void InFPSPanel()
    {
        GameSettingPanel.SetActive(false);
        FPSPanel.SetActive(true);
    }

    public void DisplayFPSMontior(bool isFPSMonitor)
    {
        FPSScreen.SetActive(isFPSMonitor);
        FpsMeterMonitor.SetActive(isFPSMonitor);
        
    }
    public void DisplayFPSNotify(bool isFPSNotify)
    {
        FPSScreen.SetActive(isFPSNotify);
        FpsMeterNotify.SetActive(isFPSNotify);
    }
    public void DisplayLagMeter(bool isLagMeter)
    {
        FPSScreen.SetActive(isLagMeter);
        LagMeter.SetActive(isLagMeter);
    }
    public void FPSBackButton()
    {
        FPSPanel.SetActive(false);
        GameSettingPanel.SetActive(true);
    }
    public void DisplayKeyMapping()
    {
        GameSettingPanel.SetActive(false);   
        KeyMapping.SetActive(true);
    }
    public void KeyMappingBackButton()
    {
        KeyMapping.SetActive(false);
        GameSettingPanel.SetActive(true);   
         
    }


}
