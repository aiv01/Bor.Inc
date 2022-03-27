using UnityEngine;
using System.Collections;

public enum _cullingType { ActivateGO, EnableAnimator, PausePS}
public class CullingGroupOps : MonoBehaviour
{
    public _cullingType cullType;
    public bool getInfo;
    private CullingGroup group = null;
    private BoundingSphere[] bounds;
    
    [SerializeField] Transform[] targets = null;

    public void SetUp(Transform[] targets)
    {
        this.targets = targets;
        group = new CullingGroup();

        //Is visible depends on the POV of this camera
        group.targetCamera = Camera.main;

        // 1:1m 2:5m 3:10m, 4:30m, 5:100m 
        group.SetDistanceReferencePoint(Camera.main.transform);
        group.SetBoundingDistances(new float[] { 1, 5, 10, 30, 100 });

        bounds = new BoundingSphere[targets.Length];
        for (int i = 0; i < bounds.Length; i++)
            bounds[i].radius = 1.5f;

        group.SetBoundingSpheres(bounds);
        group.SetBoundingSphereCount(targets.Length);

        group.onStateChanged = OnChange;
    }

    void Update()
    {
        for (int i = 0; i < bounds.Length; i++)
        {
            bounds[i].position = targets[i].position;
        }
        if (getInfo)
        {
            getInfo = false;
            printInfo();
        }
    }

    void OnDestroy()
    {
        group.onStateChanged -= OnChange;
        group.Dispose();
        group = null;
    }

    void printInfo()
    {
        for (int i = 0; i < bounds.Length; i++)
            Debug.Log("Sphere[" + i + "] visible:" + group.IsVisible(i) + ", distance:" + group.GetDistance(i));
        // Allocate an array to hold the resulting sphere indices - the size of the array determines the maximum spheres checked per call
        int[] resultIndices = new int[10];
        // Also set up an int for storing the actual number of results that have been placed into the array
        int numResults = 0;
        // Find all spheres that are visible
        numResults = group.QueryIndices(true, resultIndices, 0);
        // Find all spheres that are in distance band 1
        numResults = group.QueryIndices(1, resultIndices, 0);
        // Find all spheres that are hidden in distance band 1, skipping the first 2
        numResults = group.QueryIndices(false, 1, resultIndices, 2);
    }

    void OnChange(CullingGroupEvent ev)
    {
        //Debug.Log("Sphere["+ ev.index+"] ("+targets[ev.index].gameObject.name + ") is now inside DistanceBand: " + ev.currentDistance);
        switch (cullType) {
            case _cullingType.ActivateGO:
                Mob m = targets[ev.index].GetComponent<Mob>();
                if (m && m.CurrentHp <= 0) break;
                targets[ev.index].gameObject.SetActive(ev.currentDistance < 4);
                break;
            case _cullingType.EnableAnimator:
            targets[ev.index].gameObject.GetComponent<Animator>().enabled = (ev.currentDistance < 2);
                break;
            case _cullingType.PausePS:
                if (ev.isVisible)
                    targets[ev.index].gameObject.GetComponent<ParticleSystem>().Play();
                else
                    targets[ev.index].gameObject.GetComponent<ParticleSystem>().Pause();
                break;

        }

    }
}