﻿using UnityEngine;
using System.Collections;

public class SplashScreen : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.anyKey)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(1);
            //GameManager.Instance.ChangeScene(GameManager.Scene.MAIN);
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
