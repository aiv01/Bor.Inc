using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EllenBaseBullet : Bullet
{
    ExplosionMgr exp;
    protected override void OnDisable() {
        if (!exp) exp = GameObject.FindObjectOfType<ExplosionMgr>();
        ParticleSystem ps = exp.GetExplosion(ExplosionType.baseBulletExplosion);
        ps.transform.position = transform.position;
        ParticleSystem[] arr = ps.GetComponentsInChildren<ParticleSystem>(true);
        foreach (var item in arr) {
            item.gameObject.SetActive(true);
            item.Play();
        }
        base.OnDisable();
    }
}
