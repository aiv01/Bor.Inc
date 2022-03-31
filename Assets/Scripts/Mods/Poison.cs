using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Poison", menuName = "Mod/Poison")]
public class Poison : Mod
{
    [SerializeField] float poisonTime = 5;
    [SerializeField] float hitsNeeded = 3;
    [SerializeField] float damagePerSec = 3;
    [SerializeField] ParticleSystem particlesPrefab;
    ParticleSystem particles;
    float currentPoisonTime;
    float currentHits;
    public override void Activate() {
        currentPoisonTime = poisonTime;
        currentHits = hitsNeeded;
        particles = GameObject.Instantiate(particlesPrefab, attachedTo.transform);
    }
    public override void Reactivate() {
        currentHits--;
    }

    public override void DoCicle() {
        if(currentHits <= 1) {
            if(!particles.isPlaying) particles.Play();
            currentPoisonTime -= Time.deltaTime;
            attachedTo.GetComponent<BaseController>().TakePassiveDamage(damagePerSec * Time.deltaTime);
            if(currentPoisonTime <= 0) {
                attachedTo.modsToRemove.Add(this);
            }
        }
    }
    public override void Disable() {
        Destroy(particles.gameObject);
    }
}
