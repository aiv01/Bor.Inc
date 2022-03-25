using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedSpitter : Mob {
    [SerializeField] Transform target;
    [SerializeField] BulletMgr bulletMgr;
    bool pursuit;
    bool retreat;
    override public void Update() {
        //if ((targetPos - transform.position).sqrMagnitude < 0.5f) return;
        if ((-transform.position + target.position).sqrMagnitude <= viewDistance * viewDistance) {
            
            targetPos = target.position;
            animator.SetBool("HaveTarget", true);
            //navMesh.destination = targetPos;

        } else {
            animator.SetBool("HaveTarget", false);
            targetPos = spawnPos;
            retreat = true;
        }
        if ((-transform.position + target.position).sqrMagnitude <= attackDistance * attackDistance) {
            animator.SetTrigger("Attack");
            animator.SetBool("Fleeing", false);
            transform.LookAt(target);
            if (!navMesh.isStopped) navMesh.isStopped = true;
        } else {
            animator.SetBool("Fleeing", true);
            targetPos = target.position;
            if (navMesh.isStopped)
                navMesh.isStopped = false;
        }
        if (retreat && (-transform.position + spawnPos).sqrMagnitude <= distanceFromBase * distanceFromBase) {
            animator.SetBool("Fleeing", false);
            targetPos = target.position;
            retreat = false;
        } else if (retreat && (-transform.position + spawnPos).sqrMagnitude > distanceFromBase * distanceFromBase) {
            animator.SetBool("Fleeing", true);
            targetPos = spawnPos;
        }

        base.Update();
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