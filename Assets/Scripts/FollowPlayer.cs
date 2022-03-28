using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] Vector3 offset;
    [SerializeField] float scaler;
    [SerializeField][Range(0,1)] float speed = 0.8f;
    void Start()
    {
        
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.transform.position + offset.normalized * scaler, speed);
        transform.LookAt(target.transform, Vector3.forward + Vector3.right);
    }
}
