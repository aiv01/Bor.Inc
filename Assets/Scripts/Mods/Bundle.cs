using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Bundle", menuName = "Mod/AAA Bundle")]
public class Bundle : Mod
{
    [SerializeField] Texture bundleImage;
    [SerializeField] List<Mod> mods;
    [SerializeField] string description;
}
