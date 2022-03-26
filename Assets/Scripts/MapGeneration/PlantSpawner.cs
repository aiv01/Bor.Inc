using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSpawner : MonoBehaviour
{
    [SerializeField] Transform[] plants;

    [SerializeField] LayerMask ground;
    Ray ray;
    [SerializeField] float plantMult = 5;

    void Start() {

        

    }
    public void PlacePlants() {
        GameObject folder = new GameObject("Plants");
        folder.transform.parent = transform;
        RaycastHit raycastHit;
        Vector3 pos;
        for (int j = 0; j < plantMult; j++) {

            for (int i = 0; i < plants.Length; i++) {
                Transform plant = Instantiate(plants[i],folder.transform);
                do {
                    pos = new Vector3(Random.Range(0, -transform.position.x * 2), 20f, Random.Range(0, -transform.position.z * 2));
                
                } while (!Physics.Raycast(pos, -transform.up, out raycastHit, 25f, ground));
                plant.position = raycastHit.point;

            }
        }
        folder.transform.localPosition = Vector3.zero;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
