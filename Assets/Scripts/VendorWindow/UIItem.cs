using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIItem : MonoBehaviour,IDropOnValidPositionHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    Graphic gr;
    Transform originalParent;

    Vector3 offset;
    UICell lastParent;
    bool dropOnValidPosition = false;
    public Text debug;

    private void Awake()
    {
        
        debug.text = GetInstanceID().ToString();
        gr = GetComponent<Graphic>();
        originalParent = transform.parent;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        offset = new Vector3(eventData.position.x, eventData.position.y) - transform.position;
        gr.raycastTarget = false;
        transform.SetParent(originalParent);
        transform.SetAsLastSibling();
        lastParent = transform.parent.GetComponent<UICell>();
        dropOnValidPosition = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = new Vector3(eventData.position.x, eventData.position.y) - offset;
    }


    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        gr.raycastTarget = true;
        if (!dropOnValidPosition)
        {
            lastParent.RestoreOnPosition();
 
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.rotation = Quaternion.Euler(0, 0, 15);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    public void OnDropOnValidPosition(BaseEventData eventData,UICell parent)
    {
        dropOnValidPosition = true;
        lastParent = parent;
        parent.RestoreOnPosition();
    }
}
