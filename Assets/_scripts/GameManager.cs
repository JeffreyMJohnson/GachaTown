using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager manager;

    public List<string> masterPathList = null;
    public List<Gacha> MasterGachaCollection;

    Transform playerTransform;

    void Start()
    {
        playerTransform = GetComponentInChildren<Player>().transform;
    }

    void Awake()
    {
        if (manager == null)
        {
            DontDestroyOnLoad(gameObject);
            manager = this;
        }
        else if(manager != this)
        {
            Destroy(gameObject);
        }

    }

    public int GetRandomGachaIndex()
    {
        int randomIndex = Random.Range(0, MasterGachaCollection.Count - 1);
        return randomIndex;

    }

    public GameObject GetGachaGameObject(int index)
    {
        Gacha gacha = MasterGachaCollection[index];
        GameObject newGacha = Instantiate<GameObject>(gacha.basePrefab);
        GachaManager gachaMan = newGacha.GetComponent<GachaManager>();
        gachaMan.SetGachaData(gacha);
        return newGacha;
    }
}
