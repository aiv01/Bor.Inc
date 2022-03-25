using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ChangeBulk", menuName = "Mod/ChangeBulk")]
public class ChangeBulk : Mod
{
    [SerializeField] float damageMultDown;
    float oldEffectDamageMult;
    public override void Activate()
    {
        oldEffectDamageMult = attachedTo.GetComponent<ExplorerController>().effectDamageMult;
        attachedTo.GetComponent<ExplorerController>().effectDamageMult = damageMultDown * oldEffectDamageMult;
    }
    public override void Disable()
    {
        attachedTo.GetComponent<ExplorerController>().effectDamageMult /= damageMultDown;
    }
}
