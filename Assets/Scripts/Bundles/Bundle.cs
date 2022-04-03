using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
[CreateAssetMenu(fileName = "New Bundle", menuName = "Bundle")]
public class Bundle : ScriptableObject
{
    [SerializeField] public Sprite bundleImage;
    [SerializeField] public List<Mod> mods = new List<Mod>();
    [SerializeField] public string description;
    public bool wasFound = false;
}
