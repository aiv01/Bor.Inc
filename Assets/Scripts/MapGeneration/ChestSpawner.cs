using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestSpawner : MonoBehaviour
{
    [SerializeField] Transform chest;

    [SerializeField] LayerMask ground;
    Ray ray;
    [SerializeField] float chestMult = 2;
    List<Transform> chestList = new List<Transform>();
    public void PlaceChests()
    {
        GameObject folder = new GameObject("Chests");
        folder.transform.parent = transform;
        RaycastHit raycastHit;
        Vector3 pos;
        for (int j = 0; j < chestMult; j++)
        {
            Transform chestClone = Instantiate(chest, folder.transform);
            do
            {
                pos = new Vector3(Random.Range(0, -transform.position.x * 2), 20f, Random.Range(0, -transform.position.z * 2));

            } while (!Physics.Raycast(pos, -transform.up, out raycastHit, 25f, ground));
            chestClone.position = raycastHit.point;
            chestList.Add(chestClone);

        }
        folder.transform.localPosition = Vector3.zero;
    }
}
