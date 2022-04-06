using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParabolicMotion : MonoBehaviour
{
    [SerializeField] float gravity = 10f;
    [SerializeField] float vx = 0.5f;
    public Vector3 dist;
    private float t;
    private float vy;
    Vector2 v0;
    void Start()
    {
        t = dist.magnitude / vx;
        vy = gravity * t * 0.5f;
        v0 = new Vector2(vx, vy);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dstTrue = dist;
        dstTrue.y = 0;
    }
}
