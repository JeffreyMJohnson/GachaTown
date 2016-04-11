using UnityEngine;
using System.Collections.Generic;
using System.Linq;


public class Player : MonoBehaviour
{
    public int TotalCoins = 1000;
    [SerializeField]
    public List<GameManager.GachaID> gachaCollection;

#if DEBUG
    public List<GameObject> collectionObjects;
#endif 

    public int Selected = 1;

    Transform collectionParent;

    [SerializeField]
    [HideInInspector]
    void Awake()
    {
        collectionParent = GameObject.Find("Collection").transform;

#if DEBUG
        collectionObjects = new List<GameObject>();
#endif
    }

    public void AddGachaToList(GameManager.GachaID gachaID)
    {
        if (gachaCollection == null)
        {
            gachaCollection = new List<GameManager.GachaID>();
        }
        gachaCollection.Add(gachaID);

#if DEBUG
        GameObject gacha = GameManager.instance.GetGacha(gachaID.setIndex, gachaID.gachaIndex);
        gacha.transform.position = Vector3.right * 100;
        collectionObjects.Add(gacha);
#endif
    }

    public void ClearCollection()
    {
        gachaCollection.Clear();
    }

}
