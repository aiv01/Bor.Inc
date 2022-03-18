using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchifoMano : MonoBehaviour
{
    [SerializeField]GameObject playerHand;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = playerHand.transform.position;
        transform.rotation = playerHand.transform.rotation;
    }


    
}
