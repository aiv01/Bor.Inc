using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartMgr : MonoBehaviour
{
    [SerializeField] private List<Heart> nHeart = new List<Heart>();
    private int maxHeart;
    [SerializeField] private Heart heartPref;

    void Start()
    {
        for(int i = 0; i < maxHeart; i++)
        {
            GameObject obj = Instantiate(heartPref.gameObject, transform);
            obj.SetActive(false);
            nHeart.Add(obj.GetComponent<Heart>());
        }
    }

    public Heart GetHeart()
    {
        for(int i = 0; i< nHeart.Count; i++)
        {
            if (!nHeart[i].gameObject.activeInHierarchy)
            {
                return nHeart[i];
            }
        }
        GameObject obj = Instantiate(heartPref.gameObject, transform);
        obj.SetActive(false);
        nHeart.Add(obj.GetComponent<Heart>());
        return obj.GetComponent<Heart>();
    }
}
