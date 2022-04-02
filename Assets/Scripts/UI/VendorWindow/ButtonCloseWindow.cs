using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;
using UnityEngine.UI;
public class ButtonCloseWindow : MonoBehaviour
{
    [SerializeField] Button exitButton;
    [SerializeField] GameObject window; 
    private Player player;

    void Start() {
        player = ReInput.players.GetPlayer(0);

    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetButtonDown("OpenVendor")) { CloseWindow(); }
    }

    public void CloseWindow()
    {
        window.SetActive(false);
        Time.timeScale = 1f;
    }
}
