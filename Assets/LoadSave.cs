using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSave : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        SaveManager.LoadSave();
        ScriptableStaticClass.instance.foundTreasure = true;
        //SaveObject so = SaveManager.Load();
        //ScriptableStaticClass.instance.SetCollectedItems(so.collectedBundles);
        //ScriptableStaticClass.instance.SetInInventoryItems(so.inInventory);
        //ScriptableStaticClass.instance.nKeys = so.nKeys;
        //ScriptableStaticClass.instance.level = so.level;
        //ScriptableStaticClass.instance.explorerNumber = so.explorerNumber;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
