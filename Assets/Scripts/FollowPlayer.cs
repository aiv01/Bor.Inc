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

    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.transform.position + offset.normalized * scaler, speed);
            //+ Vector3.up * Mathf.Sin(Time.time * 0.5f) * 0.13f 
            //+ Vector3.up * Mathf.Sin(Time.time * 0.8f) * 0.1f
            //+ Vector3.up * Mathf.Sin(Time.time * 1.2f) * 0.05f;
        transform.LookAt(target.transform, Vector3.forward + Vector3.right);
    }
}
