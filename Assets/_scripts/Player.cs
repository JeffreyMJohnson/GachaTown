using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Json;
using System.IO;

public class Player : MonoBehaviour
{
    #region public properties
    public int TotalCoins { get; private set; }

    [SerializeField]
    public List<GachaID> gachaCollection;
    public int Selected = 0;
    #endregion

    #region private fields
    Transform collectionParent;

    #endregion

    #region unity lifecycle methods
    void Awake()
    {
        collectionParent = GameObject.Find("Collection").transform;
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
        string s = JsonUtility.ToJson(this);
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
