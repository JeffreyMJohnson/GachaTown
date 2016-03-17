using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BuyGacha : MonoBehaviour {

    [SerializeField]
    Text money;
    [SerializeField]
    int moneyInt;

	void Start () {
        
	}
	
	void Update () {
        
    }
   public void Buy()
    {
        moneyInt -= 5;
        money.text = moneyInt.ToString();
    }
}
