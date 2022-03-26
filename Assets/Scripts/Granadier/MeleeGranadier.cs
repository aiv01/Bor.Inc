using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeGranadier : Mob
{
    bool pursuit;
    bool retreat;
    [SerializeField] AttackArea attackArea;
    [SerializeField] float detecAngle;
    [SerializeField] float detecDistance;
    public Transform Ellen => ellen;
    public float ViewDistance => viewDistance;
    public float DetecAngle => detecAngle; 
    public Vector3 TargetPos {
        get { return targetPos; }
        set { targetPos = value; }
    }
    public float AttackDistance => attackDistance;
    public float DistanceFromBase => distanceFromBase;
    public Vector3 SpawnPos => spawnPos;
    override public void Update()
    {
        //float angle = Vector3.Angle(targetPos-transform.position, transform.forward);
        //float distance = targetPos.magnitude;
        //if ((-transform.position + ellen.position).sqrMagnitude <= viewDistance * viewDistance)// molto alta
        //{
        //    if(angle < detecAngle && distance < detecDistance)
        //    {
        //        animator.SetBool("InPursuit", true);
        //        pursuit = true;
        //        targetPos = ellen.position;
        //        if ((-transform.position + ellen.position).sqrMagnitude <= attackDistance * attackDistance)
        //        {
        //            animator.SetTrigger("MeleeAttack");
        //        }
        //    }
        //    else
        //    {
        //        animator.SetTrigger("Rotate");
        //    }
        //    //fai cono visivo
        //    //se non sei nel cono visivo ruota
        //    //se sei nel cono visivo avvicinati;
        //    // se sei nel cono e vicino nell attack distance attacca;
        //}
        //else if (pursuit)
        //{
        //    pursuit = false;
        //    animator.SetBool("InPursuit", false);
        //    targetPos = spawnPos;
        //    retreat = true;
        //}
        //BackToBase();
        //if ((targetPos - transform.position).sqrMagnitude < 0.5f) return;
        base.Update();
    }




    void BackToBase()
    {
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
    }

    public void StartAttack()
    {
        attackArea.AttackStart();
    }
    public void EndAttack()
    {
        attackArea.AttackEnd();
 
    }

}
