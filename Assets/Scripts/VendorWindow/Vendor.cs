using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Rewired;

public class Vendor : MonoBehaviour
{
    private Player player;
    [SerializeField] GameObject window;
    [SerializeField] Text tx;
    void Start()
    {
        player = ReInput.players.GetPlayer(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetButtonDown("OpenVendor"))
        {
            tx.gameObject.SetActive(false);
            window.SetActive(true);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            tx.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            tx.gameObject.SetActive(false);
        }
    }
}
