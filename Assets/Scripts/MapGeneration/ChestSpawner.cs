using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestSpawner : MonoBehaviour
{
    [SerializeField] Transform chest;
    [SerializeField] Transform finalChest;

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
        float maxDist = 0;
        Transform furtherChest = null;
        foreach (Transform item in chestList) {
            if(item.position.sqrMagnitude > maxDist) {
                maxDist = item.position.sqrMagnitude;
                furtherChest = item;
            }
        }
        chestList.Remove(furtherChest);
        chestList.Add(Instantiate(finalChest, furtherChest.position, furtherChest.rotation, folder.transform));
        Destroy(furtherChest.gameObject);
        folder.transform.localPosition = Vector3.zero;
    }
}
