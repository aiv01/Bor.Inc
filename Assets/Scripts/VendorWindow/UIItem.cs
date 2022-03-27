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

    Vector3 lastposition;
    Transform lastParent;
    bool dropOnValidPosition = false;

    private void Awake()
    {
        gr = GetComponent<Graphic>();
        originalParent = transform.parent;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        offset = new Vector3(eventData.position.x, eventData.position.y) - transform.position;
        gr.raycastTarget = false;
        transform.SetParent(originalParent);
        transform.SetAsLastSibling();
        lastParent = transform.parent;
        lastposition = transform.position;
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
            transform.SetParent(lastParent);
            transform.position = lastposition;
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

    public void OnDropOnValidPosition(BaseEventData eventData,Transform parent)
    {
        dropOnValidPosition = true;
        transform.SetParent(parent);
        transform.position = parent.position;
    }
}
