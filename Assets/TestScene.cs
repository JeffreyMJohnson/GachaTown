using UnityEngine;
using System.Collections;

public class TestScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.Alpha1))
	    {
	        GachaManager.Instance.Foo();
	    }
	}
}
