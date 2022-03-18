using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeleeChomper : Mob
{
    private void Update() {
        if (!target) return;
        if((-transform.position + target.position).sqrMagnitude <= viewDistance * viewDistance) {
            navMesh.destination = target.position;
        }
    }
}
