using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplorerController : MonoBehaviour 
    {
    [SerializeField]float speed;
    private float stateTime;
    private float timerRandomIdle;
    private float currentRT;
    private Vector3 moveDirection;
    private Vector3 offset;
    private Vector3 velocity;
    private CharacterController cc;
    [SerializeField] Collider weaponColl;
    [SerializeField] private bool isGrounded;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float gravity;
    private Animator anim;



    void Start()
    {
        cc = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        timerRandomIdle = 10f;
    }

    // Update is called once per frame
    void Update()
    { 
        Movement();
    }

    void Movement()
    {
        RaycastHit hit = new RaycastHit();
        isGrounded = Physics.Raycast(transform.position + offset, -transform.up, out hit, 1f, groundMask);
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
            //anim.SetBool("Grounded", true);
        }
        InputMove();
        if (moveDirection.sqrMagnitude > 0)
        {
            transform.LookAt(transform.position + moveDirection, Vector3.up);
            InputDetected();
        }
        cc.Move(moveDirection.normalized * speed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        cc.Move(velocity * Time.deltaTime);
        stateTime += Time.deltaTime;
        if(moveDirection == Vector3.zero)
        {
            Idle();
        }
        if(moveDirection != Vector3.zero)
        {
            Locomotion();
        }
        if (Input.GetMouseButtonDown(0))
        {
            InputDetected();
            Attack();
           
        }
        currentRT += Time.deltaTime;
        if(currentRT >= timerRandomIdle)
        {
            anim.SetBool("InputDetected", false);
            anim.SetTrigger("TimeoutToldle");
        }
    }


    void InputMove()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        moveDirection = vertical * (Vector3.forward + Vector3.right).normalized + horizontal * (-Vector3.forward + Vector3.right).normalized;
        
    }

    void Idle()
    {
        anim.SetInteger("RandomIdle", Random.Range(0,3));
        anim.SetFloat("ForwardSpeed", 0);
    }

    void Attack()
    {
        anim.SetTrigger("MeleeAttack");
        anim.SetFloat("StateTime", stateTime);
        stateTime = 0;
    }

    void InputDetected()
    {
        anim.SetBool("InputDetected", true);
        currentRT = 0;
    }

    void Locomotion()
    {
        anim.SetFloat("ForwardSpeed", speed);
    }

    public void MeleeAttackStart(int throwing = 0)
    {
        //meleeWeapon.BeginAttack(throwing != 0);
        //m_InAttack = true;
        weaponColl.enabled = true;
    }

    public void MeleeAttackEnd()
    {
        //meleeWeapon.EndAttack();
        //m_InAttack = false;
        weaponColl.enabled = false;
    }
}
