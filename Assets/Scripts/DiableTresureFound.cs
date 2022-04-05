using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiableTresureFound : MonoBehaviour
{
    void Start()
    {
        ScriptableStaticClass.instance.foundTreasure = false;
    }
}
