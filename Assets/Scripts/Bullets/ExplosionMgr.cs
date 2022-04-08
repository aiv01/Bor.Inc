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

    public ParticleSystem GetExplosion(ExplosionType type) {
        for (int i = 0; i < nParticles[(int)type].Count; i++) {
            if (!nParticles[(int)type][i].gameObject.activeInHierarchy) {
                return nParticles[(int)type][i];
            }
        }
        ScriptableExplosion expl = null;
        for (int i = 0; i < particlePrefabs.Length; i++) {
            if(particlePrefabs[i].type == type) {
                expl = particlePrefabs[i];
                break;
            }
        }
        if (!expl) return null;
        ParticleSystem obj = Instantiate(expl.prefab, transform);
        obj.gameObject.SetActive(false);
        nParticles[(int)type].Add(obj);
        return obj;
        
    }
}
