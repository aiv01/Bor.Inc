using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class KeyScript : MonoBehaviour
{
    [SerializeField] ScriptableStaticClass info;
    //[SerializeField]AudioClip clip;
    [SerializeField]AudioSource au;
    KeySoundEffect sound;
    string pTag = "Player";
    void Start()
    {
        sound = FindObjectOfType<KeySoundEffect>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag(pTag))
        {
            sound.Sound();
            gameObject.SetActive(false);
            info.nKeys++;
            
        }
    }
}
