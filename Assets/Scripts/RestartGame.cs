using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartGame : MonoBehaviour
{
    void Start()
    {
        ScriptableStaticClass.instance.Clear();
        SaveManager.SaveStaticClassValues();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
