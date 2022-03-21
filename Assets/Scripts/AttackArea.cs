using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    Collider coll;
    /*[HideInInspector]*/ public float damageMult;
    // Start is called before the first frame update
    [SerializeField] ModSlots modSlots;
    void Start()
    {
        coll= GetComponent<Collider>();
        coll.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AttackStart() {
        coll.enabled = true;
    }
    public void AttackEnd() {
        coll.enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        float knockback = 0;
        Status effect = Status.none;
        foreach (Mod mod in modSlots.mod) {
            effect = mod.effect;
            if(mod.atachTo == AtachTo.staff) {
                if(knockback < mod.knokback) {
                    knockback = mod.knokback;
                }
            }
        }
        if (other.gameObject.tag == "Enemy")
        {
            other.GetComponent<Mob>().TakeDamage(1 * damageMult, knockback, effect);
        }
    }

}
