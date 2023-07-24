using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    Vector3 posInicial;
    public Transform transformPadre;
    public static GameObject itemDrag;
    public void OnBeginDrag(PointerEventData eventData)
    {
        itemDrag = gameObject;
        transformPadre = transform.parent;
        posInicial = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = posInicial;     
        itemDrag= null;
    }
}
