using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBattleMGR : MonoBehaviour
{
    enum Fase { chompers, spitters, grenadiers, boss }
    [SerializeField] float timeToStartBattle = 90;
    [SerializeField] ExplorerController fakeBoss;
    [SerializeField] BossController killerBoss;
    [SerializeField] Vector3[] spawnPoints;
    [SerializeField] Mob chomper;
    [SerializeField] Mob spitter;
    [SerializeField] Mob grenadier;
    bool isStarted = false;
    Fase currentFase = Fase.chompers;
    float currentTime;
    int nMobs = 0;
    public static BossBattleMGR instance;
    void Awake() {
        instance = this;
        currentTime = timeToStartBattle;
    }

    // Update is called once per frame
    void Update() {
        if(spawnPoints.Length == 0) {
            Debug.LogError("You need to set spawn points!!!");
            return;
        }
        currentTime -= Time.deltaTime;
        if (currentTime <= 0)
            if (!isStarted) {
                Spawn();
                isStarted = true;
            }
    }
    private void SwitchTheBosses() {
        fakeBoss.gameObject.SetActive(false);
        killerBoss.gameObject.SetActive(true);

    }
    private void Spawn() {
        switch (currentFase) {
            case Fase.chompers:
                nMobs = 5;
                for (int i = 0; i < nMobs; i++) {
                    SpawnMob(chomper);
                }
                break;
            case Fase.spitters:
                nMobs = 4;
                for (int i = 0; i < nMobs; i++) {
                    SpawnMob(spitter);
                }
                break;
            case Fase.grenadiers:
                nMobs = 3;
                for (int i = 0; i < nMobs; i++) {
                    SpawnMob(grenadier);
                }
                break;
            case Fase.boss:
                SwitchTheBosses();
                break;
            default:
                break;
        }
    }
    private void SpawnMob(Mob prefab) {
        Mob mob = Instantiate(prefab, transform);
        mob.transform.position = spawnPoints[Random.Range(0, spawnPoints.Length)];
        mob.targetPos = mob.transform.position;
        mob.gameObject.SetActive(true);
        ParticleSystem ps = ParticleMgr.instance.GetExplosion(ParticleType.granedierExplosion);
        ps.transform.position = mob.transform.position;
        ParticleSystem[] arr = ps.GetComponentsInChildren<ParticleSystem>(true);
        foreach (var item in arr) {
            item.gameObject.SetActive(true);
            item.Play();
        }
    }
    public void MobDied() {
        nMobs--;
        if(nMobs == 0) {
            currentFase++;
            Spawn();
        }
    }
}
