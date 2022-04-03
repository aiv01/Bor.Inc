using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Rewired;

public class DropshipComponent : MonoBehaviour
{
    [SerializeField]Text goBack;
    [SerializeField] string scene;
    private Player player;
    bool entered;
    void Start()
    {
        player = ReInput.players.GetPlayer(0);
    }

    // Update is called once per frame
    void Update()
    {
        if(entered && player.GetButtonDown("OpenVendor"))
        {
            Save();
            SceneManager.LoadScene(scene);
        }
    }
    private void Save() {
        SaveObject so = new SaveObject();
        so.collectedBundles = ScriptableStaticClass.instance.GetCollectedItems();
        so.inInventory = ScriptableStaticClass.instance.GetInInventoryItems();
        so.nKeys = ScriptableStaticClass.instance.nKeys;
        so.level = ScriptableStaticClass.instance.level;
        so.explorerNumber = ScriptableStaticClass.instance.explorerNumber;
        SaveManager.Save(so);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && ScriptableStaticClass.instance.foundTreasure)
        {
            goBack.gameObject.SetActive(true);
            entered = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            goBack.gameObject.SetActive(false);
            entered = false;
        }
    }
}
