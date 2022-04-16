using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;
using UnityEngine.SceneManagement;

public class ButtonFinalScene : MonoBehaviour
{
    private Player player;

    void Start()
    {
        player = ReInput.players.GetPlayer(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetButtonDown("Select")) { NewGame();}
        if (player.GetButtonDown("OpenVendor")) { ExitGame();}
    }

    public void NewGame()
    {
        //ScriptableStaticClass.instance.Clear();
        //SaveManager.SaveStaticClassValues();
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
