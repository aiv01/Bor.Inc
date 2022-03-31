using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Multiple Shot", menuName = "Mod/MultiShot")]
public class MultipleShot : Mod
{
    [SerializeField] float angle;
    [SerializeField] int nBullets;
    BaseController bc;
    float slice;
    public override void Activate() {
        bc = attachedTo.GetComponent<BaseController>();
        slice = angle / nBullets;
    }
    public override void StrikeAttack() {
        for (int i = -(nBullets - 1) / 2; i < (nBullets - 1) / 2 + 1; i++) {
            if (i == 0) continue;
            Bullet bullet = BulletMgr.instance.GetBullet();
            if (bullet != null) {
                bullet.transform.position = bc.bulletPos.position;
                bullet.transform.rotation = Quaternion.LookRotation(attachedTo.transform.forward, Vector3.up) /** Quaternion.AngleAxis(-angle * 0.5f, Vector3.up)*/ * Quaternion.AngleAxis(slice * i, Vector3.up);
                bullet.gameObject.SetActive(true);
                bullet.GetComponent<Bullet>().Shoot(bc, "Enemy");
            }
        }
        
    }
}
