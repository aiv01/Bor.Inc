using UnityEngine;
using UnityEngine.AI;

public class Mob : BaseController
{
    [SerializeField] protected Transform ellen;

    [SerializeField] protected float damage;
    [SerializeField] protected float viewDistance;
    [SerializeField] protected float distanceFromBase;
    protected Vector3 spawnPos;
    public override void Start() {
        base.Start();
        if (!ellen) ellen = GameObject.FindGameObjectWithTag("Player").transform;
        navMesh = GetComponent<NavMeshAgent>();
        if (!animator) animator = GetComponent<Animator>();
    }

    public virtual void OnEnable() {
        if(!animator) animator = GetComponent<Animator>();
        animator.SetBool("NearBase", true);
        spawnPos = transform.position;
        targetPos = spawnPos;
    }

    override public void Update() {
        base.Update();
        //if(timeToCure > 0) {
        //    timeToCure -= Time.deltaTime;
        //} else {
        //    currentStatus = Status.none;
        //}
        //switch (currentStatus) {
        //    case Status.none:
        //        break;
        //    case Status.poison:
        //        TakeDamage(StatusStatic.dps * Time.deltaTime);
        //        break;
        //    default:
        //        break;
        //}
    }

    //override public void TakeDamage(float damage, BaseController attacker) {
    //    if (damage > 0) {
    //        animator.SetTrigger("Hit");
    //        animator.SetFloat("VerticalHitDot", 1);
    //    }
    //    base.TakeDamage(damage, attacker);
    //}




}
