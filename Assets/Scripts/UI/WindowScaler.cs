using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowScaler : MonoBehaviour
{
    float refRatio = 16 / 9;
    float currentRatio = Screen.width / Screen.height;
    private void Update() {
        transform.localScale = Vector3.one * Mathf.Min(0.4166666f, refRatio / currentRatio);
    }
}
