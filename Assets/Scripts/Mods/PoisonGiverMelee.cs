using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Poison Giver", menuName = "Mod/Poison Giver")]

public class PoisonGiverMelee : Mod
{
    [SerializeField] Mod poisonMod;
    public override void DoAttack(BaseController hit, float damage) {
        hit.GetComponent<ModSlots>().AddMod(poisonMod);
    }
}
