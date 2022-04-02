using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySpawner : MonoBehaviour
{
    [SerializeField] Transform key;

    [SerializeField] LayerMask ground;
    Ray ray;
    [SerializeField] float keyMult = 2;
    List<Transform> Keylist = new List<Transform>();
    public void PlaceKeys()
    {
        GameObject folder = new GameObject("Keys");
        folder.transform.parent = transform;
        RaycastHit raycastHit;
        Vector3 pos;
        for (int j = 0; j < keyMult; j++)
        {
                Transform plant = Instantiate(key, folder.transform);
                do
                {
                    pos = new Vector3(Random.Range(0, -transform.position.x * 2), 20f, Random.Range(0, -transform.position.z * 2));

                } while (!Physics.Raycast(pos, -transform.up, out raycastHit, 25f, ground));
                plant.position = raycastHit.point;
                Keylist.Add(plant);
            
        }
        folder.transform.localPosition = Vector3.zero;
    }
}
