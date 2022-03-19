using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMgr : MonoBehaviour
{
    public static BulletMgr instance;
    private List<GameObject> nbullets = new List<GameObject>();
    private int maxBullet = 50;
    [SerializeField] private GameObject bulletPref;

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
            GameObject obj = Instantiate(bulletPref, transform);
            obj.SetActive(false);
            nbullets.Add(obj);
        }
    }

    public GameObject GetBullet()
    {
        for(int i = 0; i< nbullets.Count; i++)
        {
            if (!nbullets[i].activeInHierarchy)
            {
                return nbullets[i];
            }
        }
        return null;
    }
}
