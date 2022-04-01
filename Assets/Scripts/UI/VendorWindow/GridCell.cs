using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GridCell : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] Image buttonA;
    [SerializeField] public Image modIcon;
    [SerializeField] Color selectedColor;
    [SerializeField] Color notSelectedColor;
    [SerializeField] Sprite noBundleImage;
    [SerializeField] public float bulletBaseDamage = 0.3f;
    Bundle bundle;
    [HideInInspector] public Bundle ConnectedBundle {
        get { return bundle; }
        set {
            bundle = value;
            if(bundle)
                modIcon.sprite = bundle.bundleImage;
            else
                modIcon.sprite = noBundleImage;
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
            if(buttonA) buttonA.gameObject.SetActive(value);
        }
    }
    private bool chosen;
    [HideInInspector] public bool Chosen {
        get { return chosen; }
        set {
            chosen = value;
            //if (buttonA) buttonA.gameObject.SetActive(!value);
            Color c = new Color(1, 1, 1, value ? 0.2f : 1);
            modIcon.color = c;
        }
    }
    private void Awake() {
        circle = GetComponent<Image>();
        
    }

    public void OnPointerClick(PointerEventData eventData) {
        VenderMgr v = GetComponentInParent<VenderMgr>();
        if (v) {
            v.SelectedCell = this;
            if(eventData.clickCount >= 2) {
                v.OnChoose();
            }
            return;
        }
        SelectedGridMGR s = GetComponentInParent<SelectedGridMGR>();
        if (s) {
            s.SelectedCell = this;
        }
    }
}
