using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Player : MonoBehaviour
{
    public int TotalCoins = 0;
    public List<string> GachaCollection = null;

    new Transform transform;

    void Awake()
    {
        transform = GetComponent<Transform>();
    }
    

    public void AddGachaToList(string gacha)
    {
        if(GachaCollection == null)
        {
            GachaCollection = new List<string>();
        }
        GachaCollection.Add(gacha);
        PlayerLoadSave.LoadGacha(gacha, transform);
    }

}
