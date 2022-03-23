using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[CreateAssetMenu(fileName = "New Swiftness", menuName = "Mod/Swiftness")]
public class Swiftness : Mod
{
    [SerializeField] float speedMult = 1;
    [SerializeField] ParticleSystem particlesPrefab;
    ParticleSystem particles;

    float oldSpeed;
    public override void Activate() {
        oldSpeed = attachedTo.GetComponent<BaseController>().speed;
        attachedTo.GetComponent<BaseController>().speed = oldSpeed * speedMult;
        particles = GameObject.Instantiate(particlesPrefab, attachedTo.transform);
        ParticleSystem.ShapeModule s = particles.shape;
        s.skinnedMeshRenderer = attachedTo.GetComponentInChildren<SkinnedMeshRenderer>();

    }
    public override void Disable() {
        attachedTo.GetComponent<NavMeshAgent>().speed = oldSpeed;
        attachedTo.GetComponent<BaseController>().speed = oldSpeed;
        Destroy(particles.gameObject);
    }
}
