using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedSpitter : Mob {
    [SerializeField] BulletMgr bulletMgr;
    bool pursuit;
    bool retreat;
    public void Awake() {
        bulletMgr = GameObject.Find("BulletMgr (Sludge)").GetComponent<BulletMgr>();
    }
    override public void Update() {
        //if ((targetPos - transform.position).sqrMagnitude < 0.5f) return;
        if ((-transform.position + ellen.position).sqrMagnitude <= viewDistance * viewDistance) {
            
            targetPos = ellen.position;
            animator.SetBool("HaveTarget", true);
            //navMesh.destination = targetPos;

        } else {
            animator.SetBool("HaveTarget", false);
            targetPos = spawnPos;
            retreat = true;
        }
        if ((-transform.position + ellen.position).sqrMagnitude <= attackDistance * attackDistance) {
            animator.SetTrigger("Attack");
            animator.SetBool("Fleeing", false);
            transform.LookAt(ellen);
            if (!navMesh.isStopped) navMesh.isStopped = true;
        } else {
            animator.SetBool("Fleeing", true);
            targetPos = ellen.position;
            if (navMesh.isStopped)
                navMesh.isStopped = false;
        }
        if (retreat && (-transform.position + spawnPos).sqrMagnitude <= distanceFromBase * distanceFromBase) {
            animator.SetBool("Fleeing", false);
            targetPos = ellen.position;
            retreat = false;
        } else if (retreat && (-transform.position + spawnPos).sqrMagnitude > distanceFromBase * distanceFromBase) {
            animator.SetBool("Fleeing", true);
            targetPos = spawnPos;
        }

        base.Update();
    }
    protected override void Die() {
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
        base.TakeDamage(damage, attacker);
    }
    public void Shoot() {
        Bullet bullet = bulletMgr.GetBullet();
        if (bullet != null) {
            bullet.transform.position = bulletPos.position;
            bullet.transform.rotation = Quaternion.LookRotation(transform.forward, Vector3.up);
            bullet.gameObject.SetActive(true);
            bullet.GetComponent<Bullet>().Shoot(this, "Player");
        }
    }
    public void AttackEnd() {
    }
}