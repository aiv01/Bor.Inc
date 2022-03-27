using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "New Teleport", menuName = "Mod/Teleport")]
public class Teleport : Mod
{
    [SerializeField] int teleportChance = 3;
    [SerializeField] float radius = 10;
    [SerializeField] LayerMask ground;
    public override void OnHit() {
        if(Random.Range(0, teleportChance) == 0) {
            RaycastHit raycastHit;
            Vector3 pos;
            do {
                pos = attachedTo.transform.position + new Vector3(Random.Range(-radius, radius), 20, Random.Range(-radius, radius));

            } while (!Physics.Raycast(pos, -Vector3.up, out raycastHit, 25f, ground));
            attachedTo.transform.position = raycastHit.point;
            attachedTo.GetComponent<BaseController>().targetPos = raycastHit.point;
        }
    }
}
