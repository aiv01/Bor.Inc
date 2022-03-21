using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum Status {
    none, poison
}

public class Mob : MonoBehaviour
{
    [SerializeField] protected float MaxHp;
    protected float currentHp;
    [SerializeField] public float speed;
    [SerializeField] protected float damage;
    [SerializeField] protected float viewDistance;
    [SerializeField] protected float attackDistance;
    //[SerializeField] GameObject ragdol;
    [SerializeField] protected float distanceFromBase;
    protected Vector3 spawnPos;

    protected Status currentStatus = Status.none;

    protected Animator animator;
    protected NavMeshAgent navMesh;
    public Transform target;

    private void Awake() {
        navMesh = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        navMesh.speed = speed;
        currentHp = MaxHp;
        animator.SetBool("Grounded", true);
        animator.SetBool("NearBase", true);
        spawnPos = transform.position;
    }

    virtual public void Update() {
        switch (currentStatus) {
            case Status.none:
                break;
            case Status.poison:

                break;
            default:
                break;
        }
    }


    public void TakeDamage(float damage, float knockBack = 0) {
        currentHp -= damage;
        if (damage > 0) { animator.SetTrigger("Hit");
            animator.SetFloat("VerticalHitDot", 1); }
        if (currentHp <= 0) Die();
    }

    private void Die() {
        if (damage > 0) animator.SetTrigger("Death");
        //ragdol.SetActive(true);
        gameObject.SetActive(false);
        //gameObject.SetActive(false);
    }
}
