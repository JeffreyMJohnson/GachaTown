using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BuyGacha : MonoBehaviour
{


    public Text moneyTextField;
    public int GachaSet = 0;
    Player localPlayer;

    void Start()
    {
        GameObject tPlayer = GameObject.FindGameObjectWithTag("Player");
        localPlayer = tPlayer.GetComponent<Player>();
        moneyTextField.text = localPlayer.TotalCoins.ToString();
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
