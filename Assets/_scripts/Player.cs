using UnityEngine;
using System.Collections.Generic;


public class Player : MonoBehaviour
{
    public int TotalCoins = 0;
    public List<int> MyGachaCollection = null;

    new Transform transform;
    Transform collectionParent;

    void Awake()
    {
        transform = GetComponent<Transform>();
        collectionParent = GameObject.Find("Collection").transform;
    }



    public void AddGachaToList(int index)
    {
        if (MyGachaCollection == null)
        {
            MyGachaCollection = new List<int>();
        }
        MyGachaCollection.Add(index);
        LoadGacha(index);
    }

    void LoadGacha(int index)
    {
        GameObject gacha = GameManager.manager.GetGachaGameObject(index);
        gacha.transform.parent = collectionParent;
        gacha.name = GameManager.manager.MasterGachaCollection[index].name;
    }


    public void LoadCollection()
    {
        foreach (int index in MyGachaCollection)
        {
            LoadGacha(index);
        }
    }

}
