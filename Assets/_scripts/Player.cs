using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Player : MonoBehaviour
{
    public int TotalCoins = 0;
    public List<GameObject> GachaCollection = null;

    public void AddGachaToList(GameObject gacha)
    {
        if(GachaCollection == null)
        {
            GachaCollection = new List<GameObject>();
        }
        GachaCollection.Add(gacha);
    }

}
