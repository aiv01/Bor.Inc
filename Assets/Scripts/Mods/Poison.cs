using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison : Mod
{
    [SerializeField] Status eff = Status.poison;
    private void Awake() {
        effect = eff;
    }

}
