using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Slowness Giver", menuName = "Mod/Slowness Giver")]
public class SlownessGiver : Mod
{
    [SerializeField] Mod slownessMod;
    public override void DoAttack(BaseController hit, float damage) {
        hit.GetComponent<ModSlots>().AddMod(slownessMod);
    }
}
