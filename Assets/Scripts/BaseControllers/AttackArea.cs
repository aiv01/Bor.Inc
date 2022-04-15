using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    Collider coll;
    BaseController controller;
    /*[HideInInspector]*/ public float damageMult;
    // Start is called before the first frame update
    [SerializeField] ModSlots modSlots;
    [SerializeField] LayerMask layer;
    [SerializeField] ParticleType particle = ParticleType.last;
    void Start()
    {
        coll= GetComponent<Collider>();
        controller = GetComponentInParent<BaseController>();
        coll.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AttackStart() {
        modSlots.StrikeAttack(AtachTo.staff);
        coll.enabled = true;
    }
    public void AttackEnd() {
        coll.enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if((layer.value & (1 << other.gameObject.layer)) > 0)
        {
            if(particle != ParticleType.last) {
                ParticleSystem ps = ParticleMgr.instance.GetExplosion(particle);
                ps.transform.position = other.transform.position;
                
                ParticleSystem[] arr = ps.GetComponentsInChildren<ParticleSystem>(true);
                foreach (var item in arr) {
                    item.gameObject.SetActive(true);
                    item.Play();
                }
            }
            BaseController bc = other.GetComponent<BaseController>();
            bc.TakeDamage(1 * damageMult,controller);
            modSlots.Attack(AtachTo.staff, bc, 1* damageMult);

            
        }
    }

}
