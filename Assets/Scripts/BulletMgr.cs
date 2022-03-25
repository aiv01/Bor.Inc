using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMgr : MonoBehaviour
{
    public static BulletMgr instance;
    [SerializeField] private List<Bullet> nbullets = new List<Bullet>();
    [SerializeField] private int maxBullet = 50;
    [SerializeField] private Bullet bulletPref;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        for(int i = 0; i < maxBullet; i++)
        {
            GameObject obj = Instantiate(bulletPref.gameObject, transform);
            obj.SetActive(false);
            nbullets.Add(obj.GetComponent<Bullet>());
        }
    }

    public Bullet GetBullet()
    {
        for(int i = 0; i< nbullets.Count; i++)
        {
            if (!nbullets[i].gameObject.activeInHierarchy)
            {
                return nbullets[i];
            }
        }
        GameObject obj = Instantiate(bulletPref.gameObject, transform);
        obj.SetActive(false);
        nbullets.Add(obj.GetComponent<Bullet>());
        return obj.GetComponent<Bullet>();
    }
}
