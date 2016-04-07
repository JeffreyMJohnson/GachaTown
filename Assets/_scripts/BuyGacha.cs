using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BuyGacha : MonoBehaviour
{


    public Text moneyTextField;
    public Text displayTextField;
    public int GachaSet = 0;

    Player localPlayer;
    AudioSource buttonPress;
    void Start()
    {
        GameObject tPlayer = GameObject.FindGameObjectWithTag("Player");
        localPlayer = tPlayer.GetComponent<Player>();
        buttonPress = GetComponent<AudioSource>();
        moneyTextField.text = localPlayer.TotalCoins.ToString();
        displayTextField.text = GameManager.instance.GetGachaSet(GachaSet).name;

        //add onclick event for menu button
        Button menu = FindObjectOfType<Button>(); //can't add more than one button in this scene
        menu.onClick.AddListener(LoadMainMenu);
    }

    void LoadMainMenu()
    {
        buttonPress.Play();
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

    
}
