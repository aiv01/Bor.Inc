using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModSlots : MonoBehaviour
{
    [SerializeField] private List<Mod> mods = new List<Mod>();
    [HideInInspector] public List<Mod> modsToRemove = new List<Mod>();
    public void Awake()
    {
        for (int i = 0; i < mods.Count; i++) {

            if (mods[i] != null)
            {
                mods[i] = Instantiate(mods[i]);
                mods[i].attachedTo = this;
                mods[i].Activate();
            } 
        }
    }
    public void Update() {
        foreach (Mod mod in mods) {
            if(mod != null)
                mod.DoCicle();
        }
        foreach (Mod mod in modsToRemove) {
            mod.Disable();
            mods.Remove(mod);
        }
        modsToRemove.Clear();
    }
    public void StrikeAttack(AtachTo type) {
        foreach (Mod mod in mods) {
            if (mod != null && mod.atachTo == type)
                mod.StrikeAttack();
        }
    }
    public void Attack(AtachTo type, BaseController hit, float damage = 0) {
        foreach (Mod mod in mods) {
            if(mod != null && mod.atachTo == type)
                mod.DoAttack(hit, damage);
        }
    }
    public void AddMod(Mod newMod) {
        newMod = Instantiate(newMod);
        for (int i = 0; i < mods.Count; i++) {
            if(mods[i] == null) {
                mods[i] = newMod;
                mods[i].attachedTo = this;
                mods[i].Activate();
                return;
            }
            else if(mods[i].name == newMod.name) {
                mods[i].Reactivate();
                return;
            }
        }
        mods.Add(newMod);
        newMod.attachedTo = this;
        newMod.Activate();
        return;
    }
    public void OnHit() {
        foreach (Mod mod in mods) {
            if(mod) mod.OnHit();
        }
    }
    private void RemoveMod(Mod toRemove) {
        mods.Remove(toRemove);
    }
}
