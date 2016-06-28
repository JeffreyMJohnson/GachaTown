using UnityEngine;
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

        public PlacedGachaData(GameObject placedGacha)
        {
            id = placedGacha.GetComponent<Gacha>().ID;
            Transform gachaTransform = placedGacha.transform;
            position = gachaTransform.position;
            rotation = gachaTransform.rotation;
            scale = gachaTransform.localScale;
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

    //0 = spooky, 1 = sweets, 2 = tropical, 3 = city
    public int Selected = 0;    
    #endregion

    #region private fields
    [SerializeField]
    private int _totalCoins;
    [SerializeField]
    private List<PlacedGachaData> placedInTownGachas = new List<PlacedGachaData>();
    //todo THIS MUST BE FALSE FOR RELEASE!!
    private bool _allGachasMode = true;
    #endregion

    #region unity lifecycle methods

    private void Awake()
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

    private void Start()
    {
        if (_allGachasMode)
        {
            gachaCollection.Clear();
            gachaCollection = GachaManager.Instance.GetAllGachaIds();
        }
    }

    private void OnDestroy()
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

    public void SaveTownData(GameObject[] placedGachas)
    {
        placedInTownGachas.Clear();
        foreach (GameObject gacha in placedGachas)
        {
            placedInTownGachas.Add(new PlacedGachaData(gacha));
        }
    }

    public PlacedGachaData[] GetTownData()
    {
        return placedInTownGachas.ToArray();
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
