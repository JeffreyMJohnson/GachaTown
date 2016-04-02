using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GachaDrag : MonoBehaviour
{
    GameObject draggedGacha = null;
    public string childToCopy;
    GameObject gachaPrefab;

    // Use this for initialization
    void Start ()
    {
        gachaPrefab = transform.FindChild(childToCopy).gameObject;

	}
	
    void OnMouseDrag()
    {
        if (draggedGacha == null)
        {
            draggedGacha = Instantiate<GameObject>(gachaPrefab);
        }
        Vector3 gachaPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward * 3 - Vector3.up * 3;
        draggedGacha.transform.position = gachaPosition;
    }

	void Update()
    {
        if (Input.GetMouseButtonUp(0) && draggedGacha != null)
        {
            draggedGacha = null;
        }
    }

}
