using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadierBullet : Bullet
{
    ParabolicMotion pb;
    ParticleMgr exp;

    void Start()
    {
        pb = GetComponent<ParabolicMotion>();
    }

    // Update is called once per frame
    protected override void Update() {
        if (pb.finishParabolic) gameObject.SetActive(false);
    }
    protected override void OnDisable() {
        if (!exp)
            exp = GameObject.FindObjectOfType<ParticleMgr>();
        if (!exp) { Debug.LogWarning("Missing Explosion Manager"); return; }
        ParticleSystem ps = exp.GetExplosion(ParticleType.granedierExplosion);
        ps.transform.position = transform.position;
        ParticleSystem[] arr = ps.GetComponentsInChildren<ParticleSystem>(true);
        foreach (var item in arr) {
            item.gameObject.SetActive(true);
            item.Play();
        }
        base.OnDisable();
    }
}
