using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBoss : MonoBehaviour
{
    [SerializeField] float timeToStartBattle = 90;
    [SerializeField] ExplorerController boss;
    float currentTime;
    void Start()
    {
        currentTime = timeToStartBattle;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
        if (currentTime <= 0) {
            boss.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
