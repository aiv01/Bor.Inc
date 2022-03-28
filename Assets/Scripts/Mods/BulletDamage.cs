using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Bullet Damage", menuName = "Mod/BulletDamage")]
public class BulletDamage : Mod
{
    [SerializeField] float damageBullet;
    float oldDamageBullet;

    public override void Activate()
    {
        
    }
}
