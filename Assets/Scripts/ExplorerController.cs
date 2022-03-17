using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplorerController : MonoBehaviour
{
    [SerializeField]float speed;
    private Vector3 moveDirection;
    Vector3 forward, right;
    //private CharacterController cc;
    //private Animator anim;



    void Start()
    {
        //cc = GetComponent<CharacterController>();
        //anim = GetComponent<Animator>();
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
    }

    // Update is called once per frame
    void Update()
    {
       
        Move();
        //Movement();
    }

    //void Movement()
    //{
    //    float horizontal = Input.GetAxis("Horizontal");
    //    float vertical = Input.GetAxis("Vertical");
    //    moveDirection = new Vector3(horizontal, 0, vertical);
    //    cc.Move(moveDirection * speed * Time.deltaTime);
    //}

    private void Move()
    {
        //Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 rightMovement = right * speed * Time.deltaTime * Input.GetAxis("Horizontal");
        Vector3 upMovement = forward * speed * Time.deltaTime * Input.GetAxis("Vertical");

        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);
        transform.forward = heading;
        transform.position += rightMovement;
        transform.position += upMovement;
    }
}
