using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonCloseWindow : MonoBehaviour
{
    [SerializeField] Button exitButton;
    [SerializeField] GameObject window;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseWindow()
    {
        window.SetActive(false);
    }
}
