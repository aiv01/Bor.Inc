using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParabolicMotion : MonoBehaviour
{
    protected float animaiton;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animaiton += Time.deltaTime;
        animaiton = animaiton % 5f;
        //transform.position = math
    }
}
