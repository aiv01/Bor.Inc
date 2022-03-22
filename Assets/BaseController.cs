using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(ModSlots))]
public class BaseController : MonoBehaviour {
    [SerializeField] public float speed;
    [SerializeField] protected float MaxHp;
    [SerializeField] protected float currentHp;
    [SerializeField] protected float attackDistance;


    protected ModSlots mods;
    protected NavMeshAgent navMesh;
    protected Vector3 targetPos;
    protected Animator animator;

    virtual public void Start()
    {
        currentHp = MaxHp;
        navMesh = GetComponent<NavMeshAgent>();
        navMesh.speed = speed;

        navMesh.destination = transform.position;

        mods = GetComponent<ModSlots>();

        animator = GetComponent<Animator>();
        animator.SetBool("Grounded", true);
    }

    // Update is called once per frame
    virtual public void Update()
    {
        navMesh.destination = targetPos;
    }

    public void TakeDamage(float damage, Mod[] mods) {
        //if (damage > 0) {
        //    animator.SetTrigger("Hit");
        //    animator.SetFloat("VerticalHitDot", 1);
        //}
        TakeDamage(damage);
    }

    private void TakeDamage(float damage) {
        currentHp -= damage;
        if (currentHp <= 0) Die();
    }

    private void Die() {
        animator.SetTrigger("Death");
        navMesh.enabled = false;
        //ragdol.SetActive(true);
        gameObject.SetActive(false);
        //gameObject.SetActive(false);
    }
}
