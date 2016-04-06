using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BuyGacha : MonoBehaviour
{


    public Text moneyTextField;
    public Text displayTextField;
    public int GachaSet = 0;

    Player localPlayer;

    void Start()
    {
        GameObject tPlayer = GameObject.FindGameObjectWithTag("Player");
        localPlayer = tPlayer.GetComponent<Player>();
        moneyTextField.text = localPlayer.TotalCoins.ToString();
        displayTextField.text = GameManager.instance.GetGachaSet(GachaSet).name;

        //add onclick event for menu button
        Button[] buttons = FindObjectsOfType<Button>();
        foreach (Button button in buttons)
        {
            switch(button.name)
            {
                case "Main Menu Button":
                    button.onClick.AddListener(LoadMainMenu);
                    break;
                case "Buy Twenty Button":
                    button.onClick.AddListener(BuyLazy);
                    break;
                default:
                    break;
            }
        }
    }

    void LoadMainMenu()
    {
        GameManager.instance.ChangeScene(GameManager.Menus.MAIN);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            LoadMainMenu();
        }
    }

    public void Buy()
    {
        if (localPlayer.TotalCoins >= 5)
        {
            localPlayer.TotalCoins -= 5;
            moneyTextField.text = localPlayer.TotalCoins.ToString();
            localPlayer.AddGachaToList(GameManager.instance.GetRandomGacha(GachaSet));
        }

    }

    public void BuyLazy()
    {
        for (int i = 0; i < 20; i++)
        {
            Buy();
        }
    }
    
}
