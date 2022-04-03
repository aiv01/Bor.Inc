using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EllenSpawner : MonoBehaviour
{
    [SerializeField] Vector3 newGameSpawnPoint;
    [SerializeField] Vector3 spawnPoint;
    [SerializeField] Transform ellen;
    void Start()
    {
        if (ScriptableStaticClass.instance.level == 1)
            ellen.position = newGameSpawnPoint;
        else ellen.position = spawnPoint;
        ellen.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
