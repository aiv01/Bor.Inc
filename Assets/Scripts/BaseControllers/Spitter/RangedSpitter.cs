using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedSpitter : Mob {

    bool pursuit;
    bool retreat;
    public override void Start() {
        base.Start();
        bulletMgr = GameObject.Find("BulletMgr (Sludge)").GetComponent<BulletMgr>();
    }
    public override void OnEnable() {
        base.OnEnable();
    }
    override public void Update() {
        //if ((targetPos - transform.position).sqrMagnitude < 0.5f) return;
        if ((-transform.position + ellen.position).sqrMagnitude <= viewDistance * viewDistance) {
            
            targetPos = ellen.position;
            animator.SetBool("HaveTarget", true);
            retreat = false;
            //navMesh.destination = targetPos;

        } else {
            animator.SetBool("HaveTarget", false);
            targetPos = spawnPos;
            retreat = true;
        }
        if (!retreat && (-transform.position + ellen.position).sqrMagnitude <= attackDistance * attackDistance) {
            animator.SetTrigger("Attack");
            animator.SetBool("Fleeing", false);
            transform.LookAt(ellen);
            if (!navMesh.isStopped) navMesh.isStopped = true;
        } else if(!retreat){
            animator.SetBool("Fleeing", true);
            targetPos = ellen.position;
            if (navMesh.isStopped)
                navMesh.isStopped = false;
        }
        if (retreat && (-transform.position + spawnPos).sqrMagnitude <= distanceFromBase * distanceFromBase) {
            animator.SetBool("Fleeing", false);
            targetPos = transform.position;
            retreat = false;
        } else if (retreat && (-transform.position + spawnPos).sqrMagnitude > distanceFromBase * distanceFromBase) {
            animator.SetBool("Fleeing", true);
            targetPos = spawnPos;
        }

        base.Update();
    }
    protected override void Die() {
        base.Die();
        GetComponent<DistanceDissolveTarget>().dissolve = true;
        animator.enabled = false;
        navMesh.enabled = false;
        this.enabled = false;
    }
    override public void TakeDamage(float damage, BaseController attacker) {
        if (damage > 0) {
            animator.SetTrigger("Hit");
            animator.SetFloat("VerticalHitDot", 1);
        }
        if ((-transform.position + spawnPos).sqrMagnitude <= distanceFromBase * distanceFromBase)
            viewDistance += 3;
        base.TakeDamage(damage, attacker);
    }
    public void Shoot() {
        Bullet bullet = bulletMgr.GetBullet();
        if (bullet != null) {
            bullet.transform.position = bulletPos.position;
            bullet.transform.rotation = Quaternion.LookRotation(transform.forward, Vector3.up);
            bullet.gameObject.SetActive(true);
            bullet.GetComponent<Bullet>().Shoot(this, "Player", bulletBaseDamage);
        }
    }
    public void AttackEnd() {
    }
}