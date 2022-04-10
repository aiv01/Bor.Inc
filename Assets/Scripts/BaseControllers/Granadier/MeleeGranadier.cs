using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeGranadier : Mob
{
    bool pursuit;
    bool retreat;
    [SerializeField] AttackArea attackArea;
    [SerializeField] AttackArea secondAttackArea;
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
        base.TakeDamage(damage, attacker);
        if (damage > 0 && Random.Range(0, 20) == 0 && currentHp > 0) {
            animator.SetTrigger("Hit");
        }
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
    public void StartAttack()
    {
        secondAttackArea.damageMult = effectDamageMult;
        secondAttackArea.AttackStart();
    }
    public void Shoot() {
        Bullet b = BulletMgr.instance.GetBullet(bulletType);
        b.transform.position = transform.position + Vector3.up;
        b.gameObject.SetActive(true);
        b.Shoot(this, "Player", 1);
        b.GetComponent<ParabolicMotion>().TargetPos = ellen.position;
    }
    public void EndAttack()
    {
        attackArea.AttackEnd();
        secondAttackArea.AttackEnd();
 
    }

    override protected void Die()
    {
        GetComponent<Collider>().enabled = false;
        animator.SetTrigger("Death");
    }

    private void DeathEvent()
    {
        navMesh.enabled = false;
        this.enabled = false;
    }

}
