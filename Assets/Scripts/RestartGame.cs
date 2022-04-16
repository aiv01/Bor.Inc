using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartGame : MonoBehaviour
{
    [SerializeField] bool keepItems = false;
    Bundle[] keepBundle = new Bundle[1];
    void Start()
    {
        if (keepItems) keepBundle[0] = ScriptableStaticClass.instance.GetCollectedItems()[Random.Range(0, ScriptableStaticClass.instance.GetCollectedItems().Length)];
        ScriptableStaticClass.instance.Clear();
        if (keepItems) ScriptableStaticClass.instance.SetCollectedItems(keepBundle);
        SaveManager.SaveStaticClassValues();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
