using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[CreateAssetMenu(fileName = "New Swiftness", menuName = "Mod/Swiftness")]
public class Swiftness : Mod
{
    [SerializeField] float speedMult = 1;
    float oldSpeed;
    public override void Activate() {
        oldSpeed = attachedTo.GetComponent<NavMeshAgent>().speed;
        attachedTo.GetComponent<NavMeshAgent>().speed = oldSpeed * speedMult;
    }
    public override void Disable() {
        attachedTo.GetComponent<NavMeshAgent>().speed = oldSpeed;
    }
}
