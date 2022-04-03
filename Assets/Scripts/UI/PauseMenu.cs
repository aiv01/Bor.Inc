using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class PauseMenu : MonoBehaviour
{
    private Player player;
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    private void Awake()
    {
        player = ReInput.players.GetPlayer(0);
    }
    void Update()
    {
        if (player.GetButtonDown("Pause"))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        if (GameIsPaused)
        {
            if (player.GetButtonDown("MeleeController")) { LoadMenu(); }
            else if (player.GetButtonDown("OpenVendor")) { QuitGame(); }
            else if (player.GetButtonDown("Select")) { Resume(); }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }


    public void LoadMenu()
    {
        Debug.Log("go to menu");
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#endif
        Application.Quit();
    }
}
