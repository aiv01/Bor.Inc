using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float bulletDamage = 0.3f;
    float currentSpeed = 0;
    private float timer = 10f;
    private float currentTimer;
    private string targetTag;
    private string oldTag;
    BaseController controller;
    ModSlots modSlots;

    void OnEnable()
    {
        currentTimer = 0;
    }
    protected virtual void OnDisable()
    {
        currentSpeed = 0;
    }
    // Update is called once per frame
    protected virtual void Update()
    {
        currentTimer += Time.deltaTime;
        transform.position += transform.forward * currentSpeed * Time.deltaTime;
        if(currentTimer >= timer)
        {
            this.gameObject.SetActive(false);
            currentTimer = 0;
        }
    }

    public void Shoot(BaseController shooter, string tag, float damage = 0)
    {
        if (damage != 0) bulletDamage = damage;
        this.targetTag = tag;
        currentSpeed = speed;
        controller = shooter;
        modSlots = shooter.GetComponent<ModSlots>(); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag(targetTag))
        {
            this.gameObject.SetActive(false);
            BaseController bc = other.GetComponent<BaseController>();
            bc.TakeDamage(bulletDamage, controller);
            modSlots.Attack(AtachTo.gun, bc, bulletDamage);
            currentTimer = 0;
        }
        if(targetTag == "Enemy" && other.gameObject.CompareTag("BulletProof")) {
            oldTag = targetTag;
            targetTag = controller.tag;
            transform.forward *= -1;
        }
    }
}
