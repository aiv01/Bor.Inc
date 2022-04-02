using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticClassInstanciator : MonoBehaviour
{
    [SerializeField]ScriptableStaticClass staticClass;
    void Awake()
    {

        if (!ScriptableStaticClass.instance) 
            staticClass.CreateInstance();
    }

}
