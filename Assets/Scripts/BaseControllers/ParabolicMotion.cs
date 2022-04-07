using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParabolicMotion : MonoBehaviour
{
    [SerializeField] float gravity = 10f;
    [SerializeField] float vx = 0.5f;
    private Vector3 dist;
    private Vector3 targetPos;
    private Vector3 startPos;
    private float t;
    private float vy;
    private float currentTime;
    public bool finishParabolic = false;
    Vector2 v0;
    public Vector3 TargetPos
    {
        get { return targetPos; }
        set { targetPos = value;
            currentTime = 0;
            startPos = transform.position;
            dist = targetPos - transform.position;
            t = dist.magnitude / vx;
            vy = gravity * t * 0.5f;
            v0 = new Vector2(vx, vy);
            finishParabolic = false;
        }
    }
    void Start()
    {
        
    }

    void Update()
    {
        if(currentTime < t)
        {
            currentTime += Time.deltaTime;
            Vector3 dstTrue = dist;
            dstTrue.y = 0;
            dstTrue = dstTrue.normalized;
            Vector3 currentPos = startPos + dstTrue * currentTime * vx;
            float posY = startPos.y + vy * currentTime - 0.5f * Mathf.Pow(currentTime, 2) * gravity;
            currentPos.y = posY;
            transform.position = currentPos;
        }
        if(currentTime > t)
        {
            finishParabolic = true;
        }
    }
}
