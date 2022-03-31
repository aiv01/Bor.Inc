using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Bullet Damage", menuName = "Mod/BulletDamage")]
public class BulletDamage : Mod
{
    [SerializeField] float damageBulletMult;
    float oldDamageBullet;

    public override void Activate()
    {
        oldDamageBullet = attachedTo.GetComponent<BaseController>().bulletBaseDamage;
        attachedTo.GetComponent<BaseController>().bulletBaseDamage = oldDamageBullet * damageBulletMult;
    }
    public override void Disable() {
        attachedTo.GetComponent<BaseController>().bulletBaseDamage /= damageBulletMult;
    }
}
