using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BulletType { baseBullet, Sludge, Grenadier, last}
public class BulletMgr : MonoBehaviour
{
    private List<Bullet>[] nBullets = new List<Bullet>[(int)BulletType.last];
    [SerializeField] private ScriptableBullet[] bulletPrefabs;
    public static BulletMgr instance;
    void Start()
    {
        instance = this;
        for (int i = 0; i < nBullets.Length; i++) {
            nBullets[i] = new List<Bullet>();
        }
    }

    public Bullet GetBullet(BulletType type)
    {
        for (int i = 0; i < nBullets[(int)type].Count; i++) {
            if (!nBullets[(int)type][i].gameObject.activeInHierarchy) {
                return nBullets[(int)type][i];
            }
        }
        ScriptableBullet bullet = null;
        for (int i = 0; i < bulletPrefabs.Length; i++) {
            if (bulletPrefabs[i].type == type) {
                bullet = bulletPrefabs[i];
                break;
            }
        }
        if (!bullet) return null;
        Bullet obj = Instantiate(bullet.prefab, transform);
        //obj.gameObject.SetActive(false);
        nBullets[(int)type].Add(obj);
        return obj;



        //for (int i = 0; i< nbullets.Count; i++)
        //{
        //    if (!nbullets[i].gameObject.activeInHierarchy)
        //    {
        //        return nbullets[i];
        //    }
        //}
        //GameObject obj = Instantiate(bulletPref.gameObject, transform);
        //obj.SetActive(false);
        //nbullets.Add(obj.GetComponent<Bullet>());
        //return obj.GetComponent<Bullet>();
    }
}
