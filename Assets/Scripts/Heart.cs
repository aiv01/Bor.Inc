using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    [SerializeField]float cureValue;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(other.GetComponent<ExplorerController>().CurrentHp + cureValue < other.GetComponent<ExplorerController>().MaxHp)
            {
                other.GetComponent<ExplorerController>().CurrentHp += cureValue;
            }
            else
            {
                other.GetComponent<ExplorerController>().CurrentHp = other.GetComponent<ExplorerController>().MaxHp;
            }
            gameObject.SetActive(false);

        }
    }
}
