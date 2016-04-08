using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BuyGacha : MonoBehaviour
{


    public Text moneyTextField;
    public Text displayTextField;
    public int GachaSet = 0;

    Player localPlayer;
    AudioSource buttonSound;
    void Start()
    {
        GameObject tPlayer = GameObject.FindGameObjectWithTag("Player");
        localPlayer = tPlayer.GetComponent<Player>();
        buttonSound = GetComponent<AudioSource>();
        moneyTextField.text = localPlayer.TotalCoins.ToString();

        if (localPlayer.Selected > GameManager.instance.setList.Count - 1)
            localPlayer.Selected = GameManager.instance.setList.Count - 1;

        GachaSet = localPlayer.Selected;
        displayTextField.text = GameManager.instance.GetGachaSet(GachaSet).name;

        //add onclick event for menu button
        Button[] buttons = FindObjectsOfType<Button>();
        foreach (Button button in buttons)
        {
            switch(button.name)
            {
                case "Main Menu Button":
                    button.onClick.AddListener(delegate { HandleClick(GameManager.Menus.MAIN); });
                    break;
                case "Buy Twenty Button":
                    button.onClick.AddListener(BuyLazy);
                    break;
                default:
                    break;
            }
        }
    }
    public void HandleClick(GameManager.Menus scene)
    {

        buttonSound.Play();//sometimes doesn't work if you click multiple times
        GameManager.instance.ChangeScene(scene);
    }

    

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            HandleClick(GameManager.Menus.MAIN);
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
