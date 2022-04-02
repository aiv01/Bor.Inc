using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Static", menuName = "Static")]
public class ScriptableStaticClass : ScriptableObject
{
    [SerializeField] List<Bundle> collectedBundles;
    [SerializeField] List<Bundle> inInventory;
    [SerializeField] List<Bundle> allPossibleBundles;
    public int nKeys = 0;

    public void Clear() {
        nKeys = 0;
        foreach (Bundle item in collectedBundles) {
            item.wasFound = false;
        }
        inInventory.Clear();
        collectedBundles.Clear();
    }
    public Bundle FindNewBundle() {
        Bundle b;
        do {
            b = allPossibleBundles[Random.Range(0, allPossibleBundles.Count)];
        } while (b.wasFound && 3 - b.mods[0].level < Random.Range(0, 3));
        collectedBundles.Add(b);
        return b;
    }
    public Bundle GetBundle(int n) {
        return collectedBundles[n];
    }
    public int Count() {
        return collectedBundles.Count;
    }
}
