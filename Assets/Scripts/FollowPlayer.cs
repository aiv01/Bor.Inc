using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] Vector3 offset;
    [SerializeField][Range(0,1)] float speed = 0.8f;
    void Start()
    {
        
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.transform.position + offset, speed);
        transform.LookAt(target.transform);
    }
}
