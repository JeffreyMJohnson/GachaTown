using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Settings : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Button[] buttons = FindObjectsOfType<Button>();

        foreach (Button button in buttons)
        {

            switch (button.name)
            {
                case "LowerBGM":                   
                    button.onClick.AddListener(GameManager.instance.LowerVolumeFX);
                    break;
                case "RaiseBGM":
                    button.onClick.AddListener(GameManager.instance.RaiseVolumeFX);
                    break;
                case "LowerMusic":
                    button.onClick.AddListener(GameManager.instance.LowerVolumeMusic);
                    break;
                case "RaiseMusic":
                    button.onClick.AddListener(GameManager.instance.RaiseVolumeMusic);
                    break;

                default:

                    break;

            }

        }
    }
	
	// Update is called once per frame
	void Update () {
      
    }

    
}
