using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AtachTo {
    staff, gun, body
}
public class Mod : MonoBehaviour
{
    public AtachTo atachTo = AtachTo.staff;
    virtual public void DoCicle() {

    }
    virtual public void DoAttack(BaseController hit) {

    }
}
