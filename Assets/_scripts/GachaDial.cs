using UnityEngine;
using System.Collections;

public class GachaDial : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        thing();
	}

    void thing()
    {
        RaycastHit hit;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.name == "LeftUpper")
                {
                    transform.Rotate(new Vector3(transform.rotation.x, transform.rotation.y, (-Input.GetAxis("Mouse X") * 5) + (-Input.GetAxis("Mouse Y") * 5)));
                }
                if (hit.collider.name == "RightUpper")
                {
                    transform.Rotate(new Vector3(transform.rotation.x, transform.rotation.y, (-Input.GetAxis("Mouse X") * 5) + (Input.GetAxis("Mouse Y") * 5)));
                }
                if (hit.collider.name == "LeftLower")
                {
                    transform.Rotate(new Vector3(transform.rotation.x, transform.rotation.y, (Input.GetAxis("Mouse X") * 5) + (-Input.GetAxis("Mouse Y") * 5)));
                }
                if (hit.collider.name == "RightLower")
                {
                    transform.Rotate(new Vector3(transform.rotation.x, transform.rotation.y, (Input.GetAxis("Mouse X") * 5) + (Input.GetAxis("Mouse Y") * 5)));
                }
            }
        }
        
    }
}
