using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Static", menuName = "Static")]
public class ScriptableStaticClass : ScriptableObject
{
    [SerializeField] List<Bundle> collectedBundles;
    [SerializeField] List<Bundle> inInventory;
    [SerializeField] List<Bundle> allPossibleBundles;
    public static ScriptableStaticClass instance;
    public int nKeys = 0;
    public bool foundTreasure;
    public int level;
    public int explorerNumber = 1126;
    public void CreateInstance() {
        instance = this;
    }
    public void Clear() {
        nKeys = 1000;
        foreach (Bundle item in collectedBundles) {
            item.wasFound = false;
        }
        inInventory.Clear();
        collectedBundles.Clear();
    }
    public Bundle FindNewBundle() {
        Bundle b;
        int i;
        do {
            b = allPossibleBundles[Random.Range(0, allPossibleBundles.Count)];
            
        } while (b.wasFound || !CalculateProbability(b.mods[0].level));
        collectedBundles.Add(b);
        return b;
    }
    public Bundle[] GetCollectedItems() {
        return collectedBundles.ToArray();
    }
    public Bundle[] GetInInventoryItems() {
        return inInventory.ToArray();
    }
    private bool CalculateProbability(int level) {
        return Random.Range(0, 50 * (level - 1) + 1) == 0;
    }
    public Bundle GetBundle(int n) {
        return collectedBundles[n];
    }
    public int Count() {
        return collectedBundles.Count;
    }
    public Mod[] GetModsInInventory() {
        List<Mod> m = new List<Mod>();
        foreach (Bundle item in inInventory) {
            m.AddRange(item.mods);
        }
        return m.ToArray();
    }
    public void AddToInventory(Bundle b) {
        inInventory.Add(b);
    }
    public void ClearInventory() {
        inInventory.Clear();
    }
}
