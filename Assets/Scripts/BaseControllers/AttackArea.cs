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
    [SerializeField] string tag;
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
        if (other.gameObject.CompareTag(tag))
        {
            BaseController bc = other.GetComponent<BaseController>();
            bc.TakeDamage(1 * damageMult,controller);
            modSlots.Attack(AtachTo.staff, bc, 1* damageMult);

            
        }
    }

}
