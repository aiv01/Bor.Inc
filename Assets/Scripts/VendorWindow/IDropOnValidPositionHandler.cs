using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public interface IDropOnValidPositionHandler : IEventSystemHandler
{
    void OnDropOnValidPosition(BaseEventData eventData, UICell parent);
}
