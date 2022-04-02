using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticClassInstanciator : MonoBehaviour
{
    ScriptableStaticClass staticClass;
    void Start()
    {
        if (!ScriptableStaticClass.instance) staticClass.CreateInstance();
    }

}
