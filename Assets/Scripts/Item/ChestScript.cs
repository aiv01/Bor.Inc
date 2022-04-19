using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Rewired;
using UnityEngine.Audio;

public class ChestScript : MonoBehaviour
{
    Animator anim;
    private Player player;
    [SerializeField] ScriptableStaticClass info;
    GameObject tx;
    Text needKey;
    Text itemFind;
    AudioSource au;
    bool entered = false;
    bool opened;
    private string pTag = "Player";
    public bool finalChest = false;
    private void Awake()
    {
        tx = GameObject.Find("OpenTextChest");
        needKey = GameObject.Find("Needkey").GetComponent<Text>();
        itemFind = GameObject.Find("ItemFind").GetComponent<Text>();
        au = GetComponent<AudioSource>();
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
                au.Play();
                info.nKeys--;
                itemFind.gameObject.SetActive(false);
                itemFind.gameObject.SetActive(true);
                if (finalChest) info.foundTreasure = true;
                itemFind.text = !finalChest ? info.FindNewBundle().description : "<color=yellow>Treasure recovered, you can now go back to base</color>";

            }
        }
    }
        

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(pTag) && !opened)
        {
            if (info.nKeys >= 1)
                tx.SetActive(true);
            else needKey.gameObject.SetActive(true);
            entered = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(pTag))
        {
            tx.SetActive(false);
            needKey.gameObject.SetActive(false);
            entered = false;
        }
    }
}
