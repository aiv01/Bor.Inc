using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


public class CullingFromPlayer : MonoBehaviour
{
    List<Transform> cullingObjects = new List<Transform>();
    public float distance = 25;
    public int checkForFrame = 30;
    public Transform playerTransform;

    float sqrtDistance;
    int currentIndex = 0;

    public void SetUp(List<Transform> targets)
    {
        this.cullingObjects = targets;
        sqrtDistance = distance * distance;
    }

    void Update()
    {
        if (cullingObjects.Count == 0) return;

        for (int i = 0; i < checkForFrame; i++) {
            currentIndex++;
            if (currentIndex >= cullingObjects.Count) currentIndex = 0;

            var target = cullingObjects[currentIndex];

            bool needToBeShowed = ((playerTransform.position - target.position).sqrMagnitude < sqrtDistance);

            ShowHide(target.gameObject, needToBeShowed);
            
        }
    }

    private void ShowHide(GameObject target, bool needToBeShowed) {
        
        if (target.layer == 3) {
            if (needToBeShowed) {
                SetLayerRecursively(target, 6);
                cullingObjects.Remove(target.transform);
            }
        } else {
            if (target.activeSelf != needToBeShowed) target.SetActive(needToBeShowed);
        }
    }

    void SetLayerRecursively(GameObject obj, int newLayer) {
        if (null == obj) {
            return;
        }

        obj.layer = newLayer;

        foreach (Transform child in obj.transform) {
            if (null == child) {
                continue;
            }
            SetLayerRecursively(child.gameObject, newLayer);
        }
    }

}