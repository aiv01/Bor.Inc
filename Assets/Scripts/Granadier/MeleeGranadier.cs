using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeGranadier : Mob
{
    [SerializeField] Transform ellen;
    bool pursuit;
    bool retreat;
    [SerializeField] AttackArea attackArea;
    [SerializeField] float detecAngle;
    [SerializeField] float detecDistance;
    override public void Update()
    {
        float angle = Vector3.Angle(targetPos, transform.forward);
        float distance = targetPos.magnitude;
        if ((-transform.position + ellen.position).sqrMagnitude <= viewDistance * viewDistance)
        {
            animator.SetBool("InPursuit", true);
            pursuit = true;
            targetPos = ellen.position;

        }
        else if (pursuit)
        {
            pursuit = false;
            animator.SetBool("InPursuit", false);
            targetPos = spawnPos;
            retreat = true;
        }
        if ((-transform.position + ellen.position).sqrMagnitude <= attackDistance * attackDistance)
        {
            animator.SetTrigger("MeleeAttack");
        }
        if (retreat && (-transform.position + spawnPos).sqrMagnitude <= distanceFromBase * distanceFromBase)
        {
            animator.SetBool("InPursuit", false);
            targetPos = transform.position;
            retreat = false;
        }
        else if ((-transform.position + spawnPos).sqrMagnitude > distanceFromBase * distanceFromBase)
        {
            animator.SetBool("InPursuit", true);
        }
        
        if ((targetPos - transform.position).sqrMagnitude < 0.5f) return;
        base.Update();
    }

    public void StartAttack()
    {
        attackArea.AttackStart();
        //navMesh.isStopped = true;
    }
    public void EndAttack()
    {
        attackArea.AttackEnd();
 
    }

}
