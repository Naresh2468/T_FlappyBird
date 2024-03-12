using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;


public class MenuManager : MonoBehaviour
{
    public GameObject PlayBTN;
    public GameObject SettingBTN;
    public GameObject ExitBTN;
    public GameObject settingPanel;
    public GameObject settingGamePanel;
    public GameObject settingCreditPanel;
    public GameObject ScoreBoardPanel;
    public GameObject PlayerDetail;

    [Header("Audio")]
    public AudioMixer audioMixer;

    [Header("Resolution")]
    public Dropdown resolutionDropDown;
    Resolution[] resolutions;

    [Header("Animations")]
    public Animator FadeAnim;
    private void Start() 
    {
        resolutions = Screen.resolutions;

        resolutionDropDown.ClearOptions();
        List<string> options = new List<string>();
        
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i] .width + "x" + resolutions[i] .height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropDown.AddOptions(options);
        resolutionDropDown.value = currentResolutionIndex;
        resolutionDropDown.RefreshShownValue();

        PlayBTN.SetActive(true);
        SettingBTN.SetActive(true);
        ExitBTN.SetActive(true);

        settingPanel.SetActive(false);
        settingGamePanel.SetActive(false);
        settingCreditPanel.SetActive(false);
        ScoreBoardPanel.SetActive(false);
        PlayerDetail.SetActive(false);
        
    }
    public void Play()
    {
        PlayerDetail.SetActive(true);

        //
    }
    public void SettingGameBack()
    {
       // settingGamePanelBackButton.SetActive(false);
        settingGamePanel.SetActive(false);
        settingPanel.SetActive(true);

    }
   
    public void backToMainMENU()
    {
        settingPanel.SetActive(false);
        PlayBTN.SetActive(true);
        SettingBTN.SetActive(true);
        ExitBTN.SetActive(true);
    }
    public void SettingCreditPanelBack()
    {
        settingCreditPanel.SetActive(false);
        settingPanel.SetActive(true);
    }
    public void PlayerDetailOff()
    {
        PlayerDetail.SetActive(false);
    }
    public void SettingPanel()
    {
       
        PlayBTN.SetActive(false);
        SettingBTN.SetActive(false);
        ExitBTN.SetActive(false);
        settingPanel.SetActive(true);
    }
    public void SettingGamePanel()
    {
        settingGamePanel.SetActive(true);
        settingPanel.SetActive(false);
    }
    // Game Setting Value;
    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
    public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    public void SetFullscreen (bool isFullScreen)
    {
        Screen.fullScreen  = isFullScreen;
    }

    public void SetResolution (int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SettingCreditPanel()
    {
        settingCreditPanel.SetActive(true);
        settingPanel.SetActive(false);
    }
    public void ScorePanel()
    {
        settingPanel.SetActive(false);
        ScoreBoardPanel.SetActive(true);
    }
    public void BackScorepanel()
    {
        ScoreBoardPanel.SetActive(false);
        settingPanel.SetActive(true);
    }
    



    public void GoBack()
    {
        // Get the index of the current scene
        int currentIndex = SceneManager.GetActiveScene().buildIndex;

        // Subtract 1 from the current index to go back to the previous scene
        int previousIndex = currentIndex - 1;

        // Load the previous scene
        SceneManager.LoadScene(previousIndex);
    }
    public void Exit()
    {
        Application.Quit();
        Debug.Log("Application Quit");
    }

  
}
