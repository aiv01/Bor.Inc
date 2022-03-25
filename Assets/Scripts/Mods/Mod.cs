using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum AtachTo {
    staff, gun, body
}
[CreateAssetMenu(fileName = "New Mod", menuName = "Mod/Mod")]
public class Mod : ScriptableObject
{
    public AtachTo atachTo = AtachTo.staff;
    [HideInInspector] public ModSlots attachedTo;
    virtual public void DoCicle() {
        
    }
    virtual public void DoAttack(BaseController hit, float damage = 0) {

    }
    virtual public void StrikeAttack() {
    }
    virtual public void Reactivate() {

    }
    virtual public void Activate() {

    }
    virtual public void Disable() {

    }
}
