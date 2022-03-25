using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[CreateAssetMenu(fileName = "New Slowness", menuName = "Mod/Slowness")]
public class Slowness : Mod
{
    [SerializeField] float slownessMult = 0.2f;
    float currentSlownessMult = 0.2f;
    [SerializeField] ParticleSystem particlesPrefab;
    ParticleSystem particles;
    [SerializeField] float blockedTime = 5;

    float currentBlockedTime;
    float oldSpeed;
    public override void Activate() {
        currentSlownessMult = slownessMult;
        currentBlockedTime = blockedTime;
        oldSpeed = attachedTo.GetComponent<BaseController>().speed;
        attachedTo.GetComponent<BaseController>().speed = oldSpeed * (1 - currentSlownessMult);
        if(particlesPrefab) particles = GameObject.Instantiate(particlesPrefab, attachedTo.transform);
    }
    public override void Reactivate() {
        currentSlownessMult += slownessMult;
        if (currentSlownessMult >= 1) currentSlownessMult = 1;
        attachedTo.GetComponent<BaseController>().speed = oldSpeed * (1 - currentSlownessMult);
        attachedTo.GetComponent<NavMeshAgent>().speed = oldSpeed * (1 - currentSlownessMult);

    }
    public override void DoCicle() {
        if (currentSlownessMult >= 1) {
            currentBlockedTime -= Time.deltaTime;
            if (currentBlockedTime <= 0) {
                attachedTo.modsToRemove.Add(this);
            }
        }
    }
    public override void Disable() {
        attachedTo.GetComponent<NavMeshAgent>().speed = oldSpeed;
        attachedTo.GetComponent<BaseController>().speed = oldSpeed;
        if (particlesPrefab) Destroy(particles.gameObject);
    }
}
