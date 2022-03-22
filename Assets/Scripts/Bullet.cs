using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed;
    float currentSpeed = 0;
    private float timer = 10f;
    private float currentTimer;
    private string crecker;
    BaseController controller;
    ModSlots modSlots;

    void OnEnable()
    {
        currentTimer = 0;
    }
    private void OnDisable()
    {
        currentSpeed = 0;
    }
    // Update is called once per frame
    void Update()
    {
        currentTimer += Time.deltaTime;
        transform.position += transform.forward * currentSpeed * Time.deltaTime;
        if(currentTimer >= timer)
        {
            this.gameObject.SetActive(false);
            currentTimer = 0;
        }
    }

    public void Shoot(BaseController shooter, string crecker)
    {
        this.crecker = crecker;// se lo cambi ti spacco come un crecker eheh;
        currentSpeed = speed;
        controller = shooter;
        modSlots = shooter.GetComponent<ModSlots>(); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == crecker)
        {
            this.gameObject.SetActive(false);
            BaseController bc = other.GetComponent<BaseController>();
            bc.TakeDamage(0.3f, controller);
            modSlots.Attack(AtachTo.gun, bc);
            currentTimer = 0;
        }
    }
}
