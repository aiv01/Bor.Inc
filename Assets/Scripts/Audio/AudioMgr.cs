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
    [SerializeField] private AudioClip[] explosionClip;


    private AudioSource audioSorc;
    private AudioSource AudioSorc {
        get {
            if(!audioSorc) {
                audioSorc = GetComponent<AudioSource>();
            }
            return audioSorc;
        }
    }

    private void Step()
    {
        AudioClip clip = GetRandomClip(clips);
        AudioSorc.PlayOneShot(clip);
    }

    private void MeleeAttackStart()
    {
        AudioClip clip = GetRandomClip(attackClips);
        AudioSorc.PlayOneShot(clip);
    }

    private void ShootStart()
    {
        AudioClip clip = GetRandomClip(shootClip);
        AudioSorc.PlayOneShot(clip);
    }

    private void Shoot()
    {
        AudioClip clip = GetRandomClip(shootClip);
        AudioSorc.PlayOneShot(clip);
    }

    public void HurtEvent()
    {
        AudioClip hurt = GetRandomClip(hurtClips);
        AudioSorc.PlayOneShot(hurt);
    }
    private AudioClip GetRandomClip(AudioClip[] array)
    {
        return array[Random.Range(0, array.Length)];
    }

    private void StartAttack()
    {
        AudioClip clip = GetRandomClip(attackClips);
        AudioSorc.PlayOneShot(clip);
    }

    public void ExplosionBullet()
    {
        AudioClip clip = GetRandomClip(explosionClip);
        AudioSorc.PlayOneShot(clip);
    }

}
