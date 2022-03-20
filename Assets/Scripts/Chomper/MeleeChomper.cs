using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeleeChomper : Mob
{
    bool pursuit;
    bool retreat;
    private void Update() {
        if (!target) return;
        if((-transform.position + target.position).sqrMagnitude <= viewDistance * viewDistance) {
            animator.SetTrigger("Spotted");
            animator.SetBool("InPursuit", true);
            pursuit = true;
            navMesh.destination = target.position;
            
        } else if(pursuit){
            pursuit = false;
            animator.SetBool("InPursuit", false);
            navMesh.destination = spawnPos;
            retreat = true;
        }
        if((-transform.position + target.position).sqrMagnitude <= attackDistance * attackDistance) {
            animator.SetTrigger("Attack");
        }
        if(retreat && (-transform.position + spawnPos).sqrMagnitude <= distanceFromBase * distanceFromBase) {
            animator.SetBool("NearBase", true);
            navMesh.destination = transform.position;
            retreat = false;
        } else if ((-transform.position + spawnPos).sqrMagnitude > distanceFromBase * distanceFromBase) {
            animator.SetBool("NearBase", false);
        }

    }


    public void AttackBegin() {

    }
    public void AttackEnd() {

    }
}
