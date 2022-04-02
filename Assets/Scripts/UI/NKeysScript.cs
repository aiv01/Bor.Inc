using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NKeysScript : MonoBehaviour
{
    [SerializeField]Text keys;
    [SerializeField]ScriptableStaticClass info;
    void Start()
    {
        info.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        keys.text = " x " + info.nKeys;
    }
}
