using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeChomper : Mob
{
    bool pursuit;
    bool retreat;
    [SerializeField]AttackArea attackArea;
    public override void Start() {
        base.Start();
        animator = GetComponent<Animator>();
    }
    public override void OnEnable() {
        base.OnEnable();
        animator.SetBool("InPursuit", false);
        animator.SetBool("NearBase", true);
    }
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
    override public void TakeDamage(float damage, BaseController attacker) {
        if (damage > 0) {
            animator.SetTrigger("Hit");
            animator.SetFloat("VerticalHitDot", 1);
        }
        if((-transform.position + spawnPos).sqrMagnitude <= distanceFromBase * distanceFromBase)
        viewDistance += 3;

        base.TakeDamage(damage, attacker);
    }

    public void MeleeAttackStart(){
        attackArea.damageMult = effectDamageMult;
        attackArea.AttackStart();
    }
    public void AttackEnd() {
        attackArea.AttackEnd();
    }

    protected override void Die() {
        base.Die();
        GetComponent<DistanceDissolveTarget>().dissolve = true;
        //GetComponent<Disintegratable>().Disintegrate(transform.position + Vector3.up);
        foreach (Collider item in GetComponentsInChildren<Collider>()) {
            item.enabled = false;
        }
        animator.enabled = false;
        navMesh.enabled = false;
        this.enabled = false;
    }
}
