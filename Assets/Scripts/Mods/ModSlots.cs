using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModSlots : MonoBehaviour
{
    [SerializeField] private List<Mod> mods = new List<Mod>();

    public void Update() {
        foreach (Mod mod in mods) {
            if(mod != null)
                mod.DoCicle();
        }
    }
    public void Attack(AtachTo type, BaseController hit) {
        foreach (Mod mod in mods) {
            if(mod != null && mod.atachTo == type)
                mod.DoAttack(hit);
        }
    }
    public void AddMod(Mod newMod) {
        for (int i = 0; i < mods.Count; i++) {
            if(mods[i] == null) {
                mods[i] = newMod;
                break;
            }
            else if(mods[i] == newMod) {
                break;
            }
            else if(i == mods.Count - 1){
                mods.Add(newMod);
                break;
            }
        }
    }
    public void RemoveMod(Mod toRemove) {
        mods.Remove(toRemove);
    }
}
