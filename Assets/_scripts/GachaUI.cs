using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class GachaUI : MonoBehaviour,
    IBeginDragHandler,
    IDragHandler,
    IEndDragHandler
{
    public GachaID ID { get; set; }
    public class OnGachaDragEvent : UnityEvent<GameObject> { }
    public class OnGachaDropEvent : UnityEvent<PointerEventData> { }
    public OnGachaDragEvent onGachaDrag = new OnGachaDragEvent();
    public OnGachaDropEvent onGachaDrop = new OnGachaDropEvent();


    public void OnBeginDrag(PointerEventData eventData)
    {
        onGachaDrag.Invoke(eventData.pointerDrag);
    }

    public void OnDrag(PointerEventData eventData) { }

    public void OnEndDrag(PointerEventData eventData)
    {
        onGachaDrop.Invoke(eventData);
    }
}
