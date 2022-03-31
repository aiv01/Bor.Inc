using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Bundle", menuName = "Bundle")]
public class Bundle : Mod
{
    [SerializeField] public Sprite bundleImage;
    [SerializeField] List<Mod> mods;
    [SerializeField] string description;
}
