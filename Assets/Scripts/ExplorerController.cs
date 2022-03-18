using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplorerController : MonoBehaviour 
    {
    [SerializeField]float speed;
    private Vector3 moveDirection;
    private Vector3 offset;
    private Vector3 velocity;
    private CharacterController cc;
    [SerializeField] private bool isGrounded;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float gravity;
    private Animator anim;



    void Start()
    {
        cc = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
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
        }
        float horizontal = Input.GetAxis("Horizontal") ;
        float vertical = Input.GetAxis("Vertical");
        moveDirection = vertical * (Vector3.forward + Vector3.right).normalized+ horizontal * (-Vector3.forward + Vector3.right).normalized;
        if(moveDirection.sqrMagnitude > 0)
        transform.LookAt(transform.position + moveDirection, Vector3.up);
        cc.Move(moveDirection.normalized * speed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        cc.Move(velocity * Time.deltaTime);
        if(moveDirection == Vector3.zero)
        {
            Idle();
        }
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }


    void Idle()
    {
        anim.SetFloat("Speed", 0);
    }

    void Attack()
    {
        anim.SetTrigger("Attack");
    }
    
}
