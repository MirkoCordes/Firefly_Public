using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    private bool isNull;
    public void OnDrop(PointerEventData eventData)
    {
        eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;

        if (eventData.pointerDrag != null)
        {
            isNull = false;
        } else
        {
            isNull = true;
        }
    }

    public bool IsNull()
    {
        return isNull;
    }
    
}
