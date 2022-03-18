using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeleeChomper : Mob
{
    bool pursuit;
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

        }
        if((-transform.position + target.position).sqrMagnitude <= attackDistance * attackDistance) {
            animator.SetTrigger("Attack");
        }

    }
}
