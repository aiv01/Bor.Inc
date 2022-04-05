using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class KeySoundEffect : MonoBehaviour
{
    AudioSource au;
    void Start()
    {
        au = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SoundKey()
    {
        au.Play();
    }
}
