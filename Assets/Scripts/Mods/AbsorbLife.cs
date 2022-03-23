using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New AbsorbLife", menuName = "Mod/AbsorbLife")]
public class AbsorbLife : Mod
{
    [SerializeField]float absorbedLife;
    [SerializeField] ParticleSystem particlesPrefab;
    ParticleSystem particles;

    public override void Activate()
    {
        particles = GameObject.Instantiate(particlesPrefab, attachedTo.transform);
    }
    public override void DoAttack(BaseController hit, float damage)
    {
        attachedTo.GetComponent<BaseController>().TakePassiveDamage(-damage * absorbedLife);
        particles.Play();
    }

}
