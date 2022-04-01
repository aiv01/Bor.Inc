using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchifoMano : MonoBehaviour
{
    [SerializeField]GameObject playerHand;
    float speed;

    void Start()
    {
        //this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        //{
        //    this.gameObject.SetActive(true);
        //    transform.localScale = new Vector3(1, 1, Mathf.Lerp(transform.localScale.z, 1, speed));
        //}
        transform.position = playerHand.transform.position;
        transform.rotation = playerHand.transform.rotation;
    }
}
