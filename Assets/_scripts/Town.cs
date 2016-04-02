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

    void Update ()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            GameManager.instance.ChangeScene(GameManager.Menus.MAIN);
        }
    }

    void InitMenu()
    {
        Button mainMenu = canvas.GetComponentInChildren<Button>();
        mainMenu.onClick.AddListener(HandleMenuButtonClick);
    }

    public void HandlePlaceButtonClick()
    {

    }

    public void HandleMenuButtonClick()
    {
        GameManager.instance.ChangeScene(GameManager.Menus.MAIN);
    }
	
}
