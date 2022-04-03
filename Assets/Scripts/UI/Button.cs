using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    private Player player;

    void Awake()
    {
        player = ReInput.players.GetPlayer(0);
    }

    void Update()
    {
        if (player.GetButtonDown("OpenVendor")) { ExitGame();}
        else if(player.GetButtonDown("Select")) { NewGame();}
        else if (player.GetButtonDown("MeleeController")){ SettingsGame();}
        else if (player.GetButtonDown("ShootController")) { LoadGame(); }
    }


    public void NewGame()
    {
        ScriptableStaticClass.instance.Clear();
        SaveManager.SaveStaticClassValues();
        SceneManager.LoadScene("lobby");
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("lobby");
    }

    public void SettingsGame()
    {
        Debug.Log("fare scena settings");
        //SceneManager.LoadScene("settings");
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#endif
        Application.Quit();
    }
}
