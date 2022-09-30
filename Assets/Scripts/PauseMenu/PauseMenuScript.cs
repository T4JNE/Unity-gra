using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public static bool GamePaused;
    public Canvas PauseMenuUI;
    public Canvas DeathMenuUI;
    public AudioSource BackgroundMusic;

    Player player;

    // Start is called before the first frame update
    void Start()
    {
        var playerObj = GameObject.Find("Player");
        player = playerObj.GetComponent<Player>();
        player.OnHealthChange.AddListener(PlayerDied);

        DeathMenuUI.enabled = false;
        GamePaused = false;
        Pause(GamePaused);

        BackgroundMusic.volume = GameSettings.Volume;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && player.Health > 0)
        {
            GamePaused = !GamePaused;
            Pause(GamePaused);
        }
    }

    private void Pause(bool SetPause)
    {
        PauseMenuUI.enabled = SetPause;

        if(SetPause)
        {
            Time.timeScale = 0f;

            BackgroundMusic.volume /= 2;
        }     
        else
        {
            Time.timeScale = 1f;

            BackgroundMusic.volume *= 2;
        }
            
    }

    public void ResumeButtonClick()
    {
        GamePaused = false;
        Pause(GamePaused);
    }

    public void RestartButtonClick()
    {
        GamePaused = false;
        Time.timeScale = 1f;
        DeathMenuUI.enabled = false;
        BackgroundMusic.volume = GameSettings.Volume;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PlayerDied()
    {
        if (player.Health > 0)
            return;

        BackgroundMusic.volume /= 2;
        GamePaused = true;
        Time.timeScale = 0f;
        DeathMenuUI.enabled = true;
    }

    public void MenuButtonClick()
    {
        GamePaused = false;
        Pause(GamePaused);

        SceneManager.LoadScene(0);
    }
}
