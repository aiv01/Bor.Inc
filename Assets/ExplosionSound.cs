using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionSound : MonoBehaviour
{
    AudioMgr au;
    void OnEnable()
    {
        if(!au) au = GetComponent<AudioMgr>();
        au.ExplosionBullet();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
