using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Poison", menuName = "Mod/Poison")]
public class Poison : Mod
{
    [SerializeField] float poisonTime = 5;
    [SerializeField] float hitsNeeded = 3;
    float currentPoisonTime;
    float currentHits;
    public override void Activate() {
        currentPoisonTime = poisonTime;
        currentHits = hitsNeeded;
    }
    public override void Reactivate() {
        currentHits--;
    }

    public override void DoCicle() {
        if(currentHits <= 1) {
            currentPoisonTime -= Time.deltaTime;
            attachedTo.GetComponent<BaseController>().TakePassiveDamage(0.5f * Time.deltaTime);
            if(currentPoisonTime <= 0) {
                attachedTo.modsToRemove.Add(this);
            }
        }
    }
}
