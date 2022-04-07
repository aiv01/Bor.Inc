using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    [SerializeField]float cureValue;
    [SerializeField]float rotateSpeed;
    string pTag = "Player";
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, rotateSpeed, 0));
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag(pTag))
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
