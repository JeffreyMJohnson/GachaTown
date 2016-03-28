﻿using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum Menus { SPLASH, MAIN, GACHA, TOWN, COLLECTION, SETTING, GACHACHOOSE, HOW_TO_PLAY }

    public static GameManager instance;
    public List<GachaSet> setList = new List<GachaSet>();
    Transform playerTransform;

    void Start()
    {
        playerTransform = GetComponentInChildren<Player>().transform;
    }

    void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

    }

    public GachaSet GetGachaSet(int setIndex)
    {
        return setList[setIndex];
    }

    public Gacha GetRandomGacha(int setIndex)
    {
        int randomIndex = Random.Range(0, setList[setIndex].collection.Count);
        return setList[setIndex].collection[randomIndex];
    }

    public GameObject GetGachaGameObject(Gacha gacha)
    {
        GameObject newGacha = Instantiate<GameObject>(gacha.basePrefab);
        GachaManager gachaMan = newGacha.GetComponent<GachaManager>();
        gachaMan.SetGachaData(gacha);
        return newGacha;
    }

    public GameObject GetGachaGameObject(int setIndex, int gachaIndex)
    {
        Gacha gacha = setList[setIndex].collection[gachaIndex];
        GameObject newGacha = Instantiate<GameObject>(gacha.basePrefab);
        GachaManager gachaMan = newGacha.GetComponent<GachaManager>();
        gachaMan.SetGachaData(gacha);
        return newGacha;
    }

    public void ChangeScene(Menus scene)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene((int)scene);
        //menuState = aChangeTo;
    }
}
