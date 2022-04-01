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
        base.Update();
    }

    override public void TakeDamage(float damage, BaseController attacker) {
        if (damage > 0 && Random.Range(0, 20) == 0) {
            animator.SetTrigger("Hit");
        }
        base.TakeDamage(damage, attacker);
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

    public void MeleeAttackStart()
    {
        attackArea.damageMult = effectDamageMult;
        attackArea.AttackStart();
    }
    public void EndAttack()
    {
        attackArea.AttackEnd();
 
    }

}
