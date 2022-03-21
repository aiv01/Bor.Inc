using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed;
    private float timer = 10f;
    private float currentTimer;
    void OnEnable()
    {
        currentTimer = 0;
    }
    // Update is called once per frame
    void Update()
    {
        currentTimer += Time.deltaTime;
        transform.position += transform.forward * speed * Time.deltaTime;
        if(currentTimer >= timer)
        {
            this.gameObject.SetActive(false);
            currentTimer = 0;
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            this.gameObject.SetActive(false);
            currentTimer = 0;
        }
    }
}
