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
    public bool entered = false;
    string pTag = "Player";
    void Start()
    {
        player = ReInput.players.GetPlayer(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (entered && player.GetButtonDown("OpenVendor") && !ScriptableStaticClass.instance.pauseOn)
        {
            ScriptableStaticClass.instance.vendorOpen = true;
            tx.gameObject.SetActive(false);
            window.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(pTag))
        {
            tx.gameObject.SetActive(true);
            entered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag(pTag))
        {
            tx.gameObject.SetActive(false);
            entered = false;
            
        }
    }
}
