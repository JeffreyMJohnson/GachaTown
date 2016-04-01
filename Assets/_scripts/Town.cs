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
        Button mainMenu = canvas.GetComponentInChildren<Button>();
        mainMenu.onClick.AddListener(HandleButtonClick);
    }

    public void HandleButtonClick()
    {
        GameManager.instance.ChangeScene(GameManager.Menus.MAIN);
    }
	
}
