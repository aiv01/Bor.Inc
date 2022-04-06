using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New LifeChange", menuName = "Mod/LifeChange")]

public class LifeChange : Mod
{
    [SerializeField] float addMaxHp;
    float oldMaxHp;
    BaseController bc;
    public override void Activate()
    {
        bc = attachedTo.GetComponent<BaseController>();
        oldMaxHp = bc.MaxHp;
        bc.MaxHp += addMaxHp;
        bc.CurrentHp = bc.MaxHp;
        
    }

    public override void Disable()
    {
        bc.MaxHp -= addMaxHp;
        if (bc.CurrentHp > bc.MaxHp) bc.CurrentHp = bc.MaxHp;
    }

}
