using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;
public class InputTest : MonoBehaviour
{
    private Player player;
    // Start is called before the first frame update
    void Awake()
    {
        player = ReInput.players.GetPlayer(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetButton("Shoot")) {
            Debug.Log("A");
        }
    }
}
