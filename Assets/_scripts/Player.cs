using UnityEngine;
using System.Collections.Generic;
using System.Linq;


public class Player : MonoBehaviour
{
    public int TotalCoins = 1000;
    public List<GameObject> gachaCollection;
    public int Selected = 1;

    Transform collectionParent;

    [SerializeField][HideInInspector]
    List<Gacha> collection;
    void Awake()
    {
         collectionParent = GameObject.Find("Collection").transform;
    }

    public void AddGachaToList(Gacha gacha)
    {
        if(collection == null)
        {
            collection = new List<Gacha>();
        }
        if (gachaCollection == null)
        {
            gachaCollection = new List<GameObject>();
        }
        GameObject gachaObject = LoadGacha(gacha);
        collection.Add(gacha);
        gachaCollection.Add(gachaObject);
    }

    public void ClearCollection()
    {
        collection.Clear();
        gachaCollection.Clear();
    }

    public bool BadCollectionLoaded()
    {
        return collection.Any(gacha => gacha == null);
    }

    GameObject LoadGacha(Gacha a_gacha)
    {
        GameObject gacha = GameManager.instance.GetGachaGameObject(a_gacha);
        gacha.transform.parent = collectionParent;
        gacha.name = a_gacha.name;
        return gacha;
    }


    public void LoadCollection()
    {
        if (BadCollectionLoaded())
        {
            return;
        }

        foreach(Gacha gacha in collection)
        {
            gachaCollection.Add(LoadGacha(gacha));
        }
    }

}
