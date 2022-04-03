using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] Vector4 nChompersPerLevel;
    [SerializeField] Vector4 nSpittersPerLevel;
    [SerializeField] Vector4 nGranadiersPerLevel;

    [SerializeField] Mob ChomperPrefab;
    [SerializeField] Mob SpitterPrefab;
    [SerializeField] Mob GranadierPrefab;

    [SerializeField] AnimationCurve spawnPosProbability;

    [SerializeField] LayerMask ground;
    GameObject folder;
    List<Transform> mobList = new List<Transform>();
    public Transform[] SpawnEnemy() {
        folder = new GameObject("Enemies");
        folder.transform.parent = transform;
        

        switch (ScriptableStaticClass.instance.level) {
            case 1:
                DoCicle(ChomperPrefab, (int)nChompersPerLevel.x);
                DoCicle(SpitterPrefab, (int)nSpittersPerLevel.x);
                DoCicle(GranadierPrefab, (int)nGranadiersPerLevel.x);
                break;
            case 2:
                DoCicle(ChomperPrefab, (int)nChompersPerLevel.y);
                DoCicle(SpitterPrefab, (int)nSpittersPerLevel.y);
                DoCicle(SpitterPrefab, (int)nGranadiersPerLevel.y);
                break;
            case 3:
                DoCicle(ChomperPrefab, (int)nChompersPerLevel.z);
                DoCicle(SpitterPrefab, (int)nSpittersPerLevel.z);
                DoCicle(GranadierPrefab, (int)nGranadiersPerLevel.z);
                break;
            case 4:
                DoCicle(ChomperPrefab, (int)nChompersPerLevel.w);
                DoCicle(SpitterPrefab, (int)nSpittersPerLevel.w);
                DoCicle(GranadierPrefab, (int)nGranadiersPerLevel.w);
                break;
            default:
                break;
        }
        folder.transform.localPosition = Vector3.zero;
        return mobList.ToArray();
    }

    private void DoCicle(Mob prefab, int n) {
        RaycastHit raycastHit;
        Vector3 pos;
        for (int i = 0; i < n; i++) {
            Mob mob = Instantiate(prefab, folder.transform);
            do {
                pos = new Vector3(Random.Range(0, -transform.position.x * 2), 20f, Random.Range(0, -transform.position.z * 2));

            } while (!Physics.Raycast(pos, -transform.up, out raycastHit, 25f, ground) ||
            Random.Range(0f, 1f) > spawnPosProbability.Evaluate(pos.x / (-transform.position.x * 2)) ||
            Random.Range(0f, 1f) > spawnPosProbability.Evaluate(pos.z / (-transform.position.z * 2))
            );
            mob.transform.position = raycastHit.point;
            mob.targetPos = raycastHit.point;
            mobList.Add(mob.transform);
        }
    }
}
