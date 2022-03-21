using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.AI;

public class ExplorerController : MonoBehaviour {
    [SerializeField] float speed;
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
    protected NavMeshAgent navMesh;
    protected ModSlots modSlots;
    [HideInInspector] public float damageMult;

    void Start() {
        //cc = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        navMesh = GetComponent<NavMeshAgent>();
        navMesh.destination = transform.position;
        timerRandomIdle = 10f;
        modSlots.GetComponent<ModSlots>();
    }

    // Update is called once per frame
    void Update() {
        Movement();
    }

    void Movement() {
        RaycastHit hit = new RaycastHit();
        isGrounded = Physics.Raycast(transform.position + offset, -transform.up, out hit, 1f, groundMask);
        if (isGrounded && velocity.y < 0) {
            velocity.y = -2f;
            //anim.SetBool("Grounded", true);
        }
        InputMove();

        if (moveDirection.sqrMagnitude > 0) {
            transform.LookAt(transform.position + moveDirection, Vector3.up);
            InputDetected();
        }
        //cc.Move(moveDirection.normalized * speed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        //cc.Move(velocity * Time.deltaTime);
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
                if (Input.GetMouseButtonDown(0) && (raycastHit.point - transform.position).sqrMagnitude < 5 
                //|| (attackableMask.value & (1 << raycastHit.transform.gameObject.layer)) > 0
                ){
                    Attack();
                    transform.LookAt(new Vector3(raycastHit.point.x, transform.position.y, raycastHit.point.z), Vector3.up);
                } else
                if ((groundMask.value & (1 << raycastHit.transform.gameObject.layer)) > 0 && (raycastHit.point - transform.position).sqrMagnitude > 5) {
                    //if(raycastHit.transform.gameObject.layer == groundMask) {
                    
                        navMesh.destination = raycastHit.point;
                    //else {
                    //    Attack();
                    //    transform.LookAt(new Vector3(raycastHit.point.x, transform.position.y, raycastHit.point.z), Vector3.up);
                    //}
                    
                }
               
            }
            
            InputDetected();
            //Attack();

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
        if(moveDirection.sqrMagnitude > 0) navMesh.destination = transform.position + moveDirection;
    }

    void Idle() {
        anim.SetInteger("RandomIdle", Random.Range(0, 3));
        anim.SetFloat("ForwardSpeed", 0);
    }

    void Attack() {

        navMesh.destination = transform.position;
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
