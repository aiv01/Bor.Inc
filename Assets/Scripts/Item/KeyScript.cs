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
    void Start()
    {
        sound = FindObjectOfType<KeySoundEffect>();
    }
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            sound.SoundKey();
            gameObject.SetActive(false);
            info.nKeys++;
            
        }
    }
}
