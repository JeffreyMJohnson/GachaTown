using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BuyGacha : MonoBehaviour
{


    public Text moneyTextField;
    Player localPlayer;
    GameManager gameManager;

    void Start()
    {
        GameObject tPlayer = GameObject.FindGameObjectWithTag("Player");
        gameManager = tPlayer.GetComponentInParent<GameManager>();
        localPlayer = tPlayer.GetComponent<Player>();
        moneyTextField.text = localPlayer.TotalCoins.ToString();
    }
    public void Buy()
    {
        if (localPlayer.TotalCoins >= 5)
        {
            localPlayer.TotalCoins -= 5;
            moneyTextField.text = localPlayer.TotalCoins.ToString();
            localPlayer.AddGachaToList(gameManager.GetRandomGacha());
        }

    }
}
