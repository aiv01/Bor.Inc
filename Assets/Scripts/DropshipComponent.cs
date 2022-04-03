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
            SaveManager.SaveStaticClassValues();
            SceneManager.LoadScene(scene);
        }
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
