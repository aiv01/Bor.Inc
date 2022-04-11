using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[DisallowMultipleComponent]
public class HeartSound : MonoBehaviour
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

    public void HeartMusic()
    {
        au.Play();
    }
}