using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Player : MonoBehaviour
{
    public int TotalCoins = 0;
    public List<string> GachaCollection = null;


    

    public void AddGachaToList(string gacha)
    {
        if(GachaCollection == null)
        {
            GachaCollection = new List<string>();
        }
        GachaCollection.Add(gacha);
    }

}
