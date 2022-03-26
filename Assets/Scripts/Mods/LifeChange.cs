using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New LifeChange", menuName = "Mod/LifeChange")]

public class LifeChange : Mod
{
    [SerializeField] float addMaxHp;
    float oldMaxHp;
    public override void Activate()
    {
        oldMaxHp = attachedTo.GetComponent<ExplorerController>().MaxHp;
        attachedTo.GetComponent<ExplorerController>().MaxHp += addMaxHp;
    }

    public override void Disable()
    {
        attachedTo.GetComponent<ExplorerController>().MaxHp -= addMaxHp;
    }

}
