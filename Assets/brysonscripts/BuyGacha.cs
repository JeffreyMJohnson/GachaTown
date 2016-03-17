using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BuyGacha : MonoBehaviour {

    [SerializeField]
    Text money;
    //GameObject playerObj;
    //[SerializeField]
    int moneyInt;
    Player localPlayer;

	void Start () {
        GameObject tPlayer = GameObject.FindGameObjectWithTag("Player");
        localPlayer = tPlayer.GetComponent<Player>();
        moneyInt = localPlayer.TotalCoins;
        money.text = moneyInt.ToString();
	}
	
	void Update () {
        
    }
   public void Buy()
    {
        if (moneyInt >= 5)
        {
            GameObject tPlayer = GameObject.FindGameObjectWithTag("Player");
            moneyInt -= 5;
            money.text = tPlayer.GetComponent<Player>().TotalCoins.ToString();
            //localPlayer.TotalCoins = moneyInt;
            tPlayer.GetComponent<Player>().TotalCoins = moneyInt;
        }
        
    }
}
