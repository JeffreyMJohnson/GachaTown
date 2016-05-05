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
    public class OnGachaDragEvent : UnityEvent<GachaID> { }
    public class OnGachaDropEvent : UnityEvent<PointerEventData> { }
    public OnGachaDragEvent onGachaDrag = new OnGachaDragEvent();
    public OnGachaDropEvent onGachaDrop = new OnGachaDropEvent();


    public void OnBeginDrag(PointerEventData eventData)
    {
        GameObject clickedObject = eventData.pointerDrag;
        GachaUI script = clickedObject.GetComponent<GachaUI>();
        onGachaDrag.Invoke(script.ID);
    }

    public void OnDrag(PointerEventData eventData) { }

    public void OnEndDrag(PointerEventData eventData)
    {
        onGachaDrop.Invoke(eventData);
    }
}
