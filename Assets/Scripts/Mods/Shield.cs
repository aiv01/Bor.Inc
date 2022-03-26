using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Shield", menuName = "Mod/Sield")]
public class Shield : Mod
{
    [SerializeField] float rechargeTime = 30;
    [SerializeField] ParticleSystem curePartclesPrefab;
    [SerializeField] ParticleSystem shieldParticlesPrefab;
    float currentRechargeTime;
    bool active = false;
    float hp;
    BaseController bc;
    ParticleSystem cureParticles;
    ParticleSystem shieldParticles;

    public override void Activate() {
        cureParticles = GameObject.Instantiate(curePartclesPrefab, attachedTo.transform);
        shieldParticles = GameObject.Instantiate(shieldParticlesPrefab, attachedTo.transform);
        active = false;
        currentRechargeTime = 0;
        bc = attachedTo.GetComponent<BaseController>();
    }
    public override void DoCicle() {
        if(!active && currentRechargeTime <= 0) {
            active = true;
            hp = bc.CurrentHp;
            shieldParticles.gameObject.SetActive(true);
            shieldParticles.Play();
        }
        if (currentRechargeTime > 0) currentRechargeTime -= Time.deltaTime;
    }
    public override void OnHit() {
        if (active) {
            bc.TakePassiveDamage(-hp + bc.CurrentHp);
            currentRechargeTime = rechargeTime;
            active = false;
            cureParticles.Play();
            shieldParticles.gameObject.SetActive(false);
        }
    }
}
