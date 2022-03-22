using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedSpitter : Mob {
    [SerializeField] Transform target;
    bool pursuit;
    bool retreat;
    override public void Update() {
        targetPos = target.position;
        if ((targetPos - transform.position).sqrMagnitude < 0.5f) return;
        if ((-transform.position + targetPos).sqrMagnitude <= viewDistance * viewDistance) {
            animator.SetTrigger("Spotted");
            animator.SetBool("InPursuit", true);
            pursuit = true;
            navMesh.destination = targetPos;

        } else if (pursuit) {
            pursuit = false;
            animator.SetBool("InPursuit", false);
            navMesh.destination = spawnPos;
            retreat = true;
        }
        if ((-transform.position + targetPos).sqrMagnitude <= attackDistance * attackDistance) {
            animator.SetTrigger("Attack");
        }
        if (retreat && (-transform.position + spawnPos).sqrMagnitude <= distanceFromBase * distanceFromBase) {
            animator.SetBool("NearBase", true);
            navMesh.destination = transform.position;
            retreat = false;
        } else if ((-transform.position + spawnPos).sqrMagnitude > distanceFromBase * distanceFromBase) {
            animator.SetBool("NearBase", false);
        }

        base.Update();
    }


    public void AttackBegin() {

    }
    public void AttackEnd() {

    }
}