﻿using UnityEngine;
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
        Button menu = FindObjectOfType<Button>();
        menu.onClick.AddListener(LoadMainMenu);
    }

    void LoadMainMenu()
    {
        GameManager.instance.ChangeScene(GameManager.Menus.MAIN);
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
