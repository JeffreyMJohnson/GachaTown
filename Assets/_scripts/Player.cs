using UnityEngine;
using System.Collections.Generic;


public class Player : MonoBehaviour
{
    public int TotalCoins = 0;
    public List<Gacha> collection;

    new Transform transform;
    Transform collectionParent;

    void Awake()
    {
        transform = GetComponent<Transform>();
        collectionParent = GameObject.Find("Collection").transform;
    }

    public void AddGachaToList(Gacha gacha)
    {
        if(collection == null)
        {
            collection = new List<Gacha>();
        }
        collection.Add(gacha);
        LoadGacha(gacha);
    }

    void LoadGacha(Gacha a_gacha)
    {
        GameObject gacha = GameManager.instance.GetGachaGameObject(a_gacha);
        gacha.transform.parent = collectionParent;
        gacha.name = a_gacha.name;
    }


    public void LoadCollection()
    {
         foreach(Gacha gacha in collection)
        {
            LoadGacha(gacha);
        }
    }

}
