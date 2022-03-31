using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Rewired;

public class ChestScript : MonoBehaviour
{
    Animator anim;
    private Player player;
    [SerializeField] ScriptableStaticClass info;
    [SerializeField] GameObject tx;
    bool entered = false;

    void Start()
    {
        player = ReInput.players.GetPlayer(0);
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(info.nKeys >= 1){
            if (entered && player.GetButtonDown("OpenVendor"))
            {
                tx.SetActive(false);
                anim.SetBool("Open", true);
                info.nKeys--;
                //spawn oggetti;
            }
        }
    }
        

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            tx.SetActive(true);
            entered = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            tx.SetActive(false);
            entered = false;
        }
    }
}
