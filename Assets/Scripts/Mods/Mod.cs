using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AtachTo {
    staff, gun, body
}
public class Mod : MonoBehaviour
{
    public Status effect = Status.none;
    public float damagePerSec = 1;
    //public float hits = 5;
    public float timeToCure = 3;
    public float knokback = 0;
    public AtachTo atachTo = AtachTo.staff;
}
