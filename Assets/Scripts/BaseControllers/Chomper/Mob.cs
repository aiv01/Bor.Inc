using UnityEngine;
using UnityEngine.AI;

public class Mob : BaseController
{
    [SerializeField] protected Transform ellen;

    [SerializeField] protected float damage;
    [SerializeField] protected float viewDistance;
    [SerializeField] protected float distanceFromBase;
    int percetageCureProbability = 10;
    HeartMgr heartmgr;
    protected Vector3 spawnPos;
    public override void Start()
    {
        base.Start();
        if (!ellen) ellen = GameObject.FindGameObjectWithTag("Player").transform;
        navMesh = GetComponent<NavMeshAgent>();
        if (!animator) animator = GetComponent<Animator>();
        heartmgr = GameObject.Find("HeartMgr").GetComponent<HeartMgr>();
    }

    public virtual void OnEnable() {
        if (!animator) animator = GetComponent<Animator>();
        animator.SetBool("NearBase", true);
        spawnPos = transform.position;
        targetPos = spawnPos;
    }

    override public void Update()
    {
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
    protected override void Die()
    {
        if (Random.Range(0, percetageCureProbability) == 0)
        {
            Heart heart = heartmgr.GetHeart();
            if (heart != null)
            {
                heart.transform.position = transform.position;
                heart.gameObject.SetActive(true);
            }
        }
    }
}
