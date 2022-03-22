using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ExplorerController : BaseController {
   
    private float stateTime;
    private float timerRandomIdle;
    private float currentRT;
    private Vector3 moveDirection;
    private Vector3 offset;
    private Vector3 velocity;
    //private CharacterController cc;
    [SerializeField] AttackArea weaponArea;
    [SerializeField] private bool isGrounded;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private LayerMask attackableMask;
    [SerializeField] private float gravity;
    [SerializeField] private Transform bulletPos;
    private Animator anim;
    
    [HideInInspector] public float damageMult;

    public override void Start() {
        base.Start();
        isGrounded = true;
        anim = GetComponent<Animator>();
        
        
        timerRandomIdle = 10f;
    }

    // Update is called once per frame
    override public void Update() {
        base.Update();
        Movement();
    }

    void Movement() {
        RaycastHit hit = new RaycastHit();
        InputMove();

        if (moveDirection.sqrMagnitude > 0) {
            transform.LookAt(transform.position + moveDirection, Vector3.up);
            InputDetected();
        }
        stateTime += Time.deltaTime;
        if (moveDirection == Vector3.zero) {
            Idle();
        }
        if (moveDirection != Vector3.zero) {
            Locomotion();
        }
        anim.SetFloat("ForwardSpeed", navMesh.velocity.magnitude);
        if (Input.GetMouseButton(0)) {
            RaycastHit raycastHit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out raycastHit, 50)) {
                if (Input.GetMouseButtonDown(0) && (raycastHit.point - transform.position).sqrMagnitude <= attackDistance 
                //|| (attackableMask.value & (1 << raycastHit.transform.gameObject.layer)) > 0
                ){
                    Attack();
                    transform.LookAt(new Vector3(raycastHit.point.x, transform.position.y, raycastHit.point.z), Vector3.up);
                } else if ((groundMask.value & (1 << raycastHit.transform.gameObject.layer)) > 0 && (raycastHit.point - transform.position).sqrMagnitude > attackDistance) {
                    //if(raycastHit.transform.gameObject.layer == groundMask) {
                    
                        targetPos = raycastHit.point;
                }
               
            }
            InputDetected();
        }
        if (Input.GetMouseButtonDown(1))
        {
            InputDetected();
            Fire();
        }
        currentRT += Time.deltaTime;
        if (currentRT >= timerRandomIdle) {
            anim.SetBool("InputDetected", false);
            anim.SetTrigger("TimeoutToIdle");
        }
    }


    void InputMove() {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        moveDirection = (vertical * (Vector3.forward + Vector3.right).normalized + horizontal * (-Vector3.forward + Vector3.right).normalized).normalized;
        if(moveDirection.sqrMagnitude > 0) targetPos = transform.position + moveDirection;
    }

    void Idle() {
        anim.SetInteger("RandomIdle", Random.Range(0, 3));
        anim.SetFloat("ForwardSpeed", 0);
    }

    void Attack() {

        targetPos = transform.position;
        anim.SetTrigger("MeleeAttack");
        anim.SetFloat("StateTime", stateTime);
        stateTime = 0;
    }

    void Fire()
    {
        RaycastHit mouseHit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out mouseHit, 50);
        transform.LookAt(new Vector3(mouseHit.point.x, transform.position.y, mouseHit.point.z), Vector3.up);
        GameObject bullet = BulletMgr.instance.GetBullet();
        if (bullet != null)
        {
            bullet.transform.position = bulletPos.position;
            bullet.transform.LookAt(new Vector3(mouseHit.point.x, bulletPos.position.y, mouseHit.point.z));
            bullet.SetActive(true);
        }
    }

    void InputDetected() {
        anim.SetBool("InputDetected", true);
        currentRT = 0;
    }

    void Locomotion() {
        anim.SetFloat("ForwardSpeed", speed);
    }

    public void MeleeAttackStart(int throwing = 0) {
        //meleeWeapon.BeginAttack(throwing != 0);
        //m_InAttack = true;
        weaponArea.damageMult = damageMult;
        weaponArea.AttackStart();
    }

    public void MeleeAttackEnd() {
        //meleeWeapon.EndAttack();
        //m_InAttack = false;
        weaponArea.AttackEnd();
        
    }
}
