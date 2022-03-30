using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridCell : MonoBehaviour
{
    [SerializeField] Image buttonA;
    [SerializeField] Color selectedColor;
    [SerializeField] Color notSelectedColor;
    private Image image;
    private bool selected;
    
    [HideInInspector] public bool Selected {
        get {
            return selected;
        }
        set {
            selected = value;
            image.color = value ? selectedColor : notSelectedColor;
        }
    }
    private void Awake() {
        image = GetComponent<Image>();
    }


}
