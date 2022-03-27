using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeChomper : Mob
{
    bool pursuit;
    bool retreat;
    [SerializeField]AttackArea attackArea;
    override public void Update() {
        if((-transform.position + ellen.position).sqrMagnitude <= viewDistance * viewDistance) {
            animator.SetTrigger("Spotted");
            animator.SetBool("InPursuit", true);
            pursuit = true;
            targetPos = ellen.position;

        } else if(pursuit){
            pursuit = false;
            animator.SetBool("InPursuit", false);
            targetPos = spawnPos;
            retreat = true;
        }
        if((-transform.position + ellen.position).sqrMagnitude <= attackDistance * attackDistance) {
            animator.SetTrigger("Attack");
        }
        if(retreat && (-transform.position + spawnPos).sqrMagnitude <= distanceFromBase * distanceFromBase) {
            animator.SetBool("NearBase", true);
            targetPos = transform.position;
            retreat = false;
        } else if ((-transform.position + spawnPos).sqrMagnitude > distanceFromBase * distanceFromBase) {
            animator.SetBool("NearBase", false);
        }

        if ((targetPos - transform.position).sqrMagnitude < 0.5f) return;
        base.Update();
    }


    public void AttackBegin() {
        attackArea.AttackStart();
    }
    public void AttackEnd() {
        attackArea.AttackEnd();
    }
}
