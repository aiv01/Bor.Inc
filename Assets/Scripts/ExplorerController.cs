using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplorerController : MonoBehaviour
{
    [SerializeField]float speed;
    private Vector3 moveDirection;
    Vector3 forward, right;
    private CharacterController cc;
    //private Animator anim;



    void Start()
    {
        cc = GetComponent<CharacterController>();
        //anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    { 
        Movement();
    }

    void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal") ;
        float vertical = Input.GetAxis("Vertical");
        moveDirection = vertical * (Vector3.forward + Vector3.right).normalized+ horizontal * (-Vector3.forward + Vector3.right).normalized;
        if(moveDirection.sqrMagnitude > 0)
        transform.LookAt(transform.position + moveDirection, Vector3.up);
        cc.Move(moveDirection.normalized * speed * Time.deltaTime);
    }
}
