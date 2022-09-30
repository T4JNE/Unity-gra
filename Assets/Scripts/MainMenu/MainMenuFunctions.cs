using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuFunctions : MonoBehaviour
{
    public Canvas MainMenuCanvas;
    public Canvas CreditsCanvas;
    public Canvas SettingsCanvas;
    public AudioSource BackgroundMusic;

    private bool IsCreditActive;
    private bool IsSettingActive;

    private void Start()
    {
        IsCreditActive = false;
        CreditsCanvas.enabled = IsCreditActive;

        IsSettingActive = false;
        SettingsCanvas.enabled = IsSettingActive;

        Slider slider = SettingsCanvas.GetComponentInChildren<Slider>();
        slider.value = GameSettings.Volume;

        Toggle toggle = SettingsCanvas.GetComponentInChildren<Toggle>();
        toggle.isOn = GameSettings.isNight;
    }

    public void PlayButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void CreditsButtonClick()
    {
        IsCreditActive = !IsCreditActive;
        CreditsCanvas.enabled = IsCreditActive;
    }
    public void SettingsButtonClick()
    {
        IsSettingActive = !IsSettingActive;
        SettingsCanvas.enabled = IsSettingActive;
    }
    public void VolumeChange(Slider Slider)
    {
        GameSettings.Volume = Slider.value;
        BackgroundMusic.volume = GameSettings.Volume;
    }
    public void Nightmode(Toggle toggle)
    {
        GameSettings.isNight = toggle.isOn;
    }
    public void QuitButtonClick()
    {
        Application.Quit();
    }
}
