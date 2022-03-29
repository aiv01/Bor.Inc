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
            explorer.ClickDown();
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
        if(player.GetAxis("MoveXController") != 0 || player.GetAxis("MoveYController") != 0)
            explorer.InputControllerMove(player.GetAxis("MoveXController"), player.GetAxis("MoveYController"));
        else if(player.GetAxis("MoveXKeyboard") != 0 || player.GetAxis("MoveYKeyboard") != 0)
            explorer.InputKeyboardMove(player.GetAxis("MoveXKeyboard"), player.GetAxis("MoveYKeyboard"));
    }
}
