using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ExplosionType { baseBulletExplosion, poisonExplosion, granedierExplosion, last}
public class ExplosionMgr : MonoBehaviour
{
    private List<ParticleSystem>[] nParticles = new List<ParticleSystem>[(int)ExplosionType.last];
    [SerializeField] private ScriptableExplosion[] particlePrefabs;

    void Start() {
        for (int i = 0; i < nParticles.Length; i++) {
            nParticles[i] = new List<ParticleSystem>();
        }
        //for (int i = 0; i < maxHeart; i++) {
        //    GameObject obj = Instantiate(heartPref.gameObject, transform);
        //    obj.SetActive(false);
        //    nHeart.Add(obj.GetComponent<ParticleSystem>());
        //}
    }

    public Heart GetExplosion(ExplosionType type) {
        //for (int i = 0; i < nHeart.Count; i++) {
        //    if (!nHeart[i].gameObject.activeInHierarchy) {
        //        return nHeart[i];
        //    }
        //}
        //GameObject obj = Instantiate(heartPref.gameObject, transform);
        //obj.SetActive(false);
        //nHeart.Add(obj.GetComponent<Heart>());
        //return obj.GetComponent<Heart>();
        return null;
    }
}
