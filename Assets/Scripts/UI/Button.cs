using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;
using UnityEngine.UI;
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
    }


    public void NewGame()
    {
        SceneManager.LoadScene("lobby");
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#endif
        Application.Quit();
    }
}
