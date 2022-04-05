using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModAdder : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        foreach (Mod item in ScriptableStaticClass.instance.GetModsInInventory()) {
            GetComponent<ModSlots>().AddMod(item);
        }
    }

}
