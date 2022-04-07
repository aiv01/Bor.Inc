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
    [SerializeField] bool inLobby = false;
    private Player player;
    bool entered;
    string pTag = "Player";
    void Start()
    {
        player = ReInput.players.GetPlayer(0);
    }

    // Update is called once per frame
    void Update()
    {
        if(entered && player.GetButtonDown("OpenVendor"))
        {
            if(!inLobby)ScriptableStaticClass.instance.level++;
            SaveManager.SaveStaticClassValues();
            if(ScriptableStaticClass.instance.level == 4 && inLobby)
            {
                SceneManager.LoadScene("BossRoom");
            }
            else { SceneManager.LoadScene(scene); }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag(pTag) && ScriptableStaticClass.instance.foundTreasure)
        {
            goBack.gameObject.SetActive(true);
            entered = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(pTag))
        {
            goBack.gameObject.SetActive(false);
            entered = false;
        }
    }
}
