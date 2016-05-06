﻿using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Json;
using System.IO;

public class Player : MonoBehaviour
{
    [Serializable]
    public struct PlacedGachaData
    {
        public GachaID id;
        public Vector3 position;
        public Quaternion rotation;
        public Vector3 scale;

        public PlacedGachaData(GachaID a_id, Vector3 a_position, Quaternion a_rotation, Vector3 a_scale)
        {
            id = a_id;
            position = a_position;
            rotation = a_rotation;
            scale = a_scale;
        }

    }
    #region public properties


    public int TotalCoins
    {
        get { return _totalCoins; }
        private set { _totalCoins = value; }
    }

    public static Player Instance;

    public List<GachaID> gachaCollection;
    public List<PlacedGachaData> placedInTownGachas = new List<PlacedGachaData>();
    public int Selected = 0;
    #endregion

    #region private fields
    [SerializeField]
    private int _totalCoins;
    #endregion

    #region unity lifecycle methods
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this.gameObject);
        }
        LoadState();
    }

    void OnDestroy()
    {
        SaveState();
    }
    #endregion

    #region Public API


    public void AddGachaToList(GachaID gachaID)
    {
        if (gachaCollection == null)
        {
            gachaCollection = new List<GachaID>();
        }
        gachaCollection.Add(gachaID);
    }

    public void ClearCollection()
    {
        gachaCollection.Clear();
    }

    public bool InCollection(GachaID gachaID)
    {
        if (gachaCollection == null)
        {
            return false;
        }
        return gachaCollection.Contains(gachaID);
    }

    public void AddCoins(int coins)
    {
        TotalCoins += coins;
    }

    public void DeductCoins(int coins)
    {
        int coinsLeft = TotalCoins - coins;
        Debug.Assert(coinsLeft >= 0, string.Format("Trying to deduct {0} coins from total of {1} leaving {2} coins.", coins, TotalCoins, coinsLeft));
        TotalCoins -= coins;

    }
    #endregion

    #region Save / Load State
    private void SaveState()
    {
        StreamWriter writer = new StreamWriter(Application.persistentDataPath + Constants.PLAYER_STATE_PATH);
        //string s = JsonUtility.ToJson(this);
        writer.Write(JsonUtility.ToJson(this));
        writer.Close();
    }

    private void LoadState()
    {
        string filePath = Application.persistentDataPath + Constants.PLAYER_STATE_PATH;
        if (!File.Exists(filePath))
        {
            Debug.LogWarning("State save file: [" + filePath + "] not found.");
            return;
        }

        StreamReader reader = new StreamReader(filePath);

        JsonUtility.FromJsonOverwrite(reader.ReadToEnd(), this);
        reader.Close();
    }
    #endregion
}
