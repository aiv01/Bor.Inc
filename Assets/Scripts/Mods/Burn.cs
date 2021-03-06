using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Burn", menuName = "Mod/Burn")]
public class Burn : Mod
{
    [SerializeField] float fireTime = 1;
    [SerializeField] float hitsNeeded = 1;
    [SerializeField] float damagePerSec = 3;
    [SerializeField] ParticleSystem particlesPrefab;
    ParticleSystem particles;
    float currentFireTime;
    float currentHits;
    public override void Activate()
    {
        currentFireTime = fireTime;
        currentHits = hitsNeeded;
        particles = GameObject.Instantiate(particlesPrefab, attachedTo.transform);
    }
    public override void Reactivate()
    {
        currentHits--;
    }

    public override void DoCicle()
    {
        if (currentHits <= 1)
        {
            if (!particles.isPlaying) particles.Play();
            currentFireTime -= Time.deltaTime;
            attachedTo.GetComponent<BaseController>().TakePassiveDamage(damagePerSec * Time.deltaTime);
            if (currentFireTime <= 0)
            {
                attachedTo.modsToRemove.Add(this);
            }
        }
    }
    public override void Disable()
    {
        Destroy(particles.gameObject);
    }
}
