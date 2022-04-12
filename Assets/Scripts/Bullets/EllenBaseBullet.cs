using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EllenBaseBullet : Bullet
{
    ParticleMgr exp;
    protected override void OnDisable() {
        if (!exp) 
        exp = GameObject.FindObjectOfType<ParticleMgr>();
        if (!exp) { Debug.LogWarning("Missing Explosion Manager"); return; }
        ParticleSystem ps = exp.GetExplosion(ParticleType.baseBulletExplosion);
        ps.transform.position = transform.position;
        ParticleSystem[] arr = ps.GetComponentsInChildren<ParticleSystem>(true);
        foreach (var item in arr) {
            item.gameObject.SetActive(true);
            item.Play();
        }
        base.OnDisable();
    }
}
