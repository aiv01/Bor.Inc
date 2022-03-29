using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(AudioSource))]
public class AudioMgr : MonoBehaviour
{
    [SerializeField] private AudioClip[] clips;
    [SerializeField] private AudioClip[] attackClips;
    [SerializeField] private AudioClip[] hurtClips;
    [SerializeField] private AudioClip[] shootClip;

    private AudioSource audioSorc;

    private void Awake()
    {
        audioSorc = GetComponent<AudioSource>();
    }

    private void Step()
    {
        AudioClip clip = GetRandomClip(clips);
        audioSorc.PlayOneShot(clip);
    }

    private void MeleeAttackStart()
    {
        AudioClip clip = GetRandomClip(attackClips);
        audioSorc.PlayOneShot(clip);
    }

    private void ShootStart()
    {
        AudioClip clip = GetRandomClip(shootClip);
        audioSorc.PlayOneShot(clip);
    }

    private void Shoot()
    {
        AudioClip clip = GetRandomClip(shootClip);
        audioSorc.PlayOneShot(clip);
    }

    private void HurtEvent()
    {
        AudioClip hurt = GetRandomClip(hurtClips);
        audioSorc.PlayOneShot(hurt);
    }
    private AudioClip GetRandomClip(AudioClip[] array)
    {
        return array[Random.Range(0, array.Length)];
    }
}
