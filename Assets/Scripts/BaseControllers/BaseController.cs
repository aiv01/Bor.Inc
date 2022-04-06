using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(ModSlots))]
public class BaseController : MonoBehaviour {
    [SerializeField] public float speed;
    [SerializeField] protected float maxHp;
    [SerializeField] protected float currentHp;
    [SerializeField] protected float attackDistance;
    [HideInInspector] public float effectDamageMult = 1;
    public float bulletBaseDamage = 0;

    [SerializeField] public Transform bulletPos;

    [SerializeField] public BulletMgr bulletMgr;


    protected ModSlots mods;
    protected NavMeshAgent navMesh;
    public Vector3 targetPos;
    protected Animator animator;
    public float MaxHp {
        get { return maxHp; }
        set { maxHp = value; }
    }
    public float CurrentHp {
        get { return currentHp; }
        set { currentHp = value; }
    }
    virtual public void Start()
    {
        currentHp = maxHp;
        navMesh = GetComponent<NavMeshAgent>();
        navMesh.speed = speed;

        targetPos = transform.position;

        mods = GetComponent<ModSlots>();

        animator = GetComponent<Animator>();
        //animator.SetBool("Grounded", true);
    }

    // Update is called once per frame
    virtual public void Update()
    {
        if(navMesh.isActiveAndEnabled && navMesh.isOnNavMesh)
        navMesh.destination = targetPos;
    }
    virtual public void TakeDamage(float damage, BaseController attacker) {
        currentHp -= damage;
        GetComponent<ModSlots>().OnHit();
        if (currentHp <= 0) Die();
    }
    virtual public void TakePassiveDamage(float damage) {
        currentHp -= damage;
        if (currentHp <= 0) Die();
        if(currentHp > maxHp) { currentHp = maxHp; }
    }

    virtual protected void Die() {
        //animator.SetTrigger("Death");
        //ragdol.SetActive(true);
        gameObject.SetActive(false);
        //gameObject.SetActive(false);
    }
}
