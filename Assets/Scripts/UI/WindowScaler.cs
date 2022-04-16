using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowScaler : MonoBehaviour
{
    float refRatio = 16f / 9f;
    float currentRatio = (float)Screen.width / (float)Screen.height;
    Vector3 baseScale;
    private void Awake() {
        baseScale = transform.localScale;
    }
    private void Update() {
        currentRatio = (float)Screen.width / (float)Screen.height;
        transform.localScale = baseScale * Mathf.Min(1f, refRatio / currentRatio);
    }
}
