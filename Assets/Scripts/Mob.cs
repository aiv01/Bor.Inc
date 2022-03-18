using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mob : MonoBehaviour
{
    [SerializeField] protected float hp;
    [SerializeField] protected float speed;
    [SerializeField] protected float damage;
    [SerializeField] protected float viewDistance;
    [SerializeField] protected float attackDistance;
    protected NavMeshAgent navMesh;
    public Transform target;
    private void Awake() {
        navMesh = GetComponent<NavMeshAgent>();
        navMesh.speed = speed;
    }
}
