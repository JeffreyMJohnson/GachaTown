using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Json;
using System.IO;
using System.Linq.Expressions;

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
    #region Singleton lazy instantiation logic
    protected Player() { }

    private static Player _instance;
    public static Player Instance
    {
        get
        {
            if (applicationIsQuitting)
            {
                Debug.LogWarning("[Singleton] Instance 'Player" +
                    "' already destroyed on application quit." +
                    " Won't create again - returning null.");
                return null;
            }
            if (_instance == null)
            {
                _instance = FindObjectOfType<Player>();

                if (FindObjectsOfType<Player>().Length > 1)
                {
                    Debug.LogError("[Singleton] Something went really wrong " +
                            " - there should never be more than 1 singleton!" +
                            " Reopening the scene might fix it.");
                    return _instance;
                }
                if (_instance == null)
                {
                    GameObject player = new GameObject();
                    _instance = player.AddComponent<Player>();

                    player.name = "(singleton) Player";

                    DontDestroyOnLoad(player);
                }
            }
            return _instance;
        }
    }
    #endregion

    #region public properties
    public int TotalCoins
    {
        get { return _totalCoins; }
        private set { _totalCoins = value; }
    }
    [SerializeField]
    public GachaID LastGachaAdded { get; private set; }

    [SerializeField]
    public GachaID[] GachaCollection { get { return _gachaCollection.ToArray(); } }

    [SerializeField]
    public GachaID[] UniqueGachaCollection
    {
        get
        {
            List<GachaID> result = new List<GachaID>(_gachaCollection.Count);
            foreach (GachaID gachaId in _gachaCollection)
            {
                if (!result.Contains(gachaId))
                {
                    result.Add(gachaId);
                }
            }
            return result.ToArray();
        }
    }

    //0 = spooky, 1 = sweets, 2 = tropical, 3 = city
    public int Selected = 0;
    #endregion

    #region private fields
    [SerializeField]
    private int _totalCoins;
    [SerializeField]
    private List<PlacedGachaData> _placedInTownGachas = new List<PlacedGachaData>();
    [SerializeField]
    private List<GachaID> _gachaCollection;
    //todo THIS MUST BE FALSE FOR RELEASE!!
    private bool _allGachasMode = true;
    #endregion

    #region unity lifecycle methods

    private void Awake()
    {
        LoadState();


    }

    private void Start()
    {
        if (_gachaCollection == null)
        {
            _gachaCollection = new List<GachaID>();
        }
        if (_allGachasMode)
        {
            _gachaCollection.Clear();
            _gachaCollection = new List<GachaID>(GachaManager.Instance.GetAllGachaIds());
            _totalCoins = 10000;
        }
    }

    private static bool applicationIsQuitting = false;
    /// <summary>
	/// When Unity quits, it destroys objects in a random order.
	/// In principle, a Singleton is only destroyed when application quits.
	/// If any script calls Instance after it have been destroyed, 
	///   it will create a buggy ghost object that will stay on the Editor scene
	///   even after stopping playing the Application. Really bad!
	/// So, this was made to be sure we're not creating that buggy ghost object.
	/// </summary>
    private void OnDestroy()
    {
        SaveState();
        applicationIsQuitting = true;
    }
    #endregion

    #region Public API


    public void AddGachaToCollection(GachaID gachaID)
    {
        if (_gachaCollection == null)
        {
            _gachaCollection = new List<GachaID>();
        }
        _gachaCollection.Add(gachaID);
        LastGachaAdded = gachaID;
    }

    public void ClearCollection()
    {
        _gachaCollection.Clear();
    }

    public bool InCollection(GachaID gachaID)
    {
        if (_gachaCollection == null)
        {
            return false;
        }
        return _gachaCollection.Contains(gachaID);
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
        _placedInTownGachas.Clear();
        foreach (GameObject gacha in placedGachas)
        {
            _placedInTownGachas.Add(new PlacedGachaData(gacha));
        }
    }

    public PlacedGachaData[] GetTownData()
    {
        return _placedInTownGachas.ToArray();
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
            _totalCoins = 100;
            return;
        }

        StreamReader reader = new StreamReader(filePath);

        JsonUtility.FromJsonOverwrite(reader.ReadToEnd(), this);
        reader.Close();
    }
    #endregion
}
