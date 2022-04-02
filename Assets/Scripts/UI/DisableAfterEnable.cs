using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisableAfterEnable : MonoBehaviour
{
    [SerializeField] float timeToOFF;
    float currentTimer;
    private void OnEnable()
    {
        currentTimer = 0;
    }
 
    void Update()
    {
        if(currentTimer <= timeToOFF)
        {
            currentTimer += Time.deltaTime;
        }
        else
        {
            currentTimer = 0;
            this.gameObject.SetActive(false);
        }
    }
}
