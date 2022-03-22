using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModSlots : MonoBehaviour
{
    [SerializeField] private List<Mod> mods = new List<Mod>();
    [HideInInspector] public List<Mod> modsToRemove = new List<Mod>();

    public void Update() {
        foreach (Mod mod in mods) {
            if(mod != null)
                mod.DoCicle();
        }
        foreach (Mod mod in modsToRemove) {
            mods.Remove(mod);
        }
        modsToRemove.Clear();
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
                mods[i].attachedTo = this;
                mods[i].Activate();
                break;
            }
            else if(mods[i] == newMod) {
                mods[i].Reactivate();
                break;
            }
            else if(i == mods.Count - 1){
                newMod.Activate();
                newMod.attachedTo = this;
                mods.Add(newMod);
                break;
            }
        }
    }
    private void RemoveMod(Mod toRemove) {
        mods.Remove(toRemove);
    }
}
