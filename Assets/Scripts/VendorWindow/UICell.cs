using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UICell : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        Debug.LogFormat("Drop on cell {0}", this.gameObject.name);

        var go = eventData.pointerDrag;
        ExecuteEvents.Execute<IDropOnValidPositionHandler>(go, eventData, (target, datiAggiuntivi) => target.OnDropOnValidPosition(datiAggiuntivi,this));
    }

    public virtual void RestoreOnPosition() 
    {
        transform.SetParent(this.transform);
    }


}
