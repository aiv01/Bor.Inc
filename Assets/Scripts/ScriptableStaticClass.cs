using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Static", menuName = "Static")]
public class ScriptableStaticClass : ScriptableObject
{
    public List<Bundle> collectedBundles;
    public List<Bundle> inInventory;
    public int nKeys = 0;
    public bool finishLevel = false;
}
