using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New AbsorbLife", menuName = "Mod/AbsorbLife")]
public class AbsorbLife : Mod
{
    [SerializeField]float absorbedLife;

    public override void DoAttack(BaseController hit, float damage)
    {
        attachedTo.GetComponent<BaseController>().TakePassiveDamage(-damage * absorbedLife);
    }

}
