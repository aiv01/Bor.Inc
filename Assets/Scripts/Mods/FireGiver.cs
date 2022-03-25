using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Fire Giver", menuName = "Mod/Fire Giver")]
public class FireGiver : Mod
{
    // Start is called before the first frame update
    [SerializeField] Mod ShootOfFireMod;
    public override void DoAttack(BaseController hit, float damage)
    {
        hit.GetComponent<ModSlots>().AddMod(ShootOfFireMod);
    }
}
