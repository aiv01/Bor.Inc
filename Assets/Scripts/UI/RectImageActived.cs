using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RectImageActived : MonoBehaviour
{
    [SerializeField] Image recOn;
    [SerializeField] Image recOff;
    float timer = 1f;
    float currentTimer;
    void Start()
    {
        recOn.gameObject.SetActive(true);
        recOff.gameObject.SetActive(false);
        currentTimer = timer;
    }

    // Update is called once per frame
    void Update()
    {
        currentTimer -= Time.deltaTime;
        if(recOn.IsActive() && currentTimer <= 0)
        {
            recOn.gameObject.SetActive(false);
            recOff.gameObject.SetActive(true);
            currentTimer = timer;
        }
        else if (!recOn.IsActive() && currentTimer <= 0)
        {
            recOn.gameObject.SetActive(true);
            recOff.gameObject.SetActive(false);
            currentTimer = timer;
        }
    }
}
