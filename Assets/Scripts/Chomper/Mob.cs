using UnityEngine;

public class Mob : BaseController
{
    
    [SerializeField] protected float damage;
    [SerializeField] protected float viewDistance;
    [SerializeField] protected float distanceFromBase;
    protected Vector3 spawnPos;


    //public int statusHit;

    public override void Start() {
        base.Start();
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

    override public void TakeDamage(float damage, BaseController creker) {
        if (damage > 0) {
            animator.SetTrigger("Hit");
            animator.SetFloat("VerticalHitDot", 1);
        }
        base.TakeDamage(damage, creker);
    }




}
