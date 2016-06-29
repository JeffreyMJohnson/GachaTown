using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine.UI;

public class GachaManager : MonoBehaviour
{
    private List<GachaSet> _gachaSets;
    private GameObject _gachaUIPrefab;

    public int SetCount { get { return _gachaSets.Count; } }

    void Awake()
    {
        _gachaSets = new List<GachaSet>(Resources.LoadAll<GachaSet>("gachasets"));
        if (_gachaSets.Count < 1)
        {
            Debug.LogException(new Exception("No GachaSet objects found in project."));
        }
        else
        {
            Debug.Log(_gachaSets.Count + " GachaSet objects found in project");
        }
        _gachaUIPrefab = Resources.Load<GameObject>("prefabs/GachaUI");
        Debug.Assert(_gachaUIPrefab != null, "Could not find GachaUI prefab in Resources folder.");
    }


    #region public API
    public List<GachaID> GetAllGachaIds()
    {
        List<GachaID> result = new List<GachaID>();
        for (int setIndex = 0; setIndex < SetCount; setIndex++)
        {
            for (int gachaIndex = 0; gachaIndex < GetGachaSet(setIndex).collection.Count; gachaIndex++)
            {
                result.Add(new GachaID(setIndex, gachaIndex));
            }
        }
        return result;
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
    /// Returns a GachaID struct that points to the prefab of a random Gacha from the given set index.
    /// NOTE:Use unity's Instantiate<GameObject>(GetGachaPrefab(GachaID)) to instantiate a gameObject from GachaID.
    /// </summary>
    /// <param name="setIndex"></param>
    /// <returns></returns>
    public GachaID GetRandomGacha(int setIndex)
    {
        int randomIndex = UnityEngine.Random.Range(0, _gachaSets[setIndex].collection.Count);
        return new GachaID(setIndex, randomIndex);
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

                    Debug.Log("[Singleton] An instance of GachaManager" +
                            " is needed in the scene, so '" + gachaManager +
                            "' was created with DontDestroyOnLoad.");
                }
                else
                {
                    Debug.Log("[Singleton] Using instance already created: " +
                            _instance.gameObject.name);
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
