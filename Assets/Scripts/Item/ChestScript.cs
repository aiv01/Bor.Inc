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
    GameObject tx;
    Text itemFind;
    bool entered = false;
    bool opened;
    bool finalChest = false;
    private void Awake()
    {
        tx = GameObject.Find("OpenTextChest");
        itemFind = GameObject.Find("ItemFind").GetComponent<Text>();
    }
    void Start()
    {
        player = ReInput.players.GetPlayer(0);
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(info.nKeys >= 1){
            if (!opened && entered && player.GetButtonDown("OpenVendor"))
            {
                opened = true;
                tx.SetActive(false);
                anim.SetBool("Open", true);
                info.nKeys--;
                itemFind.gameObject.SetActive(true);
                
                itemFind.text = !finalChest ? info.FindNewBundle().description : "<color=yellow>Treasure recovered, you can now go back to base</color>";

            }
        }
    }
        

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && !opened)
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
