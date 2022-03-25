using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New AbsorbLife", menuName = "Mod/AbsorbLife")]
public class AbsorbLife : Mod
{
    [SerializeField]float absorbedLife;
    [SerializeField] int percetageCureProbability = 3;
    [SerializeField] ParticleSystem particlesPrefab;
    ParticleSystem particles;

    public override void Activate()
    {
        particles = GameObject.Instantiate(particlesPrefab, attachedTo.transform);
    }
    public override void DoAttack(BaseController hit, float damage)
    {
        if(Random.Range(0, percetageCureProbability) == 0)
        {
            attachedTo.GetComponent<BaseController>().TakePassiveDamage(-damage * absorbedLife);
            particles.Play();
        }
    }

}
