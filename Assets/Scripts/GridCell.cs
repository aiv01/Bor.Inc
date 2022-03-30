using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridCell : MonoBehaviour
{
    [SerializeField] Image buttonA;
    [SerializeField] public Image modIcon;
    [SerializeField] Color selectedColor;
    [SerializeField] Color notSelectedColor;
    Bundle bundle;
    [HideInInspector] public Bundle ConnectedBundle {
        get { return bundle; }
        set {
            bundle = value;
            if(bundle)
            modIcon.sprite = bundle.bundleImage;
        }
    }
    private Image circle;
    private bool selected;
    
    [HideInInspector] public bool Selected {
        get {
            return selected;
        }
        set {
            selected = value;
            if(!circle) circle = GetComponent<Image>();
            circle.color = value ? selectedColor : notSelectedColor;
            buttonA.gameObject.SetActive(value);
        }
    }
    private bool chosen;
    [HideInInspector] public bool Chosen {
        get { return chosen; }
        set {
            chosen = value;
            buttonA.gameObject.SetActive(!value);
            Color c = new Color(1, 1, 1, value ? 0.2f : 1);
            modIcon.color = c;
        }
    }
    private void Awake() {
        circle = GetComponent<Image>();
        
    }


}
