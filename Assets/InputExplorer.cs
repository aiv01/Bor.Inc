using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class InputExplorer : MonoBehaviour
{
    private Player player;
    [SerializeField] private ExplorerController explorer;
    private void Awake() {
        player = ReInput.players.GetPlayer(0);
    }
    void Update()
    {
        if (player.GetButton("LeftClick")) {
            explorer.ClickPressed();
        }
        if (player.GetButtonDown("LeftClick")) {
            explorer.Click();
        }
        if (player.GetButtonDown("RightClick")) {
            explorer.RightClick();
        }
        if (player.GetButtonDown("ShootController")) {
            explorer.Shoot();
        }
        if (player.GetButtonDown("MeleeController")){
            explorer.Attack();
        }
        explorer.InputMove(player.GetAxis("MoveX"), player.GetAxis("MoveY"));
    }
}
