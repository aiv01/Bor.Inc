using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadierBullet : Bullet
{
    ParabolicMotion pb;
    void Start()
    {
        pb = GetComponent<ParabolicMotion>();
    }

    // Update is called once per frame
    protected override void Update() {
        if (pb.finishParabolic) gameObject.SetActive(false);
    }
}
