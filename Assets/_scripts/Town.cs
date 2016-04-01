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
            UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        }
    }

    void InitMenu()
    {
        Button[] mainMenu = canvas.GetComponentsInChildren<Button>();
        for (int i = 0; i < mainMenu.Length; i++)
        {

        }
        mainMenu[0].onClick.AddListener(HandleMenuButtonClick);
        mainMenu[1].onClick.AddListener(HandlePlaceButtonClick);
    }

    public void HandlePlaceButtonClick()
    {

    }

    public void HandleMenuButtonClick()
    {
        GameManager.instance.ChangeScene(GameManager.Menus.MAIN);
    }
	
}
