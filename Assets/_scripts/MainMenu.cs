using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    void Start()
    {
        InitButtonHandlers();
    }

    public void HandleClick(GameManager.Menus scene)
    {
        GameManager.instance.ChangeScene(scene);
    }

    void InitButtonHandlers()
    {
        Button[] buttons = GetComponentsInChildren<Button>();

        foreach (Button button in buttons)
        {
            GameManager.Menus scene = GameManager.Menus.MAIN;
            switch (button.name)
            {
                case "Gacha Machines":
                    scene = GameManager.Menus.GACHACHOOSE;
                    break;
                case "Visit Town":
                    scene = GameManager.Menus.TOWN;
                    break;
                case "View Collection":
                    scene = GameManager.Menus.COLLECTION;
                    break;
                case "How To Play":
                    continue;
                    break;
            }
            button.onClick.AddListener(delegate { HandleClick(scene); });

        }
    }

}
