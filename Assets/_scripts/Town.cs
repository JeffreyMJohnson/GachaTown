using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Town : MonoBehaviour
{
    Canvas canvas;
    
	void Start ()
    {
        canvas = FindObjectOfType<Canvas>();
        InitMenu();
	}

    void InitMenu()
    {
        Button mainMenu = canvas.GetComponentInChildren<Button>();
        mainMenu.onClick.AddListener(HandleButtonClick);
    }

    public void HandleButtonClick()
    {
        GameManager.instance.ChangeScene(GameManager.Menus.MAIN);
    }
	
}
