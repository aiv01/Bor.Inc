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
    virtual public void DoAttack(BaseController hit) {

    }
    virtual public void Reactivate() {

    }
    virtual public void Activate() {

    }
}
