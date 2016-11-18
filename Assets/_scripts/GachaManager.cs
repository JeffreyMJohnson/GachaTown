using System;
using UnityEngine;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine.UI;

public class GachaManager : MonoBehaviour
{
    public enum Set { CITY, SPOOKY, SWEETS, TROPICAL};

    private List<GachaSet> _gachaSets;
    private GameObject _gachaUIPrefab;

    public int SetCount { get { return _gachaSets.Count; } }
    
    void Awake()
    {

        _gachaSets = LoadGachaSets();

        _gachaUIPrefab = Resources.Load<GameObject>("prefabs/GachaUI");
        Debug.Assert(_gachaUIPrefab != null, "Could not find GachaUI prefab in Resources folder.");
    }

    private List<GachaSet> LoadGachaSets()
    {
        //should match the enum because it makes sense and easier to access set
        List<GachaSet> result = new List<GachaSet>();
        result.Add(Resources.Load<GachaSet>("gachasets/City"));
        result.Add(Resources.Load<GachaSet>("gachasets/Spooky"));
        result.Add(Resources.Load<GachaSet>("gachasets/Sweets"));
        result.Add(Resources.Load<GachaSet>("gachasets/Tropical"));
        Debug.Assert(!result.Contains(null), "One or more GachaSets did not load.");
        return result;
    }

    #region public API

    public GachaID[] GetAllGachaIds()
    {
        List<GachaID> result = new List<GachaID>();
        for (int setIndex = 0; setIndex < SetCount; setIndex++)
        {
            for (int gachaIndex = 0; gachaIndex < GetGachaSet(setIndex).collection.Count; gachaIndex++)
            {
                result.Add(new GachaID(setIndex, gachaIndex));
            }
        }
        return result.ToArray();
    }

    public GachaSet GetGachaSet(Set set)
    {
        foreach (GachaSet gachaSet in _gachaSets)
        {
            if (gachaSet.id == set)
            {
                return gachaSet;
            }
        }
        Debug.LogError("Could not fine GachaSet: " + Enum.GetName(typeof(Set), set));
        return null;
    }

    /// <summary>
    /// returns prefab located at given GachaID data.
    /// </summary>
    /// <param name="gachaID"></param>
    /// <returns></returns>
    public GameObject GetGachaPrefab(GachaID gachaID)
    {
        return GetGachaSet(gachaID.SetIndex).collection[gachaID.GachaIndex];
    }

    /// <summary>
    /// return the name of the gacha prefab object of given id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public string GetGachaName(GachaID id)
    {
        return GetGachaSet(id.SetIndex).collection[id.GachaIndex].name;
    }
    [Obsolete]
    public GachaSet GetGachaSet(int setIndex)
    {
        Debug.Assert(setIndex >= 0 && setIndex < _gachaSets.Count, "setIndex value of " + setIndex + " is not valid.");
        return _gachaSets[setIndex];
    }




    /// <summary>
    /// returns Instance of GachaUI prefab with sprite and image set if gacha has them.
    /// </summary>
    /// <param name="gachaID"></param>
    /// <returns></returns>
    public GameObject GetGachaUI(GachaID gachaID)
    {
        GameObject newGachaUI = Instantiate<GameObject>(_gachaUIPrefab);
        newGachaUI.GetComponent<GachaUI>().ID = gachaID;
        Gacha gacha = GachaManager.Instance.GetGachaSet(gachaID.SetIndex).collection[gachaID.GachaIndex].GetComponent<Gacha>();
        if (gacha.gachaUI != null)
        {
            newGachaUI.GetComponentInChildren<Image>().sprite = gacha.gachaUI;
        }
        newGachaUI.name = gacha.name;
        return newGachaUI;
    }

    /// <summary>
    /// Returns a GachaID struct that points to the prefab of a random Gacha from the given set.
    /// NOTE:Use unity's Instantiate<GameObject>(GetGachaPrefab(GachaID)) to instantiate a gameObject from GachaID.
    /// </summary>
    /// <param name="set"></param>
    /// <returns></returns>
    public GachaID GetRandomGacha(Set set)
    {
        int randomIndex = UnityEngine.Random.Range(0, _gachaSets[(int)set].collection.Count);
        return new GachaID((int)set, randomIndex);
    }
    #endregion

    #region Singleton lazy instantiation logic
    protected GachaManager() { }

    private static GachaManager _instance;
    public static GachaManager Instance
    {
        get
        {
            if (applicationIsQuitting)
            {
                Debug.LogWarning("[Singleton] Instance 'GachaManager" +
                    "' already destroyed on application quit." +
                    " Won't create again - returning null.");
                return null;
            }
            if (_instance == null)
            {
                _instance = FindObjectOfType<GachaManager>();

                if (FindObjectsOfType<GachaManager>().Length > 1)
                {
                    Debug.LogError("[Singleton] Something went really wrong " +
                            " - there should never be more than 1 singleton!" +
                            " Reopening the scene might fix it.");
                    return _instance;
                }
                if (_instance == null)
                {
                    GameObject gachaManager = new GameObject();
                    _instance = gachaManager.AddComponent<GachaManager>();
                    gachaManager.name = "(singleton) GachaManager";

                    DontDestroyOnLoad(gachaManager);
                }
            }
            return _instance;
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
	public void OnDestroy()
    {
        applicationIsQuitting = true;
    }

    #endregion

}
